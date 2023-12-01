using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.API.CQRS.Results.MessageResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetAllMessageQueryHandler : IRequestHandler<GetAllMessageQuery, List<GetAllMessageQueryResult>>
    {
        private readonly IMessageService _messageService;

        public GetAllMessageQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<List<GetAllMessageQueryResult>> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
        {
            var query =  _messageService.GetWhere(x => x.MessageID >= 1);
            return query.Select(x => new GetAllMessageQueryResult
            {
                MessageID = x.MessageID,
                Content = x.Content,
                Date = x.Date,
                Mail = x.Mail,
                Name = x.Name,
                Status = x.Status
            }).AsNoTracking().ToList();
        }
    }
}
