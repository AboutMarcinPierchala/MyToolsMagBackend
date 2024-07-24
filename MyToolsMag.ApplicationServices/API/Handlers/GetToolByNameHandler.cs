using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetToolByNameHandler : IRequestHandler<GetToolByNameRequest, GetToolByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetToolByNameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetToolByNameResponse> Handle(GetToolByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolByNameQuery()
            {
                Id = request.Id
            };

            var tools = await this.queryExecutor.Execute(query);
            if(tools == null) 
            {
                return new GetToolByNameResponse() 
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedTool = this.mapper.Map<Domain.Models.Tool>(tools);
         
            var response = new GetToolByNameResponse()
            {
                Data = mappedTool
            };
            return response;
        }
    }
}
