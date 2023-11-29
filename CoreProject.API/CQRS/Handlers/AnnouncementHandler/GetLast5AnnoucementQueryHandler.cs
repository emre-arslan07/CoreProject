using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.API.CQRS.Results.AnnouncementResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.AnnouncementHandler
{
    public class GetLast5AnnoucementQueryHandler : IRequestHandler<GetLast5AnnoucementQuery, List<GetLast5AnnouncementQueryResult>>
    {
        private readonly IAnnouncementService _announcementService;

        public GetLast5AnnoucementQueryHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<List<GetLast5AnnouncementQueryResult>> Handle(GetLast5AnnoucementQuery request, CancellationToken cancellationToken)
        {
            var query =  _announcementService.GetWhere(x => x.ID >= 1).OrderByDescending(x => x.ID).Take(5);
            return await query.Select(x => new GetLast5AnnouncementQueryResult
            {
                ID = x.ID,
                Content = x.Content,
                Date = x.Date,
                Status = x.Status,
                Title = x.Title
            }).AsNoTracking().ToListAsync();
        }
    }
}
