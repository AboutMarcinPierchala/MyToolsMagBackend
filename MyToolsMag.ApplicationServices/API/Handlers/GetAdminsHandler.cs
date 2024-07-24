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
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.Entities;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetAdminsHandler : IRequestHandler<GetAdminsRequest, GetAdminsResponse>
    {
        //private readonly IRepository<DataAccess.Entities.Admin> adminRepository;
        //private readonly IMapper mapper;

        //public GetAdminsHandler(IRepository<MyToolsMag.DataAccess.Entities.Admin> adminRepository, IMapper mapper)
        //{
        //    this.adminRepository = adminRepository;
        //    this.mapper = mapper;
        //}

        //public async Task<GetAdminsResponse> Handle(GetAdminsRequest request, CancellationToken cancellationToken)
        //{
        //    var admins = await this.adminRepository.GetAll();
        //    var mappedAdmins = this.mapper.Map<List<Domain.Models.Admin>>(admins);
        //    var response = new GetAdminsResponse()
        //    {
        //        Data = mappedAdmins
        //    };
        //    return response;
        //}
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAdminsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAdminsResponse> Handle(GetAdminsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAdminsQuery();

            var admins = await this.queryExecutor.Execute(query);
            var mappedAdmins = this.mapper.Map<List<Domain.Models.Admin>>(admins);

            var response = new GetAdminsResponse()
            {
                Data = mappedAdmins
            };
            return response;
        }
    }
}
