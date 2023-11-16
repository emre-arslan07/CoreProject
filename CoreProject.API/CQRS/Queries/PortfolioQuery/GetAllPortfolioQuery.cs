using CoreProject.API.CQRS.Results.PortfolioResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.PortfolioQuery
{
    public class GetAllPortfolioQuery:IRequest<List<GetAllPortfolioQueryResult>>
    {
    }
}
