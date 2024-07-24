using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetPlacesHandler : IRequestHandler<GetPlacesRequest, GetPlacesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Place> placeRepository;
        private readonly IMapper mapper;

        public GetPlacesHandler(IRepository<MyToolsMag.DataAccess.Entities.Place> placeRepository, IMapper mapper)
        {
            this.placeRepository = placeRepository;
            this.mapper = mapper;
        }

        public async Task<GetPlacesResponse> Handle(GetPlacesRequest request, CancellationToken cancellationToken)
        {
            var places = await this.placeRepository.GetAll();
            var mappedPlaces = this.mapper.Map<List<Domain.Models.Place>>(places);
           
            var response = new GetPlacesResponse()
            {
                Data = mappedPlaces
            };
            return response;
        }
    }
}
