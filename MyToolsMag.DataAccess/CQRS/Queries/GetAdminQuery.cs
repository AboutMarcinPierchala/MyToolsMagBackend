using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetAdminQuery : QueryBase<Admin>
    {
        public string Username { get; set; }
        public override Task<Admin> Execute(WarehouseStorageContext context)
        {
            return context.Admins.FirstOrDefaultAsync(x => x.Username == this.Username);
        }
    }
}
