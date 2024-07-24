using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class UpdateToolByIdCommand : CommandBase<Tool, Tool>
    {
        //public int Id { get; set; }
        public override async Task<Tool> Execute(WarehouseStorageContext context)
        {
            
            var existingOrder = context.Tools.Local.SingleOrDefault(o => o.Id == Parameter.Id);
            if (existingOrder != null)
                context.Entry(existingOrder).State = EntityState.Detached;

            context.Update(this.Parameter);

            await context.SaveChangesAsync();
            return this.Parameter; 
        }
    }
}
