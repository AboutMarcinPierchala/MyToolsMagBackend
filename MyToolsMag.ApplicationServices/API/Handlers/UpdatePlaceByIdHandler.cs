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
    public class UpdatePlaceByIdHandler : IRequestHandler<UpdatePlaceByIdRequest, UpdatePlaceByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdatePlaceByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdatePlaceByIdResponse> Handle(UpdatePlaceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlaceByIdQuery()
            {
                Id = request.Id
            };
            var getPlace = await this.queryExecutor.Execute(query);

            if (getPlace == null)
            {
                return new UpdatePlaceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }



            var place = this.mapper.Map<DataAccess.Entities.Place>(request);
            var command = new UpdatePlaceByIdCommand() { Parameter = place };
            var placeFromDb = await this.commandExecutor.Execute(command);
            return new UpdatePlaceByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Place>(placeFromDb)
            };
        }
    }
}

