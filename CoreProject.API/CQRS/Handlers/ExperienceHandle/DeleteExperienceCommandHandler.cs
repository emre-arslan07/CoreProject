using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, bool>
    {
        private readonly IExperienceService _experienceService;

        public DeleteExperienceCommandHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<bool> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var values = await _experienceService.GetByIdAsync(request.Id);
            return await _experienceService.Remove(values);
        }
    }
}
