using CoreProject.API.CQRS.Results.AppUserResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AppUserQuery
{
    public class GetUserFromUsernameQuery:IRequest<GetUserFromUsernameQueryResult>
    {
         public GetUserFromUsernameQuery(string username,string password) 
        { 
            this.UserName = username;
            this.Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
