using CoreProject.API.CQRS.Results.AdminMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AdminMessageQuery
{
    public class GetAdminMessageInboxQuery:IRequest<List<GetAdminMessageInboxQueryResult>>
    {
        public GetAdminMessageInboxQuery(string mail)
        {
            this.Mail = mail;
        }
        public string Mail { get; set; }
    }
}
