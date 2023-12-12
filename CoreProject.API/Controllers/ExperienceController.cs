using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.API.CQRS.Commands.SkillCommand;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.SkillQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExperienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetExperience")]
        public async Task<IActionResult> GetExperience()
        {
            var values = await _mediator.Send(new GetAllExperienceQuery());
            return Ok(values.ToList());
        }

        [HttpGet]
        [Route("GetExperienceCount")]
        public async Task<IActionResult> GetExperienceCount()
        {
            var values = await _mediator.Send(new GetExperienceTotalCountQuery());
            return Ok(values);
        }

        [HttpPost]
        [Route("AddExperience")]
        public async Task<IActionResult> AddExperience(AddExperienceCommand addExperienceCommand)
        {
            var values = await _mediator.Send(addExperienceCommand);
            if (values == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var values = await _mediator.Send(new DeleteExperienceCommand(id));
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
        public async Task<IActionResult> GetExperienceById(int id)
        {
            var values = await _mediator.Send(new GetExperienceByIdQuery(id));
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
        public async Task<IActionResult> UpdateExperience(UpdateExperienceCommand updateExperienceCommand)
        {
            var values = await _mediator.Send(updateExperienceCommand);
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
