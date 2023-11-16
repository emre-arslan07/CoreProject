using CoreProject.API.CQRS.Queries.FeatureQuery;
using CoreProject.API.CQRS.Results.FeatureResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.FeatureHandler
{
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQuery, List<GetAllFeatureQueryResult>>
    {
        private readonly IFeatureService _featureService;

        public GetAllFeatureQueryHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<List<GetAllFeatureQueryResult>> Handle(GetAllFeatureQuery request, CancellationToken cancellationToken)
        {
            var query = _featureService.GetWhere(x => x.FeatureID == 1);
            return  query.Select(x => new GetAllFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                Header = x.Header,
                Name = x.Name,
                Title = x.Title,

            }).AsNoTracking().ToList();


        }
    }
}
