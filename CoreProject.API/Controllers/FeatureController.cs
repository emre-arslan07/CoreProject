using CoreProject.API.CQRS.Commands.FeatureCommand;
using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.API.CQRS.Queries.FeatureQuery;
using CoreProject.API.CQRS.Queries.PortfolioQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetFeature")]
        public async Task<IActionResult> GetFeature()
        {
            var values = await _mediator.Send(new GetFeatureByIdQuery(1));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
        {
            var values = await _mediator.Send(updateFeatureCommand);
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
