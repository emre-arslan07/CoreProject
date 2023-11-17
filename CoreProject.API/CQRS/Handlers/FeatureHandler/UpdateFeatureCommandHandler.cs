using CoreProject.API.CQRS.Commands.FeatureCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.FeatureHandler
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, bool>
    {
        private readonly IFeatureService _featureService;

        public UpdateFeatureCommandHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            return await _featureService.Update(new Feature
            {
                FeatureID = request.FeatureID,
                Header = request.Header,
                Name = request.Name,
                Title = request.Title
            });
        }
    }
}
