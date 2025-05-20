using BookStoreApi.Model;

namespace BookStoreApi.Repository.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
