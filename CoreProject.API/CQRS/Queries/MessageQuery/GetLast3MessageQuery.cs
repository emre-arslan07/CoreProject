using CoreProject.API.CQRS.Results.MessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.MessageQuery
{
    public class GetLast3MessageQuery:IRequest<List<GetLast3MessageQueryResult>>
    {
    }
}
