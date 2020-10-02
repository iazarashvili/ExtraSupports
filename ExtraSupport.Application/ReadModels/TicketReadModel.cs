using System;
using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.ReadStores;
using ExtraSupport.Domain;
using ExtraSupport.Domain.Events;
using ExtraSupport.Domain.ValueObjects;
using ExtraSupports.Enums;

namespace ExtraSupport.Application.ReadModels
{
    public class TicketReadModel : IMongoDbReadModel,
        IAmReadModelFor<MainAggregate,TicketId,TicketAdded>,
        IAmReadModelFor<MainAggregate, TicketId, TicketClosed>,
        IAmReadModelFor<MainAggregate, TicketId, TicketDeleted>

    {
        public string Id { get; private set; }
        public long? Version { get; set; }
        public bool Deleted { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CloseComment { get; set; }
        public TicketState TicketState { get; set; } 
        public string Email { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public void Apply(IReadModelContext context, IDomainEvent<MainAggregate, TicketId, TicketAdded> domainEvent)
        {
            var ticket = domainEvent.AggregateEvent.Ticket;
            Id = ticket.TicketId.ToString();
            Deleted = false;
            Title = ticket.Title;
            Description = ticket.Description;
            PhoneNumber = ticket.PhoneNumber;
            CloseComment = ticket.CloseComment;
            TicketState = ticket.TicketState;
            Email = ticket.Email;
        }

        public void Apply(IReadModelContext context, IDomainEvent<MainAggregate, TicketId, TicketClosed> domainEvent)
        {
            var comment = domainEvent.AggregateEvent.CloseComment;
            CloseComment = comment;
            TicketState = TicketState.Finished;
        }

        public void Apply(IReadModelContext context, IDomainEvent<MainAggregate, TicketId, TicketDeleted> domainEvent)
        {
            Deleted = true;
        }

    }
}
