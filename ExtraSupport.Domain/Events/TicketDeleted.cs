using EventFlow.Aggregates;

namespace ExtraSupport.Domain.Events
{
    public class TicketDeleted: AggregateEvent<MainAggregate, TicketId>
    {
    }
}
