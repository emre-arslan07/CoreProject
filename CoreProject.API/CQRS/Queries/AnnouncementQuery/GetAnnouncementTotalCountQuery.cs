using MediatR;

namespace CoreProject.API.CQRS.Queries.AnnouncementQuery
{
    public class GetAnnouncementTotalCountQuery:IRequest<int>
    {
    }
}
