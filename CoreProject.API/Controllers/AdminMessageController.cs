using CoreProject.API.CQRS.Commands.AdminMessage;
using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.API.CQRS.Commands.WriterMessageCommand;
using CoreProject.API.CQRS.Queries.AdminMessageQuery;
using CoreProject.API.CQRS.Queries.WriterMessage;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetLast3MessageInbox/{mail}")]

        public async Task<IActionResult> GetLast3MessageInbox(string mail)
        {
            var values = await _mediator.Send(new GetLast3MessageInboxQuery(mail));
            return Ok(values);
        }

        [HttpGet("GetAdminMessageInbox/{mail}")]

        public async Task<IActionResult> GetAdminMessageInbox(string mail)
        {
            var values = await _mediator.Send(new GetAdminMessageInboxQuery(mail));
            return Ok(values);
        }
        [HttpGet("GetAdminMessageSendbox/{mail}")]
        public async Task<IActionResult> GetAdminMessageSendbox(string mail)
        {
            var values = await _mediator.Send(new GetAdminMessageSendboxQuery(mail));
            return Ok(values);
        }
        [HttpGet("GetAdminMessageById/{id}")]
        public async Task<IActionResult> GetAdminMessageById(int id)
        {
            var values = await _mediator.Send(new GetAdminMessageByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        [Route("SendAdminMessage")]
        public async Task<IActionResult> SendAdminMessage(SendAdminMessageCommand sendAdminMessageCommand)
        {
            var values = await _mediator.Send(sendAdminMessageCommand);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminMessage(int id)
        {
            var values = await _mediator.Send(new DeleteAdminMessageCommand(id));
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
