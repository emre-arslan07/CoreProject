using CoreProject.API.CQRS.Queries.WriterMessage;
using CoreProject.API.CQRS.Results.WriterMessageResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.WriterMessage
{
    public class GetWriterMessageByIdQueryHandler : IRequestHandler<GetWriterMessageByIdQuery, GetWriterMesageByIdQueryResult>
    {
        private readonly IWriterMessageService _writerMessageService;

        public GetWriterMessageByIdQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<GetWriterMesageByIdQueryResult> Handle(GetWriterMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _writerMessageService.GetByIdAsync(request.Id);
            return new GetWriterMesageByIdQueryResult
            {
                WriterMessageID = query.WriterMessageID,
                Date = query.Date,
                MessageContent = query.MessageContent,
                Receiver = query.Receiver,
                ReceiverName = query.ReceiverName,
                SenderName = query.ReceiverName,
                Sender = query.Receiver,
                Subject = query.Subject
            };
        }
    }
}
