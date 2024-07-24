using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetToolCategoryByIdHandler : IRequestHandler<GetToolCategoryByIdRequest, GetToolCategoryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetToolCategoryByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetToolCategoryByIdResponse> Handle(GetToolCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolCategoryByIdQuery()
            {
                Id = request.Id
            };

            var toolCategories = await this.queryExecutor.Execute(query);

            if (toolCategories == null)
            {
                return new GetToolCategoryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedToolCategory = this.mapper.Map<Domain.Models.ToolCategory>(toolCategories);

            var response = new GetToolCategoryByIdResponse()
            {
                Data = mappedToolCategory
            };
            return response;
        }
    }
}
