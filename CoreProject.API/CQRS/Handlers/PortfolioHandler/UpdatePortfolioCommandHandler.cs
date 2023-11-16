using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, bool>
    {
        private readonly IPortfolioService _portfolioService;

        public UpdatePortfolioCommandHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<bool> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            return await _portfolioService.Update(new Portfolio
            {
                PortfolioID = request.PortfolioID,
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
                Status = request.Status,
                Value = request.Value,

            });
        }
    }
}
