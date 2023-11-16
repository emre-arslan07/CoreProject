using CoreProject.API.CQRS.Results.ExperienceResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ExperienceQuery
{
    public class GetAllExperienceQuery:IRequest<List<GetAllExperienceQueryResult>>
    {
    }
}
