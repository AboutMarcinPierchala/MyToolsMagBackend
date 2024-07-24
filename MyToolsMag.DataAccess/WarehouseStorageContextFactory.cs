using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess
{
    internal class WarehouseStorageContextFactory : IDesignTimeDbContextFactory<WarehouseStorageContext>
    {
        
        private const string ConnectionString = "DB_CONNECTIONSTRING";//replace with current dbconnstr

        public WarehouseStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseStorageContext>();
            optionsBuilder.UseSqlServer(ConnectionString, options => options.EnableRetryOnFailure());
            return new WarehouseStorageContext(optionsBuilder.Options);
        }
    }
}
