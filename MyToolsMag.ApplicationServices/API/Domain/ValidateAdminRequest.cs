using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class ValidateAdminRequest : IRequest<ValidateAdminResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
