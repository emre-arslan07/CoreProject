using CoreProject.API.CQRS.Commands.SkillCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class AddSkillCommandHandler : IRequestHandler<AddSkillCommand>
    {
        private readonly ISkillService _skillService;

        public AddSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<Unit> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            await _skillService.AddAsync(new Skill
            {
               Title = request.Title,
               Value = request.Value
            });

            return Unit.Value;
        }
    }
}
