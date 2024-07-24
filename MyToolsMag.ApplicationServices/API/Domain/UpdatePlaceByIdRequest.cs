using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class UpdatePlaceByIdRequest : IRequest<UpdatePlaceByIdResponse>
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
    }
}
