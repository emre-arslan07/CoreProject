using MediatR;

namespace CoreProject.API.CQRS.Commands.ExperienceCommand
{
    public class DeleteExperienceCommand:IRequest<bool>
    {
        public DeleteExperienceCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }

    }
}
