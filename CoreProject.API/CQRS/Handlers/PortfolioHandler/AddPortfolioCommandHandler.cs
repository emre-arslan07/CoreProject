using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class AddPortfolioCommandHandler : IRequestHandler<AddPortfolioCommand>
    {
        private readonly IPortfolioService _portfolioService;

        public AddPortfolioCommandHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<Unit> Handle(AddPortfolioCommand request, CancellationToken cancellationToken)
        {
            await _portfolioService.AddAsync(new Portfolio
            {
                Image1 = request.Image1,
                Image2 = request.Image2,
                Image3 = request.Image3,
                Image4 = request.Image4,
                ImageUrl = request.ImageUrl,
                ImageUrl2 = request.ImageUrl2,
                Name = request.Name,
                Platform = request.Platform,
                Price = request.Price,
                ProjectUrl = request.ProjectUrl,
                Status = true,
                Value = request.Value,
            });

            return Unit.Value;
        }
    }
}
