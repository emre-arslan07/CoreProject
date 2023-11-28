using CoreProject.API.CQRS.Results.AnnouncementResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AnnouncementQuery
{
    public class GetAllAnnouncementQuery:IRequest<List<GetAllAnnouncementQueryResult>>
    {
    }
}
