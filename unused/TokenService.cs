using eClat.Common.Cache;
using eClat.Common.Model;
using eClat.Common.Utilities;
using eclinic.api.Entity;
using eclinic.api.Models;
using eclinic.api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eclinic.api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        private readonly RedisService _redisService;

        private string REFRESH_TOKEN_HASH = "jwt_refresh_hash";

        public TokenService(IConfiguration config, RedisService redisService,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
            _redisService = redisService;
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<ApiResponseObject> CreateToken(LoginModel loginModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Username.ToLower());

            if (user == null) return null;

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (!result.Succeeded) return null;

            var tokenString = await GetToken(user); 
            var newRefreshToken = await GetRefreshToken(user);

            return new ApiResponseObject(
                HttpStatusCode.OK,
                HttpStatusCode.OK.ToString(),
                "Operation successfully completed",
                new { AccessToken = tokenString, RefreshToken = newRefreshToken }
            );
        }


        public async Task<ApiResponseObject> CreateRefreshToken(RefreshTokenModel refreshTokenModel)
        {
            if (string.IsNullOrEmpty(refreshTokenModel.RefreshToken))
            {
                return null;
            }

            String refreshToken = refreshTokenModel.RefreshToken;

            // extract calims from jwt token
            ClaimsPrincipal claimsPrincipal = ValidateToken(refreshToken);
            if (claimsPrincipal == null)
            {
                return null;
            }

            //extract claims from token
            String Jti = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            String Email = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

            //inject appUser repo
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == Email.ToLower());

            //retrieve token - if not found it means refresh token has expired
            String savedRefreshToken = await _redisService.GetHashFieldAsync(Jti, REFRESH_TOKEN_HASH);

            if (savedRefreshToken == null || user == null)
            {
                return null;
            }

            var tokenString = await GetToken(user);
            var newRefreshToken = await GetRefreshToken(user);

            return new ApiResponseObject(
                HttpStatusCode.OK,
                HttpStatusCode.OK.ToString(),
                "Operation successfully completed",
                new { AccessToken = tokenString, RefreshToken = newRefreshToken }
            );
        }


        public async Task<ApiResponseObject> Register(RegisterUserModel registerEClatUserModel)
        {
            try
            {
                var appUser = new ApplicationUser
                {
                    UserName = registerEClatUserModel.Email,
                    Email = registerEClatUserModel.Email,
                    FirstName = registerEClatUserModel.FirstName,
                    LastName = registerEClatUserModel.LastName
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerEClatUserModel.Password);

                if (createdUser.Succeeded)
                {
                    var tokenString = await GetToken(appUser);
                    var newRefreshToken = await GetRefreshToken(appUser);

                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private async Task<string> GetRefreshToken(ApplicationUser user)
        {
            string tokenKey = Guid.NewGuid().ToString();
            var refreshClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Jti, tokenKey),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var refreshCreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var refreshTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(refreshClaims),
                Expires = DateTime.Now.AddDays(7), // Longer expiry for refresh token
                SigningCredentials = refreshCreds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var refreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);
            var token = tokenHandler.WriteToken(refreshToken);

            await _redisService.SetHashWithExpirationAsync(tokenKey, REFRESH_TOKEN_HASH, token, TimeSpan.FromDays(7));

            return token;
        }

        private async Task<string> GetToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id) ),
                new Claim(JwtRegisteredClaimNames.Name, user.Email)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            var refreshCreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience =  _config["JWT:Audience"];
            validationParameters.ValidIssuer = _config["JWT:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}