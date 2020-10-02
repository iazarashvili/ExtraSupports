using EventFlow.Commands;
using ExtraSupport.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraSupport.Domain.CommandHandler
{
    public class CloseTicketHandler : CommandHandler<MainAggregate, TicketId, CloseTicket>
    {
        public override Task ExecuteAsync(MainAggregate aggregate, CloseTicket command, CancellationToken cancellationToken)
        {
            aggregate.CloseTicket(command.ClosingComment);
            return Task.CompletedTask;
        }
    }
}
