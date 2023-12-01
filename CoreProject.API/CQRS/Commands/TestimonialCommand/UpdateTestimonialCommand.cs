using MediatR;

namespace CoreProject.API.CQRS.Commands.TestimonialCommand
{
    public class UpdateTestimonialCommand:IRequest<bool>
    {
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string Company { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
