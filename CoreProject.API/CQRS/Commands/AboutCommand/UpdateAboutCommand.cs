using MediatR;

namespace CoreProject.API.CQRS.Commands.AboutCommand
{
    public class UpdateAboutCommand:IRequest<bool>
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
    }
}
