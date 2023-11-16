using CoreProject.API.CQRS.Queries.TestimonialQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.TestimonialResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.TestimonialHandler
{
    public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQuery, List<GetAllTestimonialQueryResult>>
    {
        private readonly ITestimonialService _estimonialService;

        public GetAllTestimonialQueryHandler(ITestimonialService estimonialService)
        {
            _estimonialService = estimonialService;
        }

        public async Task<List<GetAllTestimonialQueryResult>> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
        {
            var query = _estimonialService.GetWhere(x => x.TestimonialID >= 1);
            return query.Select(x => new GetAllTestimonialQueryResult
            {
                TestimonialID = x.TestimonialID,
                ClientName = x.ClientName,
                Comment = x.Comment,
                Company = x.Company,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            }).AsNoTracking().ToList();
        }
    }
}
