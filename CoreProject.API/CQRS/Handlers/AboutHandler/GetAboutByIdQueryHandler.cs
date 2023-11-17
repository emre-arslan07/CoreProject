using CoreProject.API.CQRS.Queries.AboutQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AboutHandler
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IAboutService _aboutService;

        public GetAboutByIdQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _aboutService.GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult
            {
                AboutID = query.AboutID,
                Address = query.Address,
                Age = query.Age,
                Description = query.Description,
                ImageUrl = query.ImageUrl,
                Mail = query.Mail,
                Phone = query.Phone,
                Title = query.Title
            };
        }
    }
}
