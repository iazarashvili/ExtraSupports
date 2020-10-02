using EventFlow.Commands;
using ExtraSupport.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraSupport.Domain.CommandHandler
{
    public class DeleteTicketHandler : CommandHandler<MainAggregate, TicketId, DeleteTicket>
    {
        public override Task ExecuteAsync(MainAggregate aggregate, DeleteTicket command, CancellationToken cancellationToken)
        {
            aggregate.TicketDeleted();
            return Task.CompletedTask;
        }
    }
}
