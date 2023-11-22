using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.API.CQRS.Results.PortfolioResult;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetPortfolio")]
        public async Task<IActionResult> GetPortfolio()
        {
            var values = await _mediator.Send(new GetAllPortfolioQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetPortfolioCount")]
        public async Task<IActionResult> GetPortfolioCount()
        {
            var values = await _mediator.Send(new GetPortfolioTotalCountQuery());
            return Ok(values);
        }
        [HttpGet]
        [Route("GetLast5Portfolio")]
        public async Task<IActionResult> GetLast5Portfolio()
        {
            var values = await _mediator.Send(new GetLas5PortfolioQuery());
            return Ok(values);
        }

        [HttpPost]
        [Route("AddPortfolio")]
        public async Task<IActionResult> AddPortfolio(AddPortfolioCommand addPortfolioCommand )
        {
            var values = await _mediator.Send(addPortfolioCommand);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var values = await _mediator.Send(new DeletePortfolioCommand(id));
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
        public async Task<IActionResult> GetPortfolioById(int id)
        {
            var values = await _mediator.Send(new GetPortfolioByIdQuery(id));
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
        public async Task<IActionResult> UpdatePortfolio(UpdatePortfolioCommand updatePortfolioCommand)
        {
            var values = await _mediator.Send(updatePortfolioCommand);
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
