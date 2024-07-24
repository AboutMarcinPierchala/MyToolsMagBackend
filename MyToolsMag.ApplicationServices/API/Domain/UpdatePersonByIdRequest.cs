﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain
{
    public class UpdatePersonByIdRequest : IRequest<UpdatePersonByIdResponse>
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
    }
}
