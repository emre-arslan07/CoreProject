using CoreProject.API.CQRS.Commands.AppUserCommand;
using CoreProject.BLL.Abstract;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.AppUserHandler
{
    public class AppUserRegisterCommandHandler : IRequestHandler<AppUserRegisterCommand>
    {
        //private readonly IAppUserService _appUserService;

        //public AppUserRegisterCommandHandler(IAppUserService appUserService)
        //{
        //    _appUserService = appUserService;
        //}

        //public async Task<Unit> Handle(AppUserRegisterCommand request, CancellationToken cancellationToken)
        //{
        //    await _appUserService.AddAsync(new AppUser
        //    {
        //        Name = request.Name,
        //        Surname = request.Surname,
        //        UserName = request.UserName,
        //        PasswordHash=request.Password,
        //        Email=request.Mail,
        //        ImageUrl=request.ImageUrl
        //    });
        //    return Unit.Value;
        //}
        private readonly UserManager<AppUser> _userManager;

        public AppUserRegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AppUserRegisterCommand request, CancellationToken cancellationToken)
        {
            await _userManager.CreateAsync(new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                Email = request.Mail
            },request.Password);
            return Unit.Value;
        }
    }
}
