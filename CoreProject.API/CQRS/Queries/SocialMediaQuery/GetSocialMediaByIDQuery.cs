using CoreProject.API.CQRS.Results.SocialMediaResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.SocialMediaQuery
{
    public class GetSocialMediaByIDQuery:IRequest<GetSocialMediaByIdQueryResult>
    {
        public GetSocialMediaByIDQuery(int id)
        {
                this.Id = id;
        }
        public int Id { get; set; }
    }
}
