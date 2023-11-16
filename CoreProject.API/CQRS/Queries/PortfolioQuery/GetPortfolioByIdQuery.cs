using CoreProject.API.CQRS.Results.PortfolioResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.PortfolioQuery
{
    public class GetPortfolioByIdQuery:IRequest<GetPortfolioByIdQueryResult>
    {
        public GetPortfolioByIdQuery(int id)
        {
            this.Id=id;
        }

        public int Id { get; set; }
    }
}
