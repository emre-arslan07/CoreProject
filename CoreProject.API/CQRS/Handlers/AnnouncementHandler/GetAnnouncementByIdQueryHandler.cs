using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.AnnouncementResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AnnouncementHandler
{
    public class GetAnnouncementByIdQueryHandler : IRequestHandler<GetAnnoucementByIdQuery, GetAnnouncementByIdQueryResult>
    {
        private readonly IAnnouncementService _announcementService;

        public GetAnnouncementByIdQueryHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<GetAnnouncementByIdQueryResult> Handle(GetAnnoucementByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _announcementService.GetByIdAsync(request.Id);
            return new GetAnnouncementByIdQueryResult
            {
                ID= query.ID,
                Content = query.Content,
                Date = query.Date,
                Status = query.Status,
                Title = query.Title
               
            };
        }
    }
}
