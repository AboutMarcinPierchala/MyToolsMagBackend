using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class UpdatePersonByIdCommand : CommandBase<Person, Person>
    {
        //public int Id { get; set; }
        public override async Task<Person> Execute(WarehouseStorageContext context)
        {

            var existingOrder = context.Persons.Local.SingleOrDefault(o => o.Id == Parameter.Id);
            if (existingOrder != null)
                context.Entry(existingOrder).State = EntityState.Detached;

            context.Update(this.Parameter);

            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
