﻿using Microsoft.EntityFrameworkCore;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS.Queries
{
    public class GetPersonByNameQuery : QueryBase<Person>
    {
        public int Id { get; set; }

        public override async Task<Person> Execute(WarehouseStorageContext context)
        {
            return await context.Persons.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
