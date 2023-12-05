using CoreProject.API.CQRS.Queries.AdminMessageQuery;
using CoreProject.API.CQRS.Results.AdminMessageResult;
using CoreProject.BLL.Abstract;
using CoreProject.DAL.Concrete;
using CoreProject.Entity.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.API.CQRS.Handlers.AdminMessage
{
    public class GetLast3MessageInboxQueryHandler : IRequestHandler<GetLast3MessageInboxQuery, List<GetLast3MessageInboxQueryResult>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWriterMessageService _writerMessageService;

        public GetLast3MessageInboxQueryHandler(UserManager<AppUser> userManager, IWriterMessageService writerMessageService)
        {
            _userManager = userManager;
            _writerMessageService = writerMessageService;
        }

        public async Task<List<GetLast3MessageInboxQueryResult>> Handle(GetLast3MessageInboxQuery request, CancellationToken cancellationToken)
        {            
            var users=await _userManager.Users.ToListAsync();
            var messages =await _writerMessageService.GetWhere(x => x.WriterMessageID >= 1).ToListAsync();
            
            var query = (from m in messages
                        join u in users on m.Sender equals u.Email
                        where m.Receiver == request.Mail 
                        select new GetLast3MessageInboxQueryResult
                        {
                            Date = m.Date,
                            ImageUrl = u.ImageUrl,
                            SenderName = m.SenderName,
                            Subject = m.Subject,
                            WriterMessageID = m.WriterMessageID
                        }).OrderByDescending(x=>x.WriterMessageID).Take(3);
            return query.ToList();
        }
    }
}
