using MediatR;

namespace CoreProject.API.CQRS.Commands.SkillCommand
{
    public class AddSkillCommand:IRequest
    {
        public int SkillID { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
