using CoreProject.API.CQRS.Results.SocialMediaResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.SocialMediaQuery
{
    public class GetAllSocialMediaQuery:IRequest<List<GetAllSocialMediaQueryResult>>
    {
    }
}
