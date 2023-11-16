using CoreProject.API.CQRS.Results.ServiceResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ServiceQuery
{
    public class GetAllServiceQuery:IRequest<List<GetAllServiceQueryResult>>
    {
    }
}
