using CoreProject.API.CQRS.Commands.MessageCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;
using System;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IMessageService _messageService;

        public SendMessageCommandHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
              await _messageService.AddAsync(new Message
            {
                Content = request.Content,
                Mail=request.Mail,
                Name = request.Name,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = true
            }) ;

            return Unit.Value;
        }
    }
}
