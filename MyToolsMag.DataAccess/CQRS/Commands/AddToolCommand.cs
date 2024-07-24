using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class AddToolCommand : CommandBase<Tool, Tool>
    {
        public override async Task<Tool> Execute(WarehouseStorageContext context)
        {
            await context.Tools.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
