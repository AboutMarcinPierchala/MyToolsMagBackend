using FluentValidation;
using MyToolsMag.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Validators
{
    public class PutToolByNameRequestValidator : AbstractValidator<PutToolByNameRequest>
    {
        public PutToolByNameRequestValidator()
        {
            this.RuleFor(x => x.ToolName).NotNull();
            this.RuleFor(x => x.ToolName).Length(5, 100);
            this.RuleFor(x => x.ToolCategoryId).NotNull();
            this.RuleFor(x => x.ToolCategoryId).NotEqual(0);
            this.RuleFor(x => x.PlaceId).NotNull();
            this.RuleFor(x => x.PlaceId).NotEqual(0);
            this.RuleFor(x => x.PersonId).NotNull();
            this.RuleFor(x => x.PersonId).NotEqual(0);
        }
    }
}
