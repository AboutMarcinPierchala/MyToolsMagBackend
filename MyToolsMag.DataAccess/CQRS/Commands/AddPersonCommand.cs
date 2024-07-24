using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Commands
{
    public class AddPersonCommand : CommandBase<Person, Person>
    {
        public override async Task<Person> Execute(WarehouseStorageContext context)
        {
            await context.Persons.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
