using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class AddExperienceCommandHandler : IRequestHandler<AddExperienceCommand,bool>
    {
        private readonly IExperienceService _experienceService;

        public AddExperienceCommandHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<bool> Handle(AddExperienceCommand request, CancellationToken cancellationToken)
        {
          return await _experienceService.AddAsync(new Experience
            {
                Name = request.Name,
                Date = request.Date,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            });

            
        }
    }
}
