using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;


namespace MyToolsMag.DataAccess
{
    public class WarehouseStorageContext : DbContext
    {
        public WarehouseStorageContext(DbContextOptions<WarehouseStorageContext> opt) : base(opt)
        {
            
        }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<ToolCategory> ToolCategories { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
