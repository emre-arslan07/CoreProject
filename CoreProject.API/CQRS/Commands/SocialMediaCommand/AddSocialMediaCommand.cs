using MediatR;

namespace CoreProject.API.CQRS.Commands.SocialMediaCommand
{
    public class AddSocialMediaCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
    }
}
