using CoreProject.API.CQRS.Results.ContactResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ContactQuery
{
    public class GetAllContactQuery:IRequest<List<GetAllContactQueryResult>>
    {
    }
}
