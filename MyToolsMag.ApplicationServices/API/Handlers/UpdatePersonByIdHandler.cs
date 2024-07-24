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
    public class UpdatePersonByIdHandler : IRequestHandler<UpdatePersonByIdRequest, UpdatePersonByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdatePersonByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdatePersonByIdResponse> Handle(UpdatePersonByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPersonByNameQuery()
            {
                Id = request.Id
            };
            var getPerson = await this.queryExecutor.Execute(query);

            if (getPerson == null)
            {
                return new UpdatePersonByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }



            var person = this.mapper.Map<DataAccess.Entities.Person>(request);
            var command = new UpdatePersonByIdCommand() { Parameter = person };
            var personFromDb = await this.commandExecutor.Execute(command);
            return new UpdatePersonByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Person>(personFromDb)
            };
        }
    }
}
