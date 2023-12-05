namespace CoreProject.API.CQRS.Results.MessageResult
{
    public class GetLast3MessageQueryResult
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
