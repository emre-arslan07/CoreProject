using CoreProject.API.CQRS.Results.ExperienceResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ExperienceQuery
{
    public class GetExperienceByIdQuery:IRequest<GetExperienceByIdQueryResult>
    {
        public GetExperienceByIdQuery(int id) 
        {
        this.id=id;
        }
        public int id { get; set; }
    }
}
