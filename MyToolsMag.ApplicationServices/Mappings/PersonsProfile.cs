using AutoMapper;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using MyToolsMag.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.Mappings
{
    public class PersonsProfile : Profile
    {
        public PersonsProfile()
        {
            this.CreateMap<UpdatePersonByIdRequest, DataAccess.Entities.Person>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.PersonName, y => y.MapFrom(z => z.PersonName));

            this.CreateMap<DeletePersonByIdRequest, DataAccess.Entities.Person>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.PersonName, y => y.MapFrom(z => z.PersonName));

            this.CreateMap<GetPersonByNameRequest, DataAccess.Entities.Person>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<AddPersonRequest, DataAccess.Entities.Person>()
                .ForMember(x => x.PersonName, y => y.MapFrom(z => z.PersonName));

            this.CreateMap<MyToolsMag.DataAccess.Entities.Person, Person>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PersonName, y => y.MapFrom(z => z.PersonName));
        }
    }
}
