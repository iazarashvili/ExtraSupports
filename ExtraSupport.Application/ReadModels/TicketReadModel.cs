using System;
using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.ReadStores;
using ExtraSupport.Domain;
using ExtraSupport.Domain.ValueObjects;
using ExtraSupports.Enums;

namespace ExtraSupport.Application.ReadModels
{
    public class TicketReadModel : IMongoDbReadModel,
        IAmReadModelFor<MainAggregate,TicketId,TicketAdded>
    {
        public string Id { get; private set; }
        public long? Version { get; set; }

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
            Title = ticket.Title;
            Description = ticket.Description;
            PhoneNumber = ticket.PhoneNumber;
            CloseComment = ticket.CloseComment;
            TicketState = ticket.TicketState;
            Email = ticket.Email;
        }
    }
}
