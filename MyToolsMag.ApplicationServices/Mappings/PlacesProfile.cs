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
    public class PlacesProfile : Profile
    {
        public PlacesProfile()
        {
            this.CreateMap<UpdatePlaceByIdRequest, DataAccess.Entities.Place>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.PlaceName, y => y.MapFrom(z => z.PlaceName));
            this.CreateMap<DeletePlaceByIdRequest, DataAccess.Entities.Place>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.PlaceName, y => y.MapFrom(z => z.PlaceName));

            this.CreateMap<AddPlaceRequest, DataAccess.Entities.Place>()
                .ForMember(x => x.PlaceName, y => y.MapFrom(z => z.PlaceName));

            this.CreateMap<MyToolsMag.DataAccess.Entities.Place, Place>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PlaceName, y => y.MapFrom(z => z.PlaceName));
        }
    }
}
