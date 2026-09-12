using Home.Models;
using Home.Services;
using Microsoft.AspNetCore.Mvc;
namespace Home.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HomeService _homeService;
        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHomes()
        {
            return Ok(await _homeService.GetHomes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHome(int id)
        {
            var home = await _homeService.GetHome(id);
            if (home == null)
                return NotFound();
            return Ok(home);
        }
        [HttpPost]
        public async Task<IActionResult> AddHome(HomeModel home)
        {
            var result = await _homeService.AddHome(home);
            return Ok(result);
        }
    }
}