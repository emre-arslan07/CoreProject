using CoreProject.API.CQRS.Commands.AppUserCommand;
using CoreProject.API.CQRS.Commands.ExperienceCommand;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("AppUserRegister")]
        public async Task<IActionResult> AppUserRegister(AppUserRegisterCommand appUserRegisterCommand )
        {
            var values = await _mediator.Send(appUserRegisterCommand);
            return Ok(values);
        }
    }
}
