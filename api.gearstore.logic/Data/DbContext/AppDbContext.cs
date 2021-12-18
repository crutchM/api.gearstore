using api.gearstore.logic.Models;
using Microsoft.EntityFrameworkCore;

namespace api.gearstore.logic.Data.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<UserData> Users { get; set; }
        
        public DbSet<CharData> Chars { get; set; }
        public DbSet<LotData> Lots { get; set; }
        public DbSet<SessionData> Sessions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) => 
            Database.EnsureCreated();
    }
}
