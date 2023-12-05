using MediatR;

namespace CoreProject.API.CQRS.Commands.AdminMessage
{
    public class DeleteAdminMessageCommand:IRequest<bool>
    {
        public DeleteAdminMessageCommand(int id)
        {

            this.Id = id;

        }
        public int Id { get; set; }
    }
}
