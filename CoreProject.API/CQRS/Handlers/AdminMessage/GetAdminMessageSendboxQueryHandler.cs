using CoreProject.API.CQRS.Queries.AdminMessageQuery;
using CoreProject.API.CQRS.Results.AdminMessageResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.AdminMessage
{
    public class GetAdminMessageSendboxQueryHandler : IRequestHandler<GetAdminMessageSendboxQuery, List<GetAdminMessageSendboxQueryResult>>
    {
        private readonly IWriterMessageService _writerMessageService;

        public GetAdminMessageSendboxQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<List<GetAdminMessageSendboxQueryResult>> Handle(GetAdminMessageSendboxQuery request, CancellationToken cancellationToken)
        {
            var query = _writerMessageService.GetWhere(x => x.Sender == request.Mail);
            return query.Select(x => new GetAdminMessageSendboxQueryResult
            {
                Date = x.Date,
                MessageContent = x.MessageContent,
                Receiver = x.Receiver,
                ReceiverName = x.ReceiverName,
                Sender = x.Sender,
                SenderName = x.SenderName,
                Subject = x.Subject,
                WriterMessageID = x.WriterMessageID
            }).AsNoTracking().ToList();
        }
    }
}
