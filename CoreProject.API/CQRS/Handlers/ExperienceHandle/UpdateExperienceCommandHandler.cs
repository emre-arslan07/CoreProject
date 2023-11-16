using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, bool>
    {
        private readonly IExperienceService _experienceService;

        public UpdateExperienceCommandHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<bool> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            return await _experienceService.Update(new Experience
            {
                ExprerienceID = request.ExprerienceID,
                Name = request.Name,
                Date = request.Date,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            });
        }
    }
}
