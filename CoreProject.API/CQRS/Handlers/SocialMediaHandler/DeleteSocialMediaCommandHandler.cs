using CoreProject.API.CQRS.Commands.SocialMediaCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SocialMediaHandler
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, bool>
    {
        private readonly ISocialMediaService _socialMediaService;

        public DeleteSocialMediaCommandHandler(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<bool> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values=await _socialMediaService.GetByIdAsync(request.Id);
            return await _socialMediaService.Remove(values);
        }
    }
}
