using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.AnnouncementResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.AnnouncementHandler
{
    public class GetAllAnnouncementQueryHandler : IRequestHandler<GetAllAnnouncementQuery, List<GetAllAnnouncementQueryResult>>
    {
        private readonly IAnnouncementService _announcementService;

        public GetAllAnnouncementQueryHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<List<GetAllAnnouncementQueryResult>> Handle(GetAllAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var query = _announcementService.GetWhere(x => x.ID >= 1);
            return query.Select(x => new GetAllAnnouncementQueryResult
            {
                ID = x.ID,
                Content = x.Content,
                Date = x.Date,
                Status = x.Status,
                Title = x.Title
            }).AsNoTracking().ToList();
        }
    }
}
