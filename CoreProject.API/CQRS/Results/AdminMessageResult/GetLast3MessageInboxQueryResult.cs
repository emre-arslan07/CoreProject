namespace CoreProject.API.CQRS.Results.AdminMessageResult
{
    public class GetLast3MessageInboxQueryResult
    {
        public int WriterMessageID { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
