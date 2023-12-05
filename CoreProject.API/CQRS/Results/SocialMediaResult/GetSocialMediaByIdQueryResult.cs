namespace CoreProject.API.CQRS.Results.SocialMediaResult
{
    public class GetSocialMediaByIdQueryResult
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
    }
}
