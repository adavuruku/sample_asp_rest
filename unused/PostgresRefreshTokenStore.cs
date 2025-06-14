// using eClat.Common.Model;
// using eClat.Common.Utilities;
// using eclinic.api.Data;
// using Microsoft.EntityFrameworkCore;

// namespace eclinic.api.Configuration;

// public class PostgresRefreshTokenStore  : IRefreshTokenStore
// {
//     private readonly ApplicationDbContext _context;

//     public PostgresRefreshTokenStore(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task AddTokenAsync(RefreshToken token)
//     {
//         await _context.RefreshTokens.AddAsync(token);
//         await _context.SaveChangesAsync();
//     }

//     public async Task<RefreshToken> GetTokenAsync(string token)
//     {
//         return await _context.RefreshTokens
//             .FirstOrDefaultAsync(t => t.Token == token);
//     }

//     public async Task RemoveTokenAsync(string token)
//     {
//         var refreshToken = await GetTokenAsync(token);
//         if (refreshToken != null)
//         {
//             _context.RefreshTokens.Remove(refreshToken);
//             await _context.SaveChangesAsync();
//         }
//     }

//     public async Task RevokeTokenAsync(string token)
//     {
//         var refreshToken = await GetTokenAsync(token);
//         if (refreshToken != null)
//         {
//             refreshToken.IsRevoked = true;
//             await _context.SaveChangesAsync();
//         }
//     }
// }
