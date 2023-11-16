using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.AboutHandler
{
    public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQuery, List<GetAllAboutQueryResult>>
    {
        private readonly IAboutService _aboutService;

        public GetAllAboutQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<List<GetAllAboutQueryResult>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        {
            var query = _aboutService.GetWhere(x => x.AboutID >= 1);
            return query.Select(x=>new GetAllAboutQueryResult
            {
                AboutID = x.AboutID,
                Address = x.Address,
                Age = x.Age,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Mail=x.Mail,
                Phone = x.Phone,
                Title=x.Title,
            }).AsNoTracking().ToList();
        }
    }
}
