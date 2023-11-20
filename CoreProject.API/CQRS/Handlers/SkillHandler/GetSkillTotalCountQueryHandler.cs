using CoreProject.API.CQRS.Queries.SkillQuery;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class GetSkillTotalCountQueryHandler : IRequestHandler<GetSkillTotalCountQuery, int>
    {
        private readonly ISkillService _skillService;

        public GetSkillTotalCountQueryHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<int> Handle(GetSkillTotalCountQuery request, CancellationToken cancellationToken)
        {
            return _skillService.GetWhere(x=>x.SkillID>=1).Count();
        }
    }
}
