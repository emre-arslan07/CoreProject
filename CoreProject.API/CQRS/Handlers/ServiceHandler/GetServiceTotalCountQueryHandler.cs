using CoreProject.API.CQRS.Queries.ServiceQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class GetServiceTotalCountQueryHandler : IRequestHandler<GetServiceTotalCountQuery, int>
    {
        private readonly IServiceService _serviceService;

        public GetServiceTotalCountQueryHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<int> Handle(GetServiceTotalCountQuery request, CancellationToken cancellationToken)
        {
            return _serviceService.GetWhere(x => x.ServiceID >= 1).Count();
        }
    }
}
