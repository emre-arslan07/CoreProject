using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.API.CQRS.Commands.SkillCommand;
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
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetSkill")]
        public async Task<IActionResult> GetSkill()
        {
            var values = await _mediator.Send(new GetAllSkillQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetSkillCount")]
        public async Task<IActionResult> GetSkillCount()
        {
            var values = await _mediator.Send(new GetSkillTotalCountQuery());
            return Ok(values);
        }

        [HttpPost]
        [Route("AddSkill")]
        public async Task<IActionResult> AddSkill(AddSkillCommand addSkillCommand)
        {
            var values = await _mediator.Send(addSkillCommand);
            return Ok(values);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var values = await _mediator.Send(new DeleteSkillCommand(id));
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
        public async Task<IActionResult> GetSkillById(int id)
        {
            var values = await _mediator.Send(new GetSkillByIdQuery(id));
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
        public async Task<IActionResult> UpdateSkill(UpdateSkillCommand updateSkillCommand)
        {
            var values = await _mediator.Send(updateSkillCommand);
            if (values==false)
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
