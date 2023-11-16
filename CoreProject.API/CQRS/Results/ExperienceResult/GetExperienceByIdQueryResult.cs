namespace CoreProject.API.CQRS.Results.ExperienceResult
{
    public class GetExperienceByIdQueryResult
    {
        public int ExprerienceID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
