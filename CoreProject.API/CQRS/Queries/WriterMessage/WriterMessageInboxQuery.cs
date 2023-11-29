using CoreProject.API.CQRS.Results.WriterMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.WriterMessage
{
    public class WriterMessageInboxQuery:IRequest<List<WriterMessageInboxQueryResult>>
    {
        public WriterMessageInboxQuery(string mail)
        {
            this.mail = mail;
        }
        public string mail { get; set; }
    }
}
