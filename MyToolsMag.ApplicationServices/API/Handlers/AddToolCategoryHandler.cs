using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
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
    public class AddToolCategoryHandler : IRequestHandler<AddToolCategoryRequest, AddToolCategoryResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddToolCategoryHandler(ICommandExecutor commandExecutor, IMapper mapper) 
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddToolCategoryResponse> Handle(AddToolCategoryRequest request, CancellationToken cancellationToken)
        {
            var toolCategory = this.mapper.Map<DataAccess.Entities.ToolCategory>(request);
            var command = new AddToolCategoryCommand() { Parameter = toolCategory };
            var toolCategoryFromDb = await this.commandExecutor.Execute(command);
            return new AddToolCategoryResponse()
            {
                Data = this.mapper.Map<Domain.Models.ToolCategory>(toolCategoryFromDb)
            };
        }
    }
}
