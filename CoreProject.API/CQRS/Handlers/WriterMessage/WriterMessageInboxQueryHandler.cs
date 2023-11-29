using CoreProject.API.CQRS.Queries.WriterMessage;
using CoreProject.API.CQRS.Results.AnnouncementResult;
using CoreProject.API.CQRS.Results.WriterMessageResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.WriterMessage
{
    public class WriterMessageInboxQueryHandler : IRequestHandler<WriterMessageInboxQuery, List<WriterMessageInboxQueryResult>>
    {
        private readonly IWriterMessageService _writerMessageService;

        public WriterMessageInboxQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<List<WriterMessageInboxQueryResult>> Handle(WriterMessageInboxQuery request, CancellationToken cancellationToken)
        {
            var query =  _writerMessageService.GetWhere(x => x.Receiver == request.mail);
            return query.Select(x => new WriterMessageInboxQueryResult
            {
                WriterMessageID = x.WriterMessageID,
                Receiver=x.Receiver,
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
