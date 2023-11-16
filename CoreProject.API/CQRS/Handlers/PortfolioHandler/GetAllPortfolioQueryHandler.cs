using CoreProject.API.CQRS.Queries.PortfolioQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.PortfolioResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.PortfolioHandler
{
    public class GetAllPortfolioQueryHandler : IRequestHandler<GetAllPortfolioQuery, List<GetAllPortfolioQueryResult>>
    {
        private readonly IPortfolioService _portfolioService;

        public GetAllPortfolioQueryHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<List<GetAllPortfolioQueryResult>> Handle(GetAllPortfolioQuery request, CancellationToken cancellationToken)
        {
            var query = _portfolioService.GetWhere(x => x.PortfolioID >= 1);
            return query.Select(x => new GetAllPortfolioQueryResult
            {
               PortfolioID = x.PortfolioID,
               Image1 = x.Image1,
               Image2 = x.Image2,
               Image3 = x.Image3,
               Image4 = x.Image4,
               ImageUrl = x.ImageUrl,
               ImageUrl2 = x.ImageUrl2,
               Name = x.Name,
               Platform = x.Platform,
               Price = x.Price,
               ProjectUrl = x.ProjectUrl,
               Status = x.Status,
               Value = x.Value
               
            }).AsNoTracking().ToList();
        }
    }
}
