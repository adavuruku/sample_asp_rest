// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using eClat.Common.Model;
// using eClat.Common.Utilities;
// using eclinic.api.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;

// namespace eclinic.api.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class AuthController : ControllerBase
//     {
//         private readonly JwtSettings _jwtSettings;
//         private readonly IRefreshTokenStore _refreshTokenStore;

//         public AuthController(IOptions<JwtSettings> jwtSettings, IRefreshTokenStore refreshTokenStore)
//         {
//             _jwtSettings = jwtSettings.Value;
//             _refreshTokenStore = refreshTokenStore;
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login([FromBody] LoginModel model)
//         {
//             // Simplified user validation (replace with real user store in production)
//             if (model.Username != "testuser" || model.Password != "password123")
//             {
//                 return Unauthorized("Invalid credentials");
//             }

//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new[]
//                 {
//                 new Claim(ClaimTypes.Name, model.Username),
//                 new Claim(ClaimTypes.Role, "User")
//             }),
//                 Expires = DateTime.UtcNow.AddHours(1),
//                 Issuer = _jwtSettings.Issuer,
//                 Audience = _jwtSettings.Audience,
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             var tokenString = tokenHandler.WriteToken(token);

//             // Generate refresh token
//             var refreshToken = Guid.NewGuid().ToString();
//             var refreshTokenModel = new RefreshToken
//             {
//                 Token = refreshToken,
//                 Username = model.Username,
//                 Expiry = DateTime.UtcNow.AddDays(7)
//             };
//             _refreshTokenStore.AddTokenAsync(refreshTokenModel);

//             return Ok(new { AccessToken = tokenString, RefreshToken = refreshToken });
//         }

//         [HttpPost("refresh")]
//         public async Task<IActionResult> Refresh([FromBody] RefreshTokenModel model)
//         {
//             if (string.IsNullOrEmpty(model.RefreshToken))
//             {
//                 return BadRequest("Refresh token is required");
//             }

//             var storedToken = await _refreshTokenStore.GetTokenAsync(model.RefreshToken);
//             if (storedToken == null || storedToken.Expiry < DateTime.UtcNow)
//             {
//                 return Unauthorized("Invalid or expired refresh token");
//             }

//             // Invalidate the old refresh token
//             _refreshTokenStore.RemoveTokenAsync(model.RefreshToken);

//             // Generate new access token
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new[]
//                 {
//                 new Claim(ClaimTypes.Name, storedToken.Username),
//                 new Claim(ClaimTypes.Role, "User")
//             }),
//                 Expires = DateTime.UtcNow.AddHours(1),
//                 Issuer = _jwtSettings.Issuer,
//                 Audience = _jwtSettings.Audience,
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             var tokenString = tokenHandler.WriteToken(token);

//             // Generate new refresh token
//             var newRefreshToken = Guid.NewGuid().ToString();
//             var newRefreshTokenModel = new RefreshToken
//             {
//                 Token = newRefreshToken,
//                 Username = storedToken.Username,
//                 Expiry = DateTime.UtcNow.AddDays(7)
//             };
//             _refreshTokenStore.AddTokenAsync(newRefreshTokenModel);

//             return Ok(new { AccessToken = tokenString, RefreshToken = newRefreshToken });
//         }
//     }

// }