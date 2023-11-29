namespace CoreProject.API.CQRS.Results.AnnouncementResult
{
    public class GetLast5AnnouncementQueryResult
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
    }
}
