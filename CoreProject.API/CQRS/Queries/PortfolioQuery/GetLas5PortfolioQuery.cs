using CoreProject.API.CQRS.Results.PortfolioResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.PortfolioQuery
{
    public class GetLas5PortfolioQuery:IRequest<List<GetLast5PortfolioQueryResult>>
    {
    }
}
