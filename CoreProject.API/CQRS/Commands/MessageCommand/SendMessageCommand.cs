using MediatR;

namespace CoreProject.API.CQRS.Commands.MessageCommand
{
    public class SendMessageCommand:IRequest
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
