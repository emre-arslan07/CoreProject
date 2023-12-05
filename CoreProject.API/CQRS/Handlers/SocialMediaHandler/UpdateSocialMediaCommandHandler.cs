using CoreProject.API.CQRS.Commands.SocialMediaCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SocialMediaHandler
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, bool>
    {
        private readonly ISocialMediaService _socialMediaService;

        public UpdateSocialMediaCommandHandler(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<bool> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _socialMediaService.Update(new Entity.Concrete.SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                SocialMediaID = request.SocialMediaID,
                Status = request.Status,
                Url = request.Url
            });
        }
    }
}
