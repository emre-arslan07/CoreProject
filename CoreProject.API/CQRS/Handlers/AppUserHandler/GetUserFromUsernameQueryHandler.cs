using CoreProject.API.CQRS.Queries.AppUserQuery;
using CoreProject.API.CQRS.Results.AppUserResult;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.AppUserHandler
{
    
    public class GetUserFromUsernameQueryHandler : IRequestHandler<GetUserFromUsernameQuery, GetUserFromUsernameQueryResult>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

    
        public GetUserFromUsernameQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<GetUserFromUsernameQueryResult> Handle(GetUserFromUsernameQuery request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, true);
            if (result.Succeeded)
            {
                var query = await _userManager.FindByNameAsync(request.UserName);
                return new GetUserFromUsernameQueryResult
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
