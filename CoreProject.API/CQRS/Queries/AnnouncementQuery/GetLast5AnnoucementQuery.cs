using CoreProject.API.CQRS.Results.AnnouncementResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AnnouncementQuery
{
    public class GetLast5AnnoucementQuery:IRequest<List<GetLast5AnnouncementQueryResult>>
    {
    }
}
