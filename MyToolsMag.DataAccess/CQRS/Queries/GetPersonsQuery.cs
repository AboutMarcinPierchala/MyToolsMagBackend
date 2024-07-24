using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetPersonsQuery : QueryBase<List<Person>>
    {
        public int Id { get; set; }
        public override Task<List<Person>> Execute(WarehouseStorageContext context)
        {
            return context.Persons.ToListAsync();

        }
    }
}
