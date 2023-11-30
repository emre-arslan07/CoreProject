using CoreProject.API.CQRS.Results.WriterMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.WriterMessage
{
    public class GetWriterMessageInboxCountQuery:IRequest<int>
    {
        public GetWriterMessageInboxCountQuery(string email)
        {
            this.Email = email;
        }
        public string Email { get; set; }
    }
}
