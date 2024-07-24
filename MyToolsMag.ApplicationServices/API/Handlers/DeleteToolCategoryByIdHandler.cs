using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Commands;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class DeleteToolCategoryByIdHandler : IRequestHandler<DeleteToolCategoryByIdRequest,DeleteToolCategoryByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteToolCategoryByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteToolCategoryByIdResponse> Handle(DeleteToolCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var deletedToolCategory = this.mapper.Map<ToolCategory>(request);
            var command = new DeleteToolCategoryByIdCommand() { Parameter = deletedToolCategory };
            var deletedToolCategoryFromDB = await this.commandExecutor.Execute(command);
            if (deletedToolCategoryFromDB == false)
            {
                return new DeleteToolCategoryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new DeleteToolCategoryByIdResponse()
            {
                //Data = this.mapper.Map<Domain.Models.ToolCategory>(deletedToolCategoryFromDB)
                //Data = deletedToolCategoryFromDB
            };



        }
    }
}
