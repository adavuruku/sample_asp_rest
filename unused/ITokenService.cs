using eClat.Common.Model;
using eclinic.api.Entity;
using eclinic.api.Models;

namespace eclinic.api.Services.Interfaces
{
    public interface ITokenService
    {
        Task<ApiResponseObject> CreateToken(LoginModel loginModel);

        Task<ApiResponseObject> CreateRefreshToken(RefreshTokenModel refreshTokenModel);

        Task<ApiResponseObject> Register(RegisterUserModel registerEClatUserModel);
    }
}
