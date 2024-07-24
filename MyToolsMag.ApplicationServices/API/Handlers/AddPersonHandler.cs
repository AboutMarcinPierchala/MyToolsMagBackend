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
    public class AddPersonHandler : IRequestHandler<AddPersonRequest, AddPersonResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddPersonHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddPersonResponse> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var person = this.mapper.Map<DataAccess.Entities.Person>(request);
            var command = new AddPersonCommand() { Parameter = person };
            var personFromDb = await this.commandExecutor.Execute(command);
            return new AddPersonResponse()
            {
                Data = this.mapper.Map<Domain.Models.Person>(personFromDb)
            };
        }
    }
}
