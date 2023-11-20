using CoreProject.API.CQRS.Commands.ServiceCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ServiceHandler
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IServiceService _serviceService;

        public DeleteServiceCommandHandler(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _serviceService.GetByIdAsync(request.Id);
            return await _serviceService.Remove(values);
        }
    }
}
