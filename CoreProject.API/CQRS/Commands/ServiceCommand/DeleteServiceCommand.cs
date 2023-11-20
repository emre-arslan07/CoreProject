using MediatR;

namespace CoreProject.API.CQRS.Commands.ServiceCommand
{
    public class DeleteServiceCommand:IRequest<bool>
    {
        public DeleteServiceCommand(int id) 
        { 
            this.Id = id;
        }
        public int Id { get; set; }

    }
}
