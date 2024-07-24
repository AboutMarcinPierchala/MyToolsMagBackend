using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class AddToolRequest : IRequest<AddToolResponse>
    {
        public string ToolName { get; set; }
        public int ToolCategoryId { get; set; }
        public int PersonId { get; set; }

        public int PlaceId { get; set; }
    }
}
