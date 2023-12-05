using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.API.CQRS.Commands.ServiceCommand;
using CoreProject.API.CQRS.Queries.AnnouncementQuery;
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
        [HttpGet]
        [Route("GetAllMessage")]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _mediator.Send(new GetAllMessageQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetLast3Message")]
        public async Task<IActionResult> GetLast3Message()
        {
            var values = await _mediator.Send(new GetLast3MessageQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var values = await _mediator.Send(new GetMessageByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var values = await _mediator.Send(new DeleteMessageCommand(id));
            if (values == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
    }
}
