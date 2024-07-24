using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetToolsHandler : IRequestHandler<GetToolsRequest, GetToolsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetToolsHandler(IMapper mapper, IQueryExecutor queryExecutor) 
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetToolsResponse> Handle(GetToolsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolsQuery();
            
            var tools = await this.queryExecutor.Execute(query);
            var mappedTools = this.mapper.Map<List<Domain.Models.Tool>>(tools);
            #region //old method without autoMapper
            //var domainTools = tools.Select(x => new Domain.Models.Tool()
            //{
            //    Id = x.Id,
            //    ToolName = x.ToolName
            //});
            //var domainTools = new List<Domain.Models.Tool>();
            //foreach (var tool in tools)
            //{
            //    domainTools.Add(new Domain.Models.Tool()
            //    {
            //        Id = tool.Id,
            //        ToolName = tool.ToolName
            //    });
            //}
            #endregion
            var response = new GetToolsResponse()
            {
                Data = mappedTools
            };
            return response;
        }
    }
}
