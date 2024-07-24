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
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetPlaceByIdHandler : IRequestHandler<GetPlaceByIdRequest, GetPlaceByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlaceByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetPlaceByIdResponse> Handle(GetPlaceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlaceByIdQuery()
            {
                Id = request.Id
            };

            var places = await this.queryExecutor.Execute(query);

            if (places == null)
            {
                return new GetPlaceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPlace = this.mapper.Map<Domain.Models.Place>(places);

            var response = new GetPlaceByIdResponse()
            {
                Data = mappedPlace
            };
            return response;
        }
    }
}
