using CoreProject.API.CQRS.Queries.MessageQuery;
using CoreProject.API.CQRS.Results.MessageResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.MessageHandler
{
    public class GetLast3MessageQueryHandler : IRequestHandler<GetLast3MessageQuery, List<GetLast3MessageQueryResult>>
    {
        private readonly IMessageService _messageService;

        public GetLast3MessageQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<List<GetLast3MessageQueryResult>> Handle(GetLast3MessageQuery request, CancellationToken cancellationToken)
        {
            var query= _messageService.GetWhere(x=>x.MessageID>=1).OrderByDescending(x=>x.MessageID).Take(3);
            return await query.Select(x => new GetLast3MessageQueryResult
            {
                MessageID = x.MessageID,
                Date = x.Date,
                Name = x.Name,
                Status = x.Status
            }).AsNoTracking().ToListAsync();
        }
    }
}
