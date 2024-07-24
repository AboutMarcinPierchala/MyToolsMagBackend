using MyToolsMag.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly WarehouseStorageContext context;

        public QueryExecutor(WarehouseStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(context);
        }
    }
}
