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
    public class DeletePlaceByIdHandler : IRequestHandler<DeletePlaceByIdRequest, DeletePlaceByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeletePlaceByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeletePlaceByIdResponse> Handle(DeletePlaceByIdRequest request, CancellationToken cancellationToken)
        {
            var deletedPlace = this.mapper.Map<Place>(request);
            var command = new DeletePlaceByIdCommand() { Parameter = deletedPlace };
            var deletedPlaceFromDB = await this.commandExecutor.Execute(command);
            if (deletedPlaceFromDB == false)
            {
                return new DeletePlaceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new DeletePlaceByIdResponse()
            {
                //Data = this.mapper.Map<Domain.Models.Place>(deletedPlaceFromDB)
                //Data = deletedToolCategoryFromDB
            };
        }
    }
}
