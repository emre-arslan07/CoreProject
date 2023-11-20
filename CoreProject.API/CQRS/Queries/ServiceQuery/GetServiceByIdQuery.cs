using CoreProject.API.CQRS.Results.ServiceResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.ServiceQuery
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public GetServiceByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
