using MediatR;

namespace CoreProject.API.CQRS.Commands.TestimonialCommand
{
    public class DeleteTestimonialCommand:IRequest<bool>
    {
        public DeleteTestimonialCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
