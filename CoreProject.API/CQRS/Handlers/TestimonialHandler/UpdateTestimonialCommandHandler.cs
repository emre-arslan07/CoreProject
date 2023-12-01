using CoreProject.API.CQRS.Commands.TestimonialCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.TestimonialHandler
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, bool>
    {
        private readonly ITestimonialService _testimonialService;

        public UpdateTestimonialCommandHandler(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<bool> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            return await _testimonialService.Update(new Entity.Concrete.Testimonial
            {
                ClientName = request.ClientName,
                Comment = request.Comment,
                Company = request.Company,
                ImageUrl = request.ImageUrl,
                TestimonialID = request.TestimonialID,
                Title = request.Title
            });
        }
    }
}
