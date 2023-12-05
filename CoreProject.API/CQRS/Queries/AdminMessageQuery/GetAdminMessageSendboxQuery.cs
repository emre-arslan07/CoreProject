using CoreProject.API.CQRS.Results.AdminMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AdminMessageQuery
{
    public class GetAdminMessageSendboxQuery:IRequest<List<GetAdminMessageSendboxQueryResult>>
    {
        public GetAdminMessageSendboxQuery(string mail)
        {
            this.Mail = mail;
        }
        public string Mail { get; set; }
    }
}
