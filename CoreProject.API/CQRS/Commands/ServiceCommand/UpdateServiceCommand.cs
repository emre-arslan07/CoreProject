using MediatR;

namespace CoreProject.API.CQRS.Commands.ServiceCommand
{
    public class UpdateServiceCommand:IRequest<bool>
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
