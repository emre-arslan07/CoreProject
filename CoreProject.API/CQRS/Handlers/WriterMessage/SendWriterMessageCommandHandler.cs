using CoreProject.API.CQRS.Commands.WriterMessageCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.WriterMessage
{
    public class SendWriterMessageCommandHandler : IRequestHandler<SendWriterMessageCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWriterMessageService _writerMessageService;

       

        public SendWriterMessageCommandHandler(UserManager<AppUser> userManager, IWriterMessageService writerMessageService) 
        {
            _userManager = userManager;
            _writerMessageService = writerMessageService;
        }

        public async Task<bool> Handle(SendWriterMessageCommand request, CancellationToken cancellationToken)
        {
            //var receiverValue = await _userManager.FindByEmailAsync(request.Receiver);
            //return await _writerMessageService.AddAsync(new Entity.Concrete.WriterMessage
            //{
            //    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            //    MessageContent = request.MessageContent,
            //    Receiver=request.Receiver,
            //    ReceiverName=receiverValue.Name+" "+receiverValue.Surname,
            //    Sender = request.Sender,
            //    SenderName = request.SenderName,
            //    Subject = request.Subject
            //});

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
