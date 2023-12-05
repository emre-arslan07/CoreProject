using CoreProject.API.CQRS.Queries.AdminMessageQuery;
using CoreProject.API.CQRS.Results.AdminMessageResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AdminMessage
{
    public class GetAdminMessageByIdQueryHandler : IRequestHandler<GetAdminMessageByIdQuery, GetAdminMessageByIdQueryResult>
    {
        private readonly IWriterMessageService _writerMessageService;

        public GetAdminMessageByIdQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<GetAdminMessageByIdQueryResult> Handle(GetAdminMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _writerMessageService.GetByIdAsync(request.Id);
            return new GetAdminMessageByIdQueryResult
            {
                WriterMessageID = query.WriterMessageID,
                Date = query.Date,
                MessageContent = query.MessageContent,
                Receiver = query.Receiver,
                ReceiverName = query.ReceiverName,
                SenderName = query.ReceiverName,
                Sender = query.ReceiverName,
                Subject = query.ReceiverName
            };
        }
    }
}
