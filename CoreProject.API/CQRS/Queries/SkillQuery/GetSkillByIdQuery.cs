using CoreProject.API.CQRS.Results.SkillResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.SkillQuery
{
    public class GetSkillByIdQuery:IRequest<GetSkillByIdQueryResult>
    {
        public GetSkillByIdQuery(int id) 
        {
            this.id = id;
        }
        public int id { get; set; }
    }
}
