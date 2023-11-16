using CoreProject.API.CQRS.Results.SkillResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.SkillQuery
{
    public class GetAllSkillQuery:IRequest<List<GetAllSkillQueryResult>>
    {
    }
}
