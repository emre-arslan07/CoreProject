using CoreProject.API.CQRS.Commands.AboutCommand;
using CoreProject.API.CQRS.Commands.ContactCommand;
using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Queries.ContactQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetContactById")]
        public async Task<IActionResult> GetContactById()
        {
            var values = await _mediator.Send(new GetContactByIdQuery(1));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            var values = await _mediator.Send(updateContactCommand);
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
