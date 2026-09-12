using Home.Models;
using Home.Services;
using Microsoft.AspNetCore.Mvc;
namespace Home.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;
        public FavoriteController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteDto favorite)
        {
            var result = await _favoriteService.AddFavorite(favorite.UserId,favorite.HomeId);
            if (!result)
                return BadRequest("This home is already in favorites.");
            return Ok("Home added to favorites.");
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _favoriteService.GetFavorites(userId);
            return Ok(favorites);
        }
        [HttpGet("{userId}/{homeId}")]
        public async Task<IActionResult> DeleteFavorite(
            int userId,
            int homeId)
        {
            var result = await _favoriteService
                .DeleteFavorite(userId, homeId);
            if (!result)
                return NotFound("Favorite not found.");
            return Ok("Home removed from favorites.");
        }
    }
}