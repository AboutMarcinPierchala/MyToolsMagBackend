using AutoMapper;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.Mappings
{
    public class ToolsProfile : Profile
    {
        public ToolsProfile()
        {
            this.CreateMap<UpdateToolByIdRequest, DataAccess.Entities.Tool>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.ToolName, y => y.MapFrom(z => z.ToolName))
               .ForMember(x => x.ToolCategoryId, y => y.MapFrom(z => z.ToolCategoryId))
               .ForMember(x => x.PersonId, y => y.MapFrom(z => z.PersonId))
               .ForMember(x => x.PlaceId, y => y.MapFrom(z => z.PlaceId));

            this.CreateMap<PutToolByNameRequest, DataAccess.Entities.Tool>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ToolName, y => y.MapFrom(z => z.ToolName))
                .ForMember(x => x.ToolCategoryId, y => y.MapFrom(z => z.ToolCategoryId))
                .ForMember(x => x.PersonId, y => y.MapFrom(z => z.PersonId))
                .ForMember(x => x.PlaceId, y => y.MapFrom(z => z.PlaceId))
                ;

            this.CreateMap<GetToolByNameRequest, DataAccess.Entities.Tool>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<AddToolRequest, DataAccess.Entities.Tool>()
                .ForMember(x => x.ToolName , y => y.MapFrom(z => z.ToolName))
                .ForMember(x => x.ToolCategoryId, y => y.MapFrom(z => z.ToolCategoryId))
                .ForMember(x => x.PersonId, y => y.MapFrom(z => z.PersonId))
                .ForMember(x => x.PlaceId, y => y.MapFrom(z => z.PlaceId))
                ;

            this.CreateMap<MyToolsMag.DataAccess.Entities.Tool, API.Domain.Models.Tool>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ToolName, y => y.MapFrom(z => z.ToolName))
                .ForMember(x => x.ToolCategoryId, y => y.MapFrom(z => z.ToolCategoryId))
                .ForMember(x => x.PersonId, y => y.MapFrom(z => z.PersonId))
                .ForMember(x => x.PlaceId, y => y.MapFrom(z => z.PlaceId));
                //.ForMember(x => x.ToolCategoryName, y => y.MapFrom(z => z.ToolCategoryName))
                //.ForMember(x => x.PersonName, y => y.MapFrom(z => z.PersonName))
                //.ForMember(x => x.PlaceName, y => y.MapFrom(z => z.PlaceName));
        }
    }
}
