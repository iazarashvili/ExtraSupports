using EventFlow.Aggregates;

namespace ExtraSupport.Domain.Events
{
    public class TicketClosed : AggregateEvent<MainAggregate, TicketId>
    {
        public string CloseComment { get; }
        public TicketClosed(string closeComment)
        {
            this.CloseComment = closeComment;
        }
    }
}
