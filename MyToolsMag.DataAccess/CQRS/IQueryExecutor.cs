using Microsoft.AspNetCore.Http;
using MyToolsMag.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
