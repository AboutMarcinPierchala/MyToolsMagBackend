using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class GetToolByNameRequest : IRequest<GetToolByNameResponse>
    {
        public int Id { get; set; }
        //public object Id { get; internal set; }
        //public object ToolCategoryId { get; internal set; }
        //public object PersonId { get; internal set; }
        //public object PlaceId { get; internal set; }
    }
}
