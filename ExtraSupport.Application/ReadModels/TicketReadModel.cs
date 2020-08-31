using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.ReadStores;
using ExtraSupport.Domain;
using ExtraSupport.Domain.ValueObjects;

namespace ExtraSupport.Application.ReadModels
{
    public class TicketReadModel:IMongoDbReadModel,IAmReadModelFor<TicketAggregate,TicketId,TicketAdded>
    {
        public string Id { get; }
        public long? Version { get; set; }

        public List<Ticket> Tickets { get; set; }
        public void Apply(IReadModelContext context, IDomainEvent<TicketAggregate, TicketId, TicketAdded> domainEvent)
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
            Tickets.Add(domainEvent.AggregateEvent.Ticket);
        }
    }
}
