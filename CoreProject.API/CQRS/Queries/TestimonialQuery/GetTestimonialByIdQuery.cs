using CoreProject.API.CQRS.Results.TestimonialResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.TestimonialQuery
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public GetTestimonialByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
