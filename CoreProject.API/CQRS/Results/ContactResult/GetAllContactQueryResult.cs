namespace CoreProject.API.CQRS.Results.ContactResult
{
    public class GetAllContactQueryResult
    {
        public int ContactID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
