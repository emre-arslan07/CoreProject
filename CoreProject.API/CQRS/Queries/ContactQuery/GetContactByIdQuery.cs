using CoreProject.API.CQRS.Results.ContactResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ContactQuery
{
    public class GetContactByIdQuery:IRequest<GetContactByIdQueryResult>
    {
        public GetContactByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
