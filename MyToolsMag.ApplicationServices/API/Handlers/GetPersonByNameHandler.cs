using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetPersonByNameHandler : IRequestHandler<GetPersonByNameRequest, GetPersonByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPersonByNameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetPersonByNameResponse> Handle(GetPersonByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPersonByNameQuery()
            {
                Id = request.Id
            };

            var persons = await this.queryExecutor.Execute(query);

            if (persons == null)
            {
                return new GetPersonByNameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPerson = this.mapper.Map<Domain.Models.Person>(persons);
            
            var response = new GetPersonByNameResponse()
            {
                Data = mappedPerson
            };
            return response;
        }
    }
}
