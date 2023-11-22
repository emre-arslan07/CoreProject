using MediatR;

namespace CoreProject.API.CQRS.Queries.ServiceQuery
{
    public class GetServiceTotalCountQuery:IRequest<int>
    {
    }
}
