using CoreProject.API.CQRS.Queries.WriterMessage;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.WriterMessage
{
    public class GetWriterMessageInboxCountQueryHandler : IRequestHandler<GetWriterMessageInboxCountQuery, int>
    {
        private readonly IWriterMessageService _writerMessageService;

        public GetWriterMessageInboxCountQueryHandler(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public async Task<int> Handle(GetWriterMessageInboxCountQuery request, CancellationToken cancellationToken)
        {
            return _writerMessageService.GetWhere(x=>x.Receiver==request.Email).Count();
        }
    }
}
