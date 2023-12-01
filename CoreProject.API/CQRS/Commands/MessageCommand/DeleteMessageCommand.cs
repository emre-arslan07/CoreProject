using MediatR;

namespace CoreProject.API.CQRS.Commands.MessageCommand
{
    public class DeleteMessageCommand:IRequest<bool>
    {
        public DeleteMessageCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
