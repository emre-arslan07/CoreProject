using CoreProject.API.CQRS.Commands.AboutCommand;
using CoreProject.API.CQRS.Commands.FeatureCommand;
using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Queries.FeatureQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAbout")]
        public async Task<IActionResult> GetAbout()
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(1));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand )
        {
            var values = await _mediator.Send(updateAboutCommand);
            if (values == false)
            {
                return NotFound(values);
            }
            else
            {
                return Ok(values);
            }
        }
    }
}
