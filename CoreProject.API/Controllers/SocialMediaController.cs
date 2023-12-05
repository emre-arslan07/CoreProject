using CoreProject.API.CQRS.Commands.SkillCommand;
using CoreProject.API.CQRS.Commands.SocialMediaCommand;
using CoreProject.API.CQRS.Queries.SkillQuery;
using CoreProject.API.CQRS.Queries.SocialMediaQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllSocialMedia")]
        public async Task<IActionResult> GetAllSocialMedia()
        {
            var values = await _mediator.Send(new GetAllSocialMediaQuery());
            return Ok(values);
        }

        [HttpPost]
        [Route("AddSocialMedia")]
        public async Task<IActionResult> AddSocialMedia(AddSocialMediaCommand addSocialMediaCommand)
        {
            var values = await _mediator.Send(addSocialMediaCommand);
            return Ok(values);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var values = await _mediator.Send(new DeleteSocialMediaCommand(id));
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
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var values = await _mediator.Send(new GetSocialMediaByIDQuery(id));
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
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            var values = await _mediator.Send(updateSocialMediaCommand);
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
