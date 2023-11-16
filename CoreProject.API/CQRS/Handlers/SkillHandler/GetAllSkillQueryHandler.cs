using CoreProject.API.CQRS.Queries.SkillQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.SkillResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<GetAllSkillQueryResult>>
    {
        private readonly ISkillService _skillService;

        public GetAllSkillQueryHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<List<GetAllSkillQueryResult>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var query = _skillService.GetWhere(x => x.SkillID >= 1);
            return query.Select(x => new GetAllSkillQueryResult
            {
               SkillID = x.SkillID,
               Title = x.Title,
               Value= x.Value
            }).AsNoTracking().ToList();
        }
    }
}
