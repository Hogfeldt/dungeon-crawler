using Microsoft.EntityFrameworkCore;
using ServerApp.Database.Models;

namespace ServerApp.Data
{
    public class ServerAppContext : DbContext
    {
        public ServerAppContext (DbContextOptions<ServerAppContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfoModel> UserInfoModel { get; set; }

        public DbSet<CharacterModel> CharacterModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterModel>()
                .HasOne(c => c.UserInfoModel)
                .WithMany(u => u.CharacterModels)
                .HasForeignKey(c => c.Username)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
