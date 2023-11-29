using CoreProject.API.CQRS.Queries.WriterMessage;
using CoreProject.API.CQRS.Results.WriterMessageResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.WriterMessage
{
    public class WriterMessageSendboxQueryHandler : IRequestHandler<WriterMessageSendboxQuery, List<WriterMessageSendboxQueryResult>>
    {
        private readonly IWriterMessageService _writerMessageService;

        public WriterMessageSendboxQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<List<WriterMessageSendboxQueryResult>> Handle(WriterMessageSendboxQuery request, CancellationToken cancellationToken)
        {
            var query = _writerMessageService.GetWhere(x => x.Sender == request.mail);
            return query.Select(x => new WriterMessageSendboxQueryResult
            {
                WriterMessageID = x.WriterMessageID,
                Receiver = x.Receiver,
                Date = DateTime.UtcNow,
                MessageContent = x.MessageContent,
                ReceiverName = x.ReceiverName,
                Sender = x.Sender,
                SenderName = x.SenderName,
                Subject = x.Subject

            }).AsNoTracking().ToList();
        }
    }
}
