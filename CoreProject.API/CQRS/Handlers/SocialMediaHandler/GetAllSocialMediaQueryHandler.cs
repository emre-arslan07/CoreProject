using CoreProject.API.CQRS.Queries.SocialMediaQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.SocialMediaResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.SocialMediaHandler
{
    public class GetAllSocialMediaQueryHandler : IRequestHandler<GetAllSocialMediaQuery, List<GetAllSocialMediaQueryResult>>
    {
        private readonly ISocialMediaService _socialMediaService;

        public GetAllSocialMediaQueryHandler(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<List<GetAllSocialMediaQueryResult>> Handle(GetAllSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var query = _socialMediaService.GetWhere(x => x.SocialMediaID >= 1);
            return query.Select(x => new GetAllSocialMediaQueryResult
            {
                SocialMediaID = x.SocialMediaID,
                Name = x.Name,
                Status = x.Status,
                Icon = x.Icon,
                Url = x.Url
            }).AsNoTracking().ToList();
        }
    }
}
