using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.API.CQRS.Results.MessageResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, GetMesageByIdQueryResult>
    {
        private readonly IMessageService _messageService;

        public GetMessageByIdQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<GetMesageByIdQueryResult> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _messageService.GetByIdAsync(request.Id);
            return new GetMesageByIdQueryResult
            {
                Content = query.Content,
                Date = query.Date,
                Mail = query.Mail,
                MessageID = query.MessageID,
                Name = query.Name,
                Status = query.Status
            };
        }
    }
}
