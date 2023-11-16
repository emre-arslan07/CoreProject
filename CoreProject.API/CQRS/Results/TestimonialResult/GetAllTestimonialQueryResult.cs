namespace CoreProject.API.CQRS.Results.TestimonialResult
{
    public class GetAllTestimonialQueryResult
    {
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string Company { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
