using KodlamaioDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguage.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);

            return Created("", result);

        }
    }
}
