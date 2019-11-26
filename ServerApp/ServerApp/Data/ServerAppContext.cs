using Microsoft.EntityFrameworkCore;

namespace ServerApp.Data
{
    public class ServerAppContext : DbContext
    {
        public ServerAppContext (DbContextOptions<ServerAppContext> options)
            : base(options)
        {
        }

        public DbSet<ServerApp.Database.Models.UserInfoModel> UserInfoModel { get; set; }
    }
}
