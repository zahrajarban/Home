using Home.Data;
using Home.Models;
using Microsoft.EntityFrameworkCore;
namespace Home.Services
{
    public class HomeService
    {
        private readonly AppDbContext _context;
        public HomeService(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<List<HomeModel>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }
       
        public async Task<HomeModel?> GetHome(int id)
        {
            return await _context.Homes
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        
        public async Task<HomeModel> AddHome(HomeModel home)
        {
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();
            return home;
        }
    }
}