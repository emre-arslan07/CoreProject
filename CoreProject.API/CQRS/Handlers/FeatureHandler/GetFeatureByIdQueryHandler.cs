using CoreProject.API.CQRS.Queries.FeatureQuery;
using CoreProject.API.CQRS.Results.FeatureResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.FeatureHandler
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IFeatureService _featureService;

        public GetFeatureByIdQueryHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _featureService.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureID = query.FeatureID,
                Header = query.Header,
                Name = query.Name,
                Title = query.Title
            };
        }
    }
}
