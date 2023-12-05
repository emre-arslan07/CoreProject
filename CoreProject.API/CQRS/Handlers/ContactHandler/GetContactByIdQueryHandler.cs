using CoreProject.API.CQRS.Queries.ContactQuery;
using CoreProject.API.CQRS.Results.ContactResult;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ContactHandler
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IContactService _contactService;

        public GetContactByIdQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _contactService.GetByIdAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Description = values.Description,
                Mail = values.Mail,
                Phone = values.Phone,
                Title = values.Title
            };
        }
    }
}
