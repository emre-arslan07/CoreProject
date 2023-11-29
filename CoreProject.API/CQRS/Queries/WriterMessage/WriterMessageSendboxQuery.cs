using CoreProject.API.CQRS.Results.WriterMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.WriterMessage
{
    public class WriterMessageSendboxQuery:IRequest<List<WriterMessageSendboxQueryResult>>
    {
        public WriterMessageSendboxQuery(string mail)
        {
            this.mail = mail;
        }
        public string mail { get; set; }
    }
}
