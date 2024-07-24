using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class AddToolCategoryCommand : CommandBase<ToolCategory, ToolCategory>
    {
        public override async Task<ToolCategory> Execute(WarehouseStorageContext context)
        {
            await context.ToolCategories.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
