using CoreProject.API.CQRS.Queries.TestimonialQuery;
using CoreProject.API.CQRS.Results.TestimonialResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.TestimonialHandler
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly ITestimonialService _testimonialService;

        public GetTestimonialByIdQueryHandler(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _testimonialService.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = value.TestimonialID,
                ClientName = value.ClientName,
                Comment = value.Comment,
                Company = value.Company,
                ImageUrl = value.ImageUrl,
                Title = value.Title
            };
        }
    }
}
