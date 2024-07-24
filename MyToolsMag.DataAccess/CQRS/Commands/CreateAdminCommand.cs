using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class CreateAdminCommand : CommandBase<Admin, Admin>
    {
        public override async Task<Admin> Execute(WarehouseStorageContext context)
        {
            await context.Admins.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
