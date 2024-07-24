using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetToolCategoryByIdQuery : QueryBase<ToolCategory>
    {
        public int Id { get; set; }
        public override async Task<ToolCategory> Execute(WarehouseStorageContext context)
        {
            return await context.ToolCategories.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
