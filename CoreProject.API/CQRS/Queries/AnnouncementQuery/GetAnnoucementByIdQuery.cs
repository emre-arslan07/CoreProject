using CoreProject.API.CQRS.Results.AnnouncementResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AnnouncementQuery
{
    public class GetAnnoucementByIdQuery:IRequest<GetAnnouncementByIdQueryResult>
    {
        public GetAnnoucementByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
