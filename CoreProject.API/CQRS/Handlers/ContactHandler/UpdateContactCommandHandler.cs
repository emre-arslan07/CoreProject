using CoreProject.API.CQRS.Commands.ContactCommand;
using CoreProject.BLL.Abstract;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.ContactHandler
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, bool>
    {   
        private readonly IContactService _contactService;

        public UpdateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactService.Update(new Entity.Concrete.Contact
            {
                ContactID = request.ContactID,
                Description = request.Description,
                Mail=request.Mail,
                Phone = request.Phone,
                Title = request.Title
            });
        }
    }
}
