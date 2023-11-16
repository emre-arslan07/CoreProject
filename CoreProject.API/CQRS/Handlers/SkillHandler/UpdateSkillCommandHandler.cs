using CoreProject.API.CQRS.Commands.SkillCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, bool>
    {
        private readonly ISkillService _skillService;

        public UpdateSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            return await _skillService.Update(new Skill
            {
                SkillID = request.SkillID,
                Title = request.Title,
                Value = request.Value
            });
        }
    }
}
