using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetAdminHandler : IRequestHandler<GetAdminRequest, GetAdminResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAdminHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAdminResponse> Handle(GetAdminRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAdminQuery();

            var admin = await this.queryExecutor.Execute(query);
            var mappedAdmin = this.mapper.Map<List<Domain.Models.Admin>>(admin);

            var response = new GetAdminResponse()
            {
                Data = mappedAdmin
            };
            return response;
        }
    }
}
