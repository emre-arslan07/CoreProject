using CoreProject.API.CQRS.Results.FeatureResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.FeatureQuery
{
    public class GetAllFeatureQuery:IRequest<List<GetAllFeatureQueryResult>>
    {
    }
}
