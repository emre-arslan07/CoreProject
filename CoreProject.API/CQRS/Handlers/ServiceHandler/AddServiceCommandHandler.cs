using CoreProject.API.CQRS.Commands.ServiceCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class AddServiceCommandHandler : IRequestHandler<AddServiceCommand>
    {
        private readonly IServiceService _serviceService;

        public AddServiceCommandHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<Unit> Handle(AddServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceService.AddAsync(new Service
            {
                ImageUrl = request.ImageUrl,
                Title = request.Title
            });
            return Unit.Value;
        }
    }
}
