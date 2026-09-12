using Home.Data;
using Home.Models;
using Microsoft.EntityFrameworkCore;
namespace Home.Services
{
    public class FavoriteService
    {
        private readonly AppDbContext _context;
        public FavoriteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFavorite(int UserId, int HomeId)
        {
            var exists = await _context.Favorites
                .AnyAsync(f =>
                    f.UserId == UserId &&
                    f.HomeId == HomeId && !f.IsDeleted);
                    
            if (exists)
                return false;
            var favorite = new FavoriteModel
            {
                UserId = UserId,
                HomeId = HomeId
            };
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<FavoriteModel>> GetFavorites(int userId)
        {
            return await _context.Favorites
                .Include(f => f.Home)
                .Where(f => f.UserId == userId && !f.IsDeleted)
                .ToListAsync();

        }

        public async Task<bool> DeleteFavorite(int userId, int homeId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f =>
                    f.UserId == userId &&
                    f.HomeId == homeId);
            if (favorite == null || favorite.IsDeleted)
            {
                return false;
            }
           

            favorite.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}