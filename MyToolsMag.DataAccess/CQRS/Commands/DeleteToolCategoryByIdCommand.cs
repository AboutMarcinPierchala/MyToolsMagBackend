using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class DeleteToolCategoryByIdCommand : CommandBase<ToolCategory, bool>
    {
        public override async Task<bool> Execute(WarehouseStorageContext context)
        {
            try
            {
                context.ToolCategories.Remove(this.Parameter);
                await context.SaveChangesAsync();
                //return this.Parameter;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
