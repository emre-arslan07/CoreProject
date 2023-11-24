using CoreProject.API.CQRS.Results.AppUserResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AppUserQuery
{
    public class AppUserLoginQuery:IRequest<AppUserLoginQueryResult>
    {
        public AppUserLoginQuery(string username,string password) 
        { 
        this.UserName = username;
            this.Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
