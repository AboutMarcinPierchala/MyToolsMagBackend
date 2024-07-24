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
    public class ToolCategoriesProfile : Profile
    {
        public ToolCategoriesProfile()
        {
            this.CreateMap<UpdateToolCategoryByIdRequest, DataAccess.Entities.ToolCategory>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.ToolCategoryName));

            this.CreateMap<DeleteToolCategoryByIdRequest, DataAccess.Entities.ToolCategory>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
               //.ForMember(x => x.CategoryName, y => y.MapFrom(z => z.ToolCategoryName));

            this.CreateMap<AddToolCategoryRequest, DataAccess.Entities.ToolCategory>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z =>  z.ToolCategoryName));

            this.CreateMap<MyToolsMag.DataAccess.Entities.ToolCategory, ToolCategory>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ToolCategoryName, y => y.MapFrom(z => z.CategoryName));
        }
    }
}
