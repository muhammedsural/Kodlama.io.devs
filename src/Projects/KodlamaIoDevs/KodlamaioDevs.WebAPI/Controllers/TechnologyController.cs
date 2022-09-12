using Core.Application.Requests;
using KodlamaioDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Queries.GetListTechnology;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        private readonly IMediator _mediator;

        public TechnologyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateTechnologyCommand createTechnologyCommand)
        {
            var result = await _mediator.Send(createTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await _mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            var result = await _mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetTechnologyListQuery getTechnologyListQuery = new GetTechnologyListQuery(){PageRequest = pageRequest};

            var result = await _mediator.Send(getTechnologyListQuery);

            return Ok(result);
        }
    }
}
