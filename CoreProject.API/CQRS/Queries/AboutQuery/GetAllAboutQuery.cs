using CoreProject.API.CQRS.Results.AboutResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AboutQuery
{
    public class GetAllAboutQuery:IRequest<List<GetAllAboutQueryResult>>
    {
    }
}
