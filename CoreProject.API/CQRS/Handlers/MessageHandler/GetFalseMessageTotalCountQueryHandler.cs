using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetFalseMessageTotalCountQueryHandler : IRequestHandler<GetFalseMessageTotalQuery, int>
    {
        private readonly IMessageService _messageService;

        public GetFalseMessageTotalCountQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<int> Handle(GetFalseMessageTotalQuery request, CancellationToken cancellationToken)
        {
           
            return  _messageService.GetWhere(x=>x.MessageID>=1 && x.Status==false).Count();

        }
    }
}

