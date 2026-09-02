using Home.Models;
using Microsoft.EntityFrameworkCore;

namespace Home.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<HomeModel> Homes { get; set; }
    }
}