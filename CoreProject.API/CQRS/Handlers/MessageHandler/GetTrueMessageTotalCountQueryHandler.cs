using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetTrueMessageTotalCountQueryHandler : IRequestHandler<GetTrueMessageTotalQuery, int>
    {
        private readonly IMessageService _messageService;

        public GetTrueMessageTotalCountQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<int> Handle(GetTrueMessageTotalQuery request, CancellationToken cancellationToken)
        {
            return _messageService.GetWhere(x=>x.MessageID>=1 && x.Status==true).Count();
        }
    }
}
