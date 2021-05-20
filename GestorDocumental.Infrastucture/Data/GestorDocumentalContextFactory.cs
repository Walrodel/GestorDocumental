using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GestorDocumental.Infrastucture.Data
{
    public class GestorDocumentalContextFactory : IDesignTimeDbContextFactory<GestorDocumentalContext>
    {
        public GestorDocumentalContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GestorDocumentalContext>();
            var connectionString = configuration.GetConnectionString("Connection");
            optionsBuilder.UseSqlServer(connectionString);

            return new GestorDocumentalContext(optionsBuilder.Options);
        }
    }
}