using CoreProject.API.CQRS.Commands.SocialMediaCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SocialMediaHandler
{
    public class AddSocialMediaCommandHandler : IRequestHandler<AddSocialMediaCommand, bool>
    {
        private readonly ISocialMediaService _socialMediaService;

        public AddSocialMediaCommandHandler(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<bool> Handle(AddSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _socialMediaService.AddAsync(new SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Status = true,
                Url = request.Url
            });
        }
    }
}
