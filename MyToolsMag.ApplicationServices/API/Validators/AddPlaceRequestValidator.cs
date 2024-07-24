using FluentValidation;
using MyToolsMag.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Validators
{
    public class AddPlaceRequestValidator : AbstractValidator<AddPlaceRequest>
    {
        public AddPlaceRequestValidator()
        {
            this.RuleFor(x => x.PlaceName).NotNull();
            this.RuleFor(x => x.PlaceName).Length(5, 100);
        }
    }
}
