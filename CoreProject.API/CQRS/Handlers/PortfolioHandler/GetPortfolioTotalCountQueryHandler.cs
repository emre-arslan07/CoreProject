using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class GetPortfolioTotalCountQueryHandler : IRequestHandler<GetPortfolioTotalCountQuery, int>
    {
        private readonly IPortfolioService _portfolioService;

        public GetPortfolioTotalCountQueryHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<int> Handle(GetPortfolioTotalCountQuery request, CancellationToken cancellationToken)
        {
            return  _portfolioService.GetWhere(x => x.PortfolioID>=1).Count();
        }
    }
}
