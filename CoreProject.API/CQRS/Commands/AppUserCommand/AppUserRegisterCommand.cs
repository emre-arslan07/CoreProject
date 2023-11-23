using MediatR;

namespace CoreProject.API.CQRS.Commands.AppUserCommand
{
    public class AppUserRegisterCommand:IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
