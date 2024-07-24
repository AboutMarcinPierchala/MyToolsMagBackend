using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetMeHandler : IRequestHandler<GetMeRequest, GetMeResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetMeHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetMeResponse> Handle(GetMeRequest request, CancellationToken cancellationToken)
        {
            if (request.Me == "Me" || request.Me == "me")
            {
                var query = new GetAdminQuery()
                {
                    Username = request.Username

                };

                var admin = await this.queryExecutor.Execute(query);
                if (admin == null)
                {
                    return new GetMeResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                var mappedAdmin = this.mapper.Map<Admin>(admin);

                return new GetMeResponse()
                {
                    Data = mappedAdmin
                };
            }
            return new GetMeResponse()
            {
                Error = new ErrorModel(ErrorType.UnsupportedMethod)
            };
        }
    }
}
