using CoreProject.API.CQRS.Results.WriterMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.WriterMessage
{
    public class GetWriterMessageByIdQuery:IRequest<GetWriterMesageByIdQueryResult>
    {
        public GetWriterMessageByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
