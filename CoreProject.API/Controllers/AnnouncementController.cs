using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnnouncementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAnnouncement")]
        public async Task<IActionResult> GetAnnouncement()
        {
            var values = await _mediator.Send(new GetAllAnnouncementQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(int id)
        {
            var values = await _mediator.Send(new GetAnnoucementByIdQuery(id));
            return Ok(values);
        }

        [HttpGet]
        [Route("GetAnnouncementCount")]
        public async Task<IActionResult> GetAnnouncementCount()
        {
            var values = await _mediator.Send(new GetAnnouncementTotalCountQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetLast5Announcement")]
        public async Task<IActionResult> GetLast5Announcement()
        {
            var values = await _mediator.Send(new GetLast5AnnoucementQuery());
            return Ok(values);
        }
    }
}
