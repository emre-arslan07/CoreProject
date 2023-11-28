using MediatR;

namespace CoreProject.API.CQRS.Queries.AppUserQuery
{
    public class GetUserTotalCountQuery:IRequest<int>
    {
    }
}
