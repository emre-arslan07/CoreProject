using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Results.ExperienceResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class GetExperienceByIdCommandHandler : IRequestHandler<GetExperienceByIdQuery, GetExperienceByIdQueryResult>
    {
        private readonly IExperienceService _experienceService;

        public GetExperienceByIdCommandHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<GetExperienceByIdQueryResult> Handle(GetExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _experienceService.GetByIdAsync(request.id);
            return new GetExperienceByIdQueryResult
            {
                ExprerienceID = query.ExprerienceID,
                Name = query.Name,
                Date = query.Date,
                Description = query.Description,
                ImageUrl = query.ImageUrl
            };
        }
    }
}
