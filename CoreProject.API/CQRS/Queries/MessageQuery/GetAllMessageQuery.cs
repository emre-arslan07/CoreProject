using CoreProject.API.CQRS.Results.MessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.MessageQuery
{
    public class GetAllMessageQuery:IRequest<List<GetAllMessageQueryResult>>
    {
    }
}
