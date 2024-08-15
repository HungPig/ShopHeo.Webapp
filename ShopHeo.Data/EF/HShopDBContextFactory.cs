using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShopHeo.Data.EF
{
    public class HshopDBContextFactory : IDesignTimeDbContextFactory<HshopDBContext>
    {
        public HshopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var ConnectionString = configuration.GetConnectionString("HeoShopSolution");
            var optionsBuilder = new DbContextOptionsBuilder<HshopDBContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new HshopDBContext(optionsBuilder.Options);
        }
    }
}
