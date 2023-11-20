using CoreProject.API.CQRS.Queries.ServiceQuery;
using CoreProject.API.CQRS.Results.ServiceResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IServiceService _serviceService;

        public GetServiceByIdQueryHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _serviceService.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ImageUrl = query.ImageUrl,
                ServiceID = query.ServiceID,
                Title = query.Title
            };
        }
    }
}
