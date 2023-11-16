using CoreProject.API.CQRS.Queries.ServiceQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.FeatureResult;
using CoreProject.API.CQRS.Results.ServiceResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, List<GetAllServiceQueryResult>>
    {
        private readonly IServiceService _serviceService;

        public GetAllServiceQueryHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<List<GetAllServiceQueryResult>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            var query = _serviceService.GetWhere(x => x.ServiceID >= 1);
            return query.Select(x => new GetAllServiceQueryResult
            {
               ServiceID = x.ServiceID,
               ImageUrl = x.ImageUrl,
               Title= x.Title
            }).AsNoTracking().ToList();
        }
    }
}
