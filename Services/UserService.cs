using Home.Data;
using Home.Models;
using Microsoft.EntityFrameworkCore;
namespace Home.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<UserModel>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<UserModel?> GetUser(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<UserModel> AddUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}