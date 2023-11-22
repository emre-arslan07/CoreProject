using MediatR;

namespace CoreProject.API.CQRS.Queries.PortfolioQuery
{
    public class GetPortfolioTotalCountQuery:IRequest<int>
    {
    }
}
