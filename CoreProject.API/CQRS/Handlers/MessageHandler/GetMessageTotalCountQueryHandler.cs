using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.API.CQRS.Results.MessageResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetMessageTotalCountQueryHandler : IRequestHandler<GetMessageTotalCountQuery, int>
    {
        private readonly IMessageService _messageService;

        public GetMessageTotalCountQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<int> Handle(GetMessageTotalCountQuery request, CancellationToken cancellationToken)
        {
            return  _messageService.GetWhere(x => x.MessageID >= 1).Count();
        }
    }
}
