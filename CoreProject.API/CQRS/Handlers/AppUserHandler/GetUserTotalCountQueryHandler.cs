using CoreProject.API.CQRS.Queries.AppUserQuery;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.API.CQRS.Handlers.AppUserHandler
{
    public class GetUserTotalCountQueryHandler : IRequestHandler<GetUserTotalCountQuery, int>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserTotalCountQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> Handle(GetUserTotalCountQuery request, CancellationToken cancellationToken)
        {
            return  _userManager.Users.Count();
        }
    }
}
