using CoreProject.API.CQRS.Results.MessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.MessageQuery
{
    public class GetMessageByIdQuery:IRequest<GetMesageByIdQueryResult>
    {
        public GetMessageByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
