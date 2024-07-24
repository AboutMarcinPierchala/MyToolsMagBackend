using FluentValidation;
using MyToolsMag.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Validators
{
    public class AddToolCategoryRequestValidator : AbstractValidator<AddToolCategoryRequest>
    {
        public AddToolCategoryRequestValidator()
        {
            this.RuleFor(x => x.ToolCategoryName).NotNull();
            this.RuleFor(x => x.ToolCategoryName).Length(5,100);
        }
    }
}
