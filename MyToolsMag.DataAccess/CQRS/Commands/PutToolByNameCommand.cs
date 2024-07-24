using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class PutToolByNameCommand : CommandBase<Tool, Tool>
    {
        //public string ToolName { get; set; }
        public override async Task<Tool> Execute(WarehouseStorageContext context)
        {
            context.Tools.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
