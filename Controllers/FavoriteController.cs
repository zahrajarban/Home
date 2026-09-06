using Home.Data;
using Home.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Home.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FavoriteController(AppDbContext context)
        {
            _context = context;
        }
              

        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteModel favorite)
        {
            var exists = await _context.Favorite
                .AnyAsync(f => f.UserId == favorite.UserId &&
                              f.HomeId == favorite.HomeId);
            if (exists)
            {
                return BadRequest("This home is already in favorites.");
            }
            _context.Favorite.Add(favorite);
            await _context.SaveChangesAsync();
            return Ok("Home added to favorites.");
        }
     

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _context.Favorite
                .Include(f => f.Home)
                .Where(f => f.UserId == userId)
                .ToListAsync();
            return Ok(favorites);
        }
      

        [HttpDelete("{UserId}/{HomeId}")]
        public async Task<IActionResult> DeleteFavorite(
            int userId,
            int homeId)
        {
            var favorite = await _context.Favorite
                .FirstOrDefaultAsync(f =>
                    f.UserId == userId &&
                    f.HomeId == homeId);
            if (favorite == null)
            {
                return NotFound("Favorite not found.");
            }
            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();
            return Ok("Home removed from favorites.");
        }
    }
}