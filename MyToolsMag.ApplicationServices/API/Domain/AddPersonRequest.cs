using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class AddPersonRequest : IRequest<AddPersonResponse>
    {
        public string PersonName { get; set; }
    }
}
