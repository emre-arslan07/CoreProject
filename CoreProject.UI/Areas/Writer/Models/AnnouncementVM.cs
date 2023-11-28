namespace CoreProject.UI.Areas.Writer.Models
{
    public class AnnouncementVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
    }
}
