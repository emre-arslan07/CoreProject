using CoreProject.API.CQRS.Queries.ExperienceQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ExperienceHandle
{
    public class GetExperienceTotalCountQueryHandler : IRequestHandler<GetExperienceTotalCountQuery, int>
    {
        private readonly IExperienceService _experienceService;

        public GetExperienceTotalCountQueryHandler(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<int> Handle(GetExperienceTotalCountQuery request, CancellationToken cancellationToken)
        {
            return _experienceService.GetWhere(x=>x.ExprerienceID>=1).Count();
        }
    }
}
