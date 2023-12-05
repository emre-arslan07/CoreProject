using CoreProject.API.CQRS.Results.AdminMessageResult;
using MediatR;

namespace CoreProject.API.CQRS.Queries.AdminMessageQuery
{
    public class GetLast3MessageInboxQuery:IRequest<List<GetLast3MessageInboxQueryResult>>
    {
        public GetLast3MessageInboxQuery(string mail)
        {
            this.Mail = mail;
        }
        public string Mail { get; set; } 
    }
}
