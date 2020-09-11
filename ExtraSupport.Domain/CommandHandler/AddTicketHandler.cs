using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExtraSupport.Domain.Commands;

namespace ExtraSupport.Domain.CommandHandler
{
    public class AddTicketHandler:CommandHandler<MainAggregate,TicketId,AddTicket>
    {
        public override Task ExecuteAsync(MainAggregate aggregate, AddTicket command, CancellationToken cancellationToken)
        {
            aggregate.AddTicket(command.Ticket);
            return Task.CompletedTask;
        }
    }
}
