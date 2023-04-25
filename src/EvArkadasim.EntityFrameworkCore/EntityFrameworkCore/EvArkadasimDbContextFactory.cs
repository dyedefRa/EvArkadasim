using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EvArkadasim.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class EvArkadasimDbContextFactory : IDesignTimeDbContextFactory<EvArkadasimDbContext>
    {
        public EvArkadasimDbContext CreateDbContext(string[] args)
        {
            EvArkadasimEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EvArkadasimDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new EvArkadasimDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EvArkadasim.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
