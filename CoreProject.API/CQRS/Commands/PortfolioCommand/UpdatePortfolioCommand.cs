using MediatR;

namespace CoreProject.API.CQRS.Commands.PortfolioCommand
{
    public class UpdatePortfolioCommand:IRequest<bool>
    {
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string Platform { get; set; }
        public string Price { get; set; }
        public bool Status { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public int Value { get; set; }
    }
}
