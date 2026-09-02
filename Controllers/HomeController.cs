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

        
        [HttpPost]
        public async Task<IActionResult> SetHome(Home.Models.HomeModel home)
        {
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return Ok(home);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHome(int id)
        {
            var home = await _context.Homes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (home == null)
                return NotFound();

            return Ok(home);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id)
        {
            var home = await _context.Homes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (home == null)
                return NotFound();

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return Ok("Home deleted successfully");
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHome(
            int id,
            Home.Models.HomeModel home)
        {
            var existingHome = await _context.Homes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingHome == null)
                return NotFound();

            existingHome.Address = home.Address;
            existingHome.Area = home.Area;
            existingHome.Rent = home.Rent;
            existingHome.Deposit = home.Deposit;
            existingHome.Lat = home.Lat;
            existingHome.Lng = home.Lng;

            await _context.SaveChangesAsync();

            return Ok(existingHome);
        }
    }
}