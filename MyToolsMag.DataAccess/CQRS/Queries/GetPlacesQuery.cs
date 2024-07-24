using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetPlacesQuery : QueryBase<List<Place>>
    {
        public int Id { get; set; }
        public override Task<List<Place>> Execute(WarehouseStorageContext context)
        {
            return context.Places.ToListAsync();
        }
    }
}
