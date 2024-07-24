using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class UpdateToolByIdRequest : IRequest<UpdateToolByIdResponse>
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public int ToolCategoryId { get; set; }
        public int PersonId { get; set; }

        public int PlaceId { get; set; }
        //public string ToolCategoryName { get; set; }

        //public string PersonName { get; set; }

        //public string PlaceName { get; set; }
    }
}
