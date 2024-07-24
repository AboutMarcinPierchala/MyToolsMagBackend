using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetToolsQuery : QueryBase<List<Tool>>
    {
        public int Id { get; set; }
        public override Task<List<Tool>> Execute(WarehouseStorageContext context)
        {
            return context.Tools.ToListAsync();
        }
    }
}
