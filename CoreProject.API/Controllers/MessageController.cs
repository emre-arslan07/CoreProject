using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.MessageQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetMessageCount")]
        public async Task<IActionResult> GetMessageCount()
        {
            var values = await _mediator.Send(new GetMessageTotalCountQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetTrueMessageCount")]
        public async Task<IActionResult> GetTrueMessageCount()
        {
            var values = await _mediator.Send(new GetTrueMessageTotalQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetFalseMessageCount")]
        public async Task<IActionResult> GetFalseMessageCount()
        {
            var values = await _mediator.Send(new GetFalseMessageTotalQuery());
            return Ok(values);
        }
    }
}
