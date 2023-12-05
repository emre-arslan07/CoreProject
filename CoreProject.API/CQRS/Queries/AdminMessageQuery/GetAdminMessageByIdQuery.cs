using CoreProject.API.CQRS.Results.AdminMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AdminMessageQuery
{
    public class GetAdminMessageByIdQuery:IRequest<GetAdminMessageByIdQueryResult>
    {
        public GetAdminMessageByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
