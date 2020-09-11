using EventFlow.Aggregates;
using ExtraSupport.Domain.ValueObjects;

namespace ExtraSupport.Domain
{
    public class TicketAdded : AggregateEvent<MainAggregate, TicketId>
    {
        public Ticket Ticket { get; set; }

        public TicketAdded(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}
