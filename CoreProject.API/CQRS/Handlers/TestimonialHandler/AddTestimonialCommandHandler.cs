using CoreProject.API.CQRS.Commands.TestimonialCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.TestimonialHandler
{
    public class AddTestimonialCommandHandler : IRequestHandler<AddTestimonialCommand>
    {
        private readonly ITestimonialService _testimonialService;

        public AddTestimonialCommandHandler(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<Unit> Handle(AddTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _testimonialService.AddAsync(new Entity.Concrete.Testimonial
            {
                ClientName = request.ClientName,
                Comment = request.Comment,
                Company= request.Company,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            });
            return Unit.Value;
        }
    }
}
