using CoreProject.API.CQRS.Queries.SocialMediaQuery;
using CoreProject.API.CQRS.Results.SocialMediaResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SocialMediaHandler
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIDQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly ISocialMediaService _socialMediaService;

        public GetSocialMediaByIdQueryHandler(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIDQuery request, CancellationToken cancellationToken)
        {
            var values=await _socialMediaService.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = request.Id,
                Icon = values.Icon,
                Name = values.Name,
                Status = values.Status,
                Url = values.Url
            };
        }
    }
}
