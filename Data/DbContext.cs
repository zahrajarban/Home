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

        public DbSet<UserModel> Users { get; set; }

        public DbSet<FavoriteModel> Favorites { get; set; }

        public DbSet<HomeInfoModel> HomeInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HomeModel>()
                .HasOne(h => h.User)
                .WithMany(u => u.Homes)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<FavoriteModel>()
                .HasKey(f => new { f.UserId, f.HomeId });

            modelBuilder.Entity<FavoriteModel>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteModel>()
                .HasOne(f => f.Home)
                .WithMany()
                .HasForeignKey(f => f.HomeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HomeInfoModel>()
                .HasKey(h => h.HomeId);

           
        }
    }
}