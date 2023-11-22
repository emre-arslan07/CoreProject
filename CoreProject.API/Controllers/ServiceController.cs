using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.API.CQRS.Commands.ServiceCommand;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.API.CQRS.Queries.ServiceQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetService")]
        public async Task<IActionResult> GetService()
        {
            var values = await _mediator.Send(new GetAllServiceQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetServiceCount")]
        public async Task<IActionResult> GetServiceCount()
        {
            var values = await _mediator.Send(new GetServiceTotalCountQuery());
            return Ok(values);
        }
        [HttpPost]
        [Route("AddService")]
        public async Task<IActionResult> AddService(AddServiceCommand addServiceCommand )
        {
            var values = await _mediator.Send(addServiceCommand);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var values = await _mediator.Send(new DeleteServiceCommand(id));
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
            var values = await _mediator.Send(new GetServiceByIdQuery(id));
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
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand )
        {
            var values = await _mediator.Send(updateServiceCommand);
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
