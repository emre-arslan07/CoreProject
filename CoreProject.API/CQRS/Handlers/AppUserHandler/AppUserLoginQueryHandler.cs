using CoreProject.API.CQRS.Queries.AppUserQuery;
using CoreProject.API.CQRS.Results.AppUserResult;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.AppUserHandler
{
    public class AppUserLoginQueryHandler : IRequestHandler<AppUserLoginQuery, AppUserLoginQueryResult>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

    
        public AppUserLoginQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUserLoginQueryResult> Handle(AppUserLoginQuery request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, true);
           if (result.Succeeded)
            {
                var query=await _userManager.FindByNameAsync(request.UserName);
                return  new AppUserLoginQueryResult
                {
                    Id = query.Id,
                    Name = query.Name,
                    Surname = query.Surname,
                    Email = query.Email,
                    UserName = query.UserName,
                    ImageUrl = query.ImageUrl
                };
            }
            else
            {
                return null;
            }
            
        }
    }
}
