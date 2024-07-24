using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetPlaceQuery : QueryBase<Place>
    {
        public int Id { get; set; }
        public override async Task<Place> Execute(WarehouseStorageContext context)
        {
            var place = await context.Places.FirstOrDefaultAsync(x => x.Id == this.Id);
            return place;
        }
    }
}
