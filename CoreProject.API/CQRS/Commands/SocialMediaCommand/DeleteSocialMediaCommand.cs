using MediatR;

namespace CoreProject.API.CQRS.Commands.SocialMediaCommand
{
    public class DeleteSocialMediaCommand:IRequest<bool>
    {
        public DeleteSocialMediaCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
