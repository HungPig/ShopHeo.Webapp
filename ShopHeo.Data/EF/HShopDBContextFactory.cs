using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShopHeo.Data.EF
{
    public class HShopDBContextFactory : IDesignTimeDbContextFactory<HShopDBContext>
    {
        public HShopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var ConnectionString = configuration.GetConnectionString("ShopHeoDb");
            var optionsBuilder = new DbContextOptionsBuilder<HShopDBContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new HShopDBContext(optionsBuilder.Options);
        }
    }
}
