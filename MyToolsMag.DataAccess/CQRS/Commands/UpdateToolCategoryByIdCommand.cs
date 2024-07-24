using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class UpdateToolCategoryByIdCommand : CommandBase<ToolCategory, ToolCategory>
    {
        //public int Id { get; set; }
        public override async Task<ToolCategory> Execute(WarehouseStorageContext context)
        {

            var existingOrder = context.ToolCategories.Local.SingleOrDefault(o => o.Id == Parameter.Id);
            if (existingOrder != null)
                context.Entry(existingOrder).State = EntityState.Detached;

            context.Update(this.Parameter);

            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
