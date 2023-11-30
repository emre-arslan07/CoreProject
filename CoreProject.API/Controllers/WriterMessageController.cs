using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.API.CQRS.Commands.WriterMessageCommand;
using CoreProject.API.CQRS.Queries.AnnouncementQuery;
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
    public class WriterMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WriterMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetMessageInbox/{mail}")]

        public async Task<IActionResult> GetMessageInbox(string mail)
        {
            var values = await _mediator.Send(new WriterMessageInboxQuery(mail));
            return Ok(values);
        }
        [HttpGet("GetMessageSendbox/{mail}")]
        public async Task<IActionResult> GetMessageSendbox(string mail)
        {
            var values = await _mediator.Send(new WriterMessageSendboxQuery(mail));
            return Ok(values);
        }
        [HttpGet("GetWriterMessageById/{id}")]
        public async Task<IActionResult> GetWriterMessageById(int id)
        {
            var values = await _mediator.Send(new GetWriterMessageByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        [Route("SendWriterMessage")]
        public async Task<IActionResult> SendWriterMessage(SendWriterMessageCommand sendWriterMessageCommand)
        {
            var values = await _mediator.Send(sendWriterMessageCommand);
            return Ok(values);
        }
        [HttpGet("GetWriterMessageInboxCount/{mail}")]
        public async Task<IActionResult> GetWriterMessageInboxCount(string mail)
        {
            var values = await _mediator.Send(new GetWriterMessageInboxCountQuery(mail));
            return Ok(values);
        }
    }
}
