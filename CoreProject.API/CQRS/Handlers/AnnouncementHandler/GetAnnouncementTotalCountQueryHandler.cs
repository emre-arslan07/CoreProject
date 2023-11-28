using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AnnouncementHandler
{
    public class GetAnnouncementTotalCountQueryHandler : IRequestHandler<GetAnnouncementTotalCountQuery, int>
    {
        private readonly IAnnouncementService _announcementService;

        public GetAnnouncementTotalCountQueryHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<int> Handle(GetAnnouncementTotalCountQuery request, CancellationToken cancellationToken)
        {
            return  _announcementService.GetWhere(x => x.ID >= 1).Count();
        }
    }
}
