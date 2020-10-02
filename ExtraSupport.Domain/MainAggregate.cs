using System.Collections.Generic;
using System.ServiceModel.Channels;
using EventFlow.Aggregates;
using ExtraSupport.Domain.Events;
using ExtraSupport.Domain.ValueObjects;
using ExtraSupports.Enums;

namespace ExtraSupport.Domain
{
    public class MainAggregate:AggregateRoot<MainAggregate,TicketId>,
        IApply<TicketAdded>,
        IApply<TicketClosed>
    {
        public Ticket Ticket { get; set; }

        public MainAggregate(TicketId id) : base(id)
        {
        }

        public void Apply(TicketAdded aggregateEvent)
        {
            Ticket = aggregateEvent.Ticket;
        }

        public void Apply(TicketClosed aggregateEvent)
        {
            this.Ticket.CloseComment = aggregateEvent.CloseComment;
            Ticket.TicketState = TicketState.Finished;
        }

        public void Apply(TicketDeleted aggregateEvent)
        {
            this.Ticket.Deleted = true;
        }

        public void AddTicket(Ticket ticket)
        {
            Emit(new TicketAdded(ticket));
        }

        public void CloseTicket (string closeComment)
        {
            Emit(new TicketClosed(closeComment));
        }

        public void TicketDeleted()
        {
            Emit(new TicketDeleted());
        }

    }
}
