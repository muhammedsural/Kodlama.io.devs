using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator: AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.Name).NotNull().NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotNull();
        }
    }
}
