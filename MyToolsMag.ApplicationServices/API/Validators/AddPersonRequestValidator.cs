using FluentValidation;
using MyToolsMag.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Validators
{
    public class AddPersonRequestValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonRequestValidator()
        {
            this.RuleFor(x => x.PersonName).NotNull();
            this.RuleFor(x => x.PersonName).Length(5, 100);
        }
    }
}
