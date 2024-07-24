using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS.Commands;
using MyToolsMag.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolsMag.ApplicationServices.Components.PasswordHasher;
using MyToolsMag.DataAccess.Entities;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class ValidateAdminHandler : IRequestHandler<ValidateAdminRequest, ValidateAdminResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher passwordHasher;
        private readonly IQueryExecutor queryExecutor;

        public ValidateAdminHandler(ICommandExecutor commandExecutor, IMapper mapper, IPasswordHasher passwordHasher, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.queryExecutor = queryExecutor;
        }

        public async Task<ValidateAdminResponse> Handle(ValidateAdminRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAdminQuery()
            {
                //FirstName = request.FirstName,
                //LastName = request.LastName,
                Username = request.Username
            };

            var user = await this.queryExecutor.Execute(query);
            if (user == null)
            {
                return new ValidateAdminResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };

            }

            return new ValidateAdminResponse()
            {
                Data = this.mapper.Map<Domain.Models.Admin>(user)
            };

            //var auth = passwordHasher.Hash(request.Password);
            //request.Password = auth[0];
            ////request.Salt = auth[1];


            //var mappedAdmin = this.mapper.Map<Admin>(request);
            //var command = new CreateAdminCommand()
            //{
            //    Parameter = mappedAdmin
            //};
            //var createdAdmin = await this.commandExecutor.Execute(command);

            //return new ValidateAdminResponse()
            //{
            //    Data = this.mapper.Map<Domain.Models.Admin>(createdAdmin)
            //};

            //var admin = this.mapper.Map<DataAccess.Entities.Admin>(request);

            //    var command = new CreateAdminCommand() { Parameter = admin };
            //    var adminFromDb = await this.commandExecutor.Execute(command);
            //    return new CreateAdminResponse()
            //    {
            //        Data = this.mapper.Map<Domain.Models.Admin>(adminFromDb)
            //    };
        }
    }
}