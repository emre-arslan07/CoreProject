using MediatR;

namespace CoreProject.API.CQRS.Commands.FeatureCommand
{
    public class UpdateFeatureCommand:IRequest<bool>
    {
        public int FeatureID { get; set; }
        public string Header { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
