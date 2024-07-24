using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class GetToolCategoryByIdRequest : IRequest<GetToolCategoryByIdResponse>
    {
        public int Id { get; set; }
        public string ToolCategoryName { get; set; }
    }
}
