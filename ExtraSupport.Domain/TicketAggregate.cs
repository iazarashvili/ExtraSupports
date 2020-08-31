using System.Collections.Generic;
using System.ServiceModel.Channels;
using EventFlow.Aggregates;
using ExtraSupport.Domain.ValueObjects;

namespace ExtraSupport.Domain
{
    public class TicketAggregate:AggregateRoot<TicketAggregate,TicketId>, IApply<TicketAdded>
    {
        public List<Ticket> Tickets { get; set; }
        public TicketAggregate(TicketId id) : base(id)
        {
        }

        public void Apply(TicketAdded aggregateEvent)
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
            Tickets.Add(aggregateEvent.Ticket);
        }

        public void AddTicket(Ticket ticket)
        {
            Emit(new TicketAdded(ticket));
        }
    }
}
