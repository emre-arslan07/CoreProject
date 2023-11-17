using CoreProject.API.CQRS.Results.AboutResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AboutQuery
{
    public class GetAboutByIdQuery:IRequest<GetAboutByIdQueryResult>
    {
        public GetAboutByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
