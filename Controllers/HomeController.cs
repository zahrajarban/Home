using Home.Data;
using Home.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Home.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Home
        [HttpPost("List")]
        public async Task<IActionResult> GetHomes()
        {
            var homes = await _context.Homes
                .Include(h => h.User)
                .ToListAsync();

            return Ok(homes);
        }

        // GET: api/Home/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHome(int id)
        {
            var home = await _context.Homes
                .Include(h => h.User)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (home == null)
            {
                return NotFound();
            }

            return Ok(home);
        }

        // POST: api/Home
        [HttpPost]
        public async Task<IActionResult> CreateHome(HomeModel home)
        {
            _context.Homes.Add(home);

            await _context.SaveChangesAsync();

            return Ok(home);
        }
    }
}