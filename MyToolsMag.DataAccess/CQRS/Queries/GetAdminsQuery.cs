using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetAdminsQuery : QueryBase<List<Admin>>
    {
        public int Id { get; set; }
        public async override Task<List<Admin>> Execute(WarehouseStorageContext context)
        {
            return await context.Admins.ToListAsync();
        }
    }
}
