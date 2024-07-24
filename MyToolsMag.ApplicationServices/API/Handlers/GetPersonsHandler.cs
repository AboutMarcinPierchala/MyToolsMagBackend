using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.Entities;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetPersonsHandler : IRequestHandler<GetPersonsRequest, GetPersonsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Person> personRepository;
        private readonly IMapper mapper;

        public GetPersonsHandler(IRepository<MyToolsMag.DataAccess.Entities.Person> personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<GetPersonsResponse> Handle(GetPersonsRequest request, CancellationToken cancellationToken)
        {
            var persons = await this.personRepository.GetAll();
            var mappedPersons = this.mapper.Map<List<Domain.Models.Person>>(persons);
            var response = new GetPersonsResponse()
            {
                Data = mappedPersons
            };
            return response;
        }
    }
}
