using CoreProject.API.CQRS.Commands.AboutCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;

namespace CoreProject.API.CQRS.Handlers.AboutHandler
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, bool>
    {
        private readonly IAboutService _aboutService;

        public UpdateAboutCommandHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<bool> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            return await _aboutService.Update(new About
            {
                AboutID = request.AboutID,
                Address = request.Address,
                Age = request.Age,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Mail = request.Mail,
                Phone = request.Phone,
                Title = request.Title
            });
        }
    }
}
