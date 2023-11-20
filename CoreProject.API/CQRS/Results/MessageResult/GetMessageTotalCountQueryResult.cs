namespace CoreProject.API.CQRS.Results.MessageResult
{
    public class GetMessageTotalCountQueryResult
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
