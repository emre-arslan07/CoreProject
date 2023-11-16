using CoreProject.API.CQRS.Commands.PortfolioCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, bool>
    {
        private readonly IPortfolioService _portfolioService;

        public DeletePortfolioCommandHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<bool> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var value = await _portfolioService.GetByIdAsync(request.Id);
            return await _portfolioService.Remove(value);
        }
    }
}
