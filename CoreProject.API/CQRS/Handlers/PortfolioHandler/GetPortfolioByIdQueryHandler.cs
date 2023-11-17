using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.API.CQRS.Results.PortfolioResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class GetPortfolioByIdQueryHandler : IRequestHandler<GetPortfolioByIdQuery, GetPortfolioByIdQueryResult>
    {
        private readonly IPortfolioService _portfolioService;

        public GetPortfolioByIdQueryHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<GetPortfolioByIdQueryResult> Handle(GetPortfolioByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _portfolioService.GetByIdAsync(request.Id);
            return new GetPortfolioByIdQueryResult
            {
                Image1 = query.Image1,
                Image2 = query.Image2,
                Image3 = query.Image3,
                Image4 = query.Image4,
                ImageUrl = query.ImageUrl,
                ImageUrl2 = query.ImageUrl2,
                Name = query.Name,
                Platform = query.Platform,
                PortfolioID = query.PortfolioID,
                Price = query.Price,
                ProjectUrl = query.ProjectUrl,
                Status = query.Status,
                Value = query.Value
            };
        }
    }
}
