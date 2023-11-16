using MediatR;

namespace CoreProject.API.CQRS.Commands.SkillCommand
{
    public class DeleteSkillCommand:IRequest<bool>
    {
        public DeleteSkillCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }


}
