using CoreProject.API.CQRS.Commands.AppUserCommand;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.AppUserHandler
{
    public class AppUserRegisterCommandHandler : IRequestHandler<AppUserRegisterCommand,bool>
    {       
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserRegisterCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(AppUserRegisterCommand request, CancellationToken cancellationToken)
        {
          var result=await _userManager.CreateAsync(new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                Email = request.Mail
            },request.Password);

           
            if (result.Succeeded)
            {
                AppUser user =await _userManager.FindByEmailAsync(request.Mail);

                if (!await _roleManager.RoleExistsAsync("Writer"))
                {
                    await _roleManager.CreateAsync(new AppRole
                    {                       
                        Name="Writer"
                    });
                }
                await _userManager.AddToRoleAsync(user, "Writer");
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
