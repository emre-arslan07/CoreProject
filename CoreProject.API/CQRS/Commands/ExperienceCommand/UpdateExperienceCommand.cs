using MediatR;

namespace CoreProject.API.CQRS.Commands.ExperienceCommand
{
    public class UpdateExperienceCommand:IRequest<bool>
    {
        public int ExprerienceID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
