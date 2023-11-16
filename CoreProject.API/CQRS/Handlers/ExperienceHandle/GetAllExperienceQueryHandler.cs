using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.ExperienceResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class GetAllExperienceQueryHandler : IRequestHandler<GetAllExperienceQuery, List<GetAllExperienceQueryResult>>
    {
        private readonly IExperienceService _experienceService;

        public GetAllExperienceQueryHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<List<GetAllExperienceQueryResult>> Handle(GetAllExperienceQuery request, CancellationToken cancellationToken)
        {
            var query = _experienceService.GetWhere(x => x.ExprerienceID >= 1);
            return query.Select(x => new GetAllExperienceQueryResult
            {
                ExprerienceID = x.ExprerienceID,
                Date = x.Date,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).AsNoTracking().ToList();
        }
    }
}
