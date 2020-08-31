using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExtraSupport.Domain.Commands;

namespace ExtraSupport.Domain.CommandHandler
{
    public class AddTicketHandler:CommandHandler<TicketAggregate,TicketId,AddTicket>
    {
        public override Task ExecuteAsync(TicketAggregate aggregate, AddTicket command, CancellationToken cancellationToken)
        {
            aggregate.AddTicket(command.Ticket);
            return Task.CompletedTask;
        }
    }
}
