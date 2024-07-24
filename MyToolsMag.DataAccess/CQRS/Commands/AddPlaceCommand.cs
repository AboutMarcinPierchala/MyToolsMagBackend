using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class AddPlaceCommand : CommandBase<Place, Place>
    {
        public override async Task<Place> Execute(WarehouseStorageContext context)
        {
            await context.Places.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
