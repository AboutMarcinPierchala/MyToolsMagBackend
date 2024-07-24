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
    public class DeletePersonByIdHandler : IRequestHandler<DeletePersonByIdRequest, DeletePersonByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeletePersonByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeletePersonByIdResponse> Handle(DeletePersonByIdRequest request, CancellationToken cancellationToken)
        {
            var deletedPerson = this.mapper.Map<Person>(request);
            var command = new DeletePersonByIdCommand() { Parameter = deletedPerson };
            
            var deletedPersonFromDB = await this.commandExecutor.Execute(command);
            if(deletedPersonFromDB == false)
            {
                return new DeletePersonByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new DeletePersonByIdResponse()
            {
                //Data = this.mapper.Map<Domain.Models.Person>(deletedPersonFromDB)
                //Data = deletedToolCategoryFromDB
            };
        }
    }
}
