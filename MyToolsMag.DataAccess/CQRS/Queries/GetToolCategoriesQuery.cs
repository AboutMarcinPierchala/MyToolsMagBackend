using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetToolCategoriesQuery : QueryBase<List<ToolCategory>>
    {
        public int Id { get; set; }
        public override Task<List<ToolCategory>> Execute(WarehouseStorageContext context)
        {
            return context.ToolCategories.ToListAsync();

        }
    }
}
