using CoreProject.API.CQRS.Commands.SkillCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class DeleteSkillCommandHandler:IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly ISkillService _skillService;

        public DeleteSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        //public async Task<bool> Handle(DeleteSkillCommand deleteSkillCommand)
        //{
        //    var values = await _skillService.GetByIdAsync(deleteSkillCommand.Id);
        //    return await _skillService.Remove(values);
        //}

        public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var values = await _skillService.GetByIdAsync(request.Id);
            return await _skillService.Remove(values);
        }
    }
}
