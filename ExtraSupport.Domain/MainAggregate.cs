﻿using System.Collections.Generic;
using System.ServiceModel.Channels;
using EventFlow.Aggregates;
using ExtraSupport.Domain.ValueObjects;

namespace ExtraSupport.Domain
{
    public class MainAggregate:AggregateRoot<MainAggregate,TicketId>,
        IApply<TicketAdded>
    {
        public Ticket Ticket { get; set; }

        public MainAggregate(TicketId id) : base(id)
        {
        }

        public void Apply(TicketAdded aggregateEvent)
        {
            Ticket = aggregateEvent.Ticket;
        }

        public void AddTicket(Ticket ticket)
        {
            Emit(new TicketAdded(ticket));
        }
    }
}