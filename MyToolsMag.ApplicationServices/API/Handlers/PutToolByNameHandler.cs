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
    public class PutToolByNameHandler : IRequestHandler<PutToolByNameRequest, PutToolByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutToolByNameHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutToolByNameResponse> Handle(PutToolByNameRequest request, CancellationToken cancellationToken)
        {
            var tool = this.mapper.Map<DataAccess.Entities.Tool>(request);
            var command = new PutToolByNameCommand() { Parameter = tool };
            var toolFromDb = await this.commandExecutor.Execute(command);
            return new PutToolByNameResponse()
            {
                Data = this.mapper.Map<Domain.Models.Tool>(toolFromDb)
            };
        }
    }
}
