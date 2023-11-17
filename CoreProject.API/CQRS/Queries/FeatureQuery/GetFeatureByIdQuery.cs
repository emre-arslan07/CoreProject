using CoreProject.API.CQRS.Results.FeatureResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.FeatureQuery
{
    public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQuery(int id) 
        {
        this.Id = id;
        }
        public int Id { get; set; }
    }
}
