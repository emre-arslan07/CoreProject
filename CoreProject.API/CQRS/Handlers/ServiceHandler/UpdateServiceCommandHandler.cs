using CoreProject.API.CQRS.Commands.ServiceCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IServiceService _serviceService;

        public UpdateServiceCommandHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            return await _serviceService.Update(new Service
            {
                ServiceID = request.ServiceID,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            });
        }
    }
}
