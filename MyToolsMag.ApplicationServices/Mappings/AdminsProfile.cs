using AutoMapper;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.Mappings
{
    public class AdminsProfile : Profile
    {
        public AdminsProfile() 
        {
            this.CreateMap<ValidateAdminRequest, DataAccess.Entities.Admin>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

            this.CreateMap<CreateAdminRequest, DataAccess.Entities.Admin>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

            this.CreateMap<MyToolsMag.DataAccess.Entities.Admin, Admin>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username));
                //.ForMember(x => x.Password, y => y.MapFrom(z => z.Password));
        }
    }
}
