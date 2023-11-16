using CoreProject.API.CQRS.Results.TestimonialResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.TestimonialQuery
{
    public class GetAllTestimonialQuery:IRequest<List<GetAllTestimonialQueryResult>>
    {
    }
}
