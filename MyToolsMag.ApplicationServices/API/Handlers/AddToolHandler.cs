using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class AddToolHandler : IRequestHandler<AddToolRequest, AddToolResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddToolHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddToolResponse> Handle(AddToolRequest request, CancellationToken cancellationToken)
        {
            var tool = this.mapper.Map<DataAccess.Entities.Tool>(request);
            var command = new AddToolCommand() { Parameter = tool };
            var toolFromDb = await this.commandExecutor.Execute(command);
            return new AddToolResponse()
            {
                Data = this.mapper.Map<Domain.Models.Tool>(toolFromDb)
            };
        }
    }
}
