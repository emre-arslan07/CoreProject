using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.API.CQRS.Commands.TestimonialCommand;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.TestimonialQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllTestimonial")]
        public async Task<ActionResult> GetAllTestimonial()
        {
            var values = await _mediator.Send(new GetAllTestimonialQuery());
            return Ok(values);
        }
        [HttpPost]
        [Route("AddTestimonial")]
        public async Task<IActionResult> AddTestimonial(AddTestimonialCommand addTestimonialCommand)
        {
            var values = await _mediator.Send(addTestimonialCommand);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var values = await _mediator.Send(new DeleteTestimonialCommand(id));
            if (values == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand )
        {
            var values = await _mediator.Send(updateTestimonialCommand);
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
