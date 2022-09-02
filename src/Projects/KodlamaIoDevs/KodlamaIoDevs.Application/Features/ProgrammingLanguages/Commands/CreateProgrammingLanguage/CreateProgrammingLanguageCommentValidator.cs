using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    internal class CreateProgrammingLanguageCommentValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommentValidator()
        {
            RuleFor(e => e.Name).NotEmpty(); //Programlama dilinin ismi boş geçilemez.
        }
    }
}
