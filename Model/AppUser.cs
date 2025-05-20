using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Model
{
    public class AppUser: IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
