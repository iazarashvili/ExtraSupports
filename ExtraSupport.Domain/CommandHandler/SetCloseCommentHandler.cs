using EventFlow.Commands;
using ExtraSupport.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraSupport.Domain.CommandHandler
{
    public class SetCloseCommentHandler : CommandHandler<MainAggregate, TicketId, SetCloseComment>
    {
        public override Task ExecuteAsync(MainAggregate aggregate, SetCloseComment command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
