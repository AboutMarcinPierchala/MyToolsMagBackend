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
    public class AddPlaceHandler : IRequestHandler<AddPlaceRequest, AddPlaceResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddPlaceHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddPlaceResponse> Handle(AddPlaceRequest request, CancellationToken cancellationToken)
        {
            var place = this.mapper.Map<DataAccess.Entities.Place>(request);
            var command = new AddPlaceCommand() { Parameter = place };
            var placeFromDb = await this.commandExecutor.Execute(command);
            return new AddPlaceResponse()
            {
                Data = this.mapper.Map<Domain.Models.Place>(placeFromDb)
            };
        }
    }
}
