namespace CoreProject.API.CQRS.Results.FeatureResult
{
    public class GetFeatureByIdQueryResult
    {
        public int FeatureID { get; set; }
        public string Header { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
