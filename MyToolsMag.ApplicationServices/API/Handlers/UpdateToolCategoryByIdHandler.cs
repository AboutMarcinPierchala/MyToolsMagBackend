using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS.Commands;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class UpdateToolCategoryByIdHandler : IRequestHandler<UpdateToolCategoryByIdRequest, UpdateToolCategoryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateToolCategoryByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateToolCategoryByIdResponse> Handle(UpdateToolCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolCategoryByIdQuery()
            {
                Id = request.Id
            };
            var getTool = await this.queryExecutor.Execute(query);

            if (getTool == null)
            {
                return new UpdateToolCategoryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }



            var toolCategory = this.mapper.Map<DataAccess.Entities.ToolCategory>(request);
            var command = new UpdateToolCategoryByIdCommand() { Parameter = toolCategory };
            var toolCategoryFromDb = await this.commandExecutor.Execute(command);
            return new UpdateToolCategoryByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.ToolCategory>(toolCategoryFromDb)
            };
        }
    }
}
