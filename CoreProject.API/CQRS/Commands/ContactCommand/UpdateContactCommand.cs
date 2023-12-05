using MediatR;

namespace CoreProject.API.CQRS.Commands.ContactCommand
{
    public class UpdateContactCommand:IRequest<bool>
    {
        public int ContactID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
