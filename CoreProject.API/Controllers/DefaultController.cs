using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Queries.ContactQuery;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.FeatureQuery;
using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.API.CQRS.Queries.ServiceQuery;
using CoreProject.API.CQRS.Queries.SkillQuery;
using CoreProject.API.CQRS.Queries.SocialMediaQuery;
using CoreProject.API.CQRS.Queries.TestimonialQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DefaultController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("GetFeature")]
        public async Task<ActionResult> GetFeature()
        {
            var values = await _mediator.Send(new GetAllFeatureQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetAbout")]
        public async Task<ActionResult> GetAbout()
        {
            var values = await _mediator.Send(new GetAllAboutQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetService")]
        public async Task<ActionResult> GetService()
        {
            var values = await _mediator.Send(new GetAllServiceQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetContact")]
        public async Task<ActionResult> GetContact()
        {
            var values = await _mediator.Send(new GetAllContactQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetExperience")]
        public async Task<ActionResult> GetExperience()
        {
            var values = await _mediator.Send(new GetAllExperienceQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetSkill")]
        public async Task<ActionResult> GetSkill()
        {
            var values = await _mediator.Send(new GetAllSkillQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetSocialMedia")]
        public async Task<ActionResult> GetSocialMedia()
        {
            var values = await _mediator.Send(new GetAllSocialMediaQuery());
            return Ok(values);
        }


        [HttpGet]
        [Route("GetTestimonial")]
        public async Task<ActionResult> GetTestimonial()
        {
            var values = await _mediator.Send(new GetAllTestimonialQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("GetPortfolio")]
        public async Task<ActionResult> GetPortfolio()
        {
            var values = await _mediator.Send(new GetAllPortfolioQuery());
            return Ok(values);
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<ActionResult> SendMessage(SendMessageCommand sendMessageCommand)
        {
            var values = await _mediator.Send(sendMessageCommand);
            return Ok(values);
        }
    }
}
