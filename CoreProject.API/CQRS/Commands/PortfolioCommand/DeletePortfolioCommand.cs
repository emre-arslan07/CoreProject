using MediatR;

namespace CoreProject.API.CQRS.Commands.PortfolioCommand
{
    public class DeletePortfolioCommand:IRequest<bool>
    {
        public DeletePortfolioCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
