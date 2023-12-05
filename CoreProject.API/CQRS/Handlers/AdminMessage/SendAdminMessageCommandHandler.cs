using CoreProject.API.CQRS.Commands.AdminMessage;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AdminMessage
{
    public class SendAdminMessageCommandHandler : IRequestHandler<SendAdminMessageCommand, bool>
    {
        private readonly IWriterMessageService _writerMessageService;

        public SendAdminMessageCommandHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<bool> Handle(SendAdminMessageCommand request, CancellationToken cancellationToken)
        {
            return await _writerMessageService.AddAsync(new Entity.Concrete.WriterMessage
            {
                Date = request.Date,
                MessageContent = request.MessageContent,
                Receiver = request.Receiver,
                ReceiverName = request.ReceiverName,
                Sender = request.Sender,
                SenderName = request.SenderName,
                Subject = request.Subject
            });
        }
    }
}
