﻿using KodlamaioDevs.Application.Features.Developers.Commands.CreateDeveloper;
using KodlamaioDevs.Application.Features.Developers.Commands.LoginDeveloper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateDeveloperCommand createDeveloperCommand)
        {
            var result = await _mediator.Send(createDeveloperCommand);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDeveloperCommand loginDeveloperCommand)
        {
            var result = await _mediator.Send(loginDeveloperCommand);

            return Ok(result);
        }
    }
}