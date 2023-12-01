using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly IMessageService _messageService;

        public DeleteMessageCommandHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var value=await _messageService.GetByIdAsync(request.Id);
            return await _messageService.Remove(value);
        }
    }
}
