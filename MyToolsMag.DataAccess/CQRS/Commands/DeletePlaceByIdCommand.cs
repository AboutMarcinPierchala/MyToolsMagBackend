using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class DeletePlaceByIdCommand : CommandBase<Place, bool>
    {
        public override async Task<bool> Execute(WarehouseStorageContext context)
        {
            try
            {
                context.Places.Remove(this.Parameter);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
