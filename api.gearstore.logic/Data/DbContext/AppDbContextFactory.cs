using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace api.gearstore.logic.Data.DbContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // Надо понять как брать это значение из appsettings.json
        private const string ConnectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}