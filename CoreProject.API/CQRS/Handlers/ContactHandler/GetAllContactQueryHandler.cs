using CoreProject.API.CQRS.Queries.ContactQuery;
using CoreProject.API.CQRS.Results.AboutResult;
using CoreProject.API.CQRS.Results.ContactResult;
using CoreProject.BLL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.ContactHandler
{
    public class GetAllContactQueryHandler:IRequestHandler<GetAllContactQuery, List<GetAllContactQueryResult>>
    {
        IContactService _contactService;

        public GetAllContactQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<List<GetAllContactQueryResult>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            var query = _contactService.GetWhere(x => x.ContactID >= 1);
            return query.Select(x => new GetAllContactQueryResult
            {
                ContactID = x.ContactID,
                Description = x.Description,
                Mail=x.Mail,
                Phone = x.Phone,
                Title = x.Title
            }).AsNoTracking().ToList();
        }
    }
}
