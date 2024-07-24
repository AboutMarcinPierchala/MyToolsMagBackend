using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetToolQuery : QueryBase<Tool>
    {
        public string ToolName { get; set; }
        public override async Task<Tool> Execute(WarehouseStorageContext context)
        {
            var tool = await context.Tools.FirstOrDefaultAsync(x => x.ToolName == this.ToolName);
            return tool;
        }
    }
}
