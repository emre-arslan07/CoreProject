using CoreProject.API.CQRS.Commands.AdminMessage;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AdminMessage
{
    public class DeleteAdminMessageCommandHandler : IRequestHandler<DeleteAdminMessageCommand, bool>
    {
        private readonly IWriterMessageService _writerMessageService;

        public DeleteAdminMessageCommandHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<bool> Handle(DeleteAdminMessageCommand request, CancellationToken cancellationToken)
        {
            var values=await _writerMessageService.GetByIdAsync(request.Id);
            return await _writerMessageService.Remove(values);
        }
    }
}
