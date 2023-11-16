using CoreProject.API.CQRS.Queries.SkillQuery;
using CoreProject.API.CQRS.Results.SkillResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.SkillHandler
{
    public class GetSkillByIdCommandHandler : IRequestHandler<GetSkillByIdQuery, GetSkillByIdQueryResult>
    {
        private readonly ISkillService _skillService;

        public GetSkillByIdCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<GetSkillByIdQueryResult> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _skillService.GetByIdAsync(request.id);

            return new GetSkillByIdQueryResult
            {
                SkillID=query.SkillID,
                Title=query.Title,
                Value=query.Value
            };
        }
    }
}
