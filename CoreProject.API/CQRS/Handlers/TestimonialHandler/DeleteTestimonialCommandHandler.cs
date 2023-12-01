using CoreProject.API.CQRS.Commands.TestimonialCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.TestimonialHandler
{
    public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand, bool>
    {
        private readonly ITestimonialService _testimonialService;

        public DeleteTestimonialCommandHandler(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<bool> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value=await _testimonialService.GetByIdAsync(request.Id);
            return await _testimonialService.Remove(value);
        }
    }
}
