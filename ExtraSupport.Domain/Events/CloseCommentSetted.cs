using EventFlow.Aggregates;

namespace ExtraSupport.Domain.Events
{
    public class CloseCommentSetted : AggregateEvent<MainAggregate, TicketId>
    {
        public string CloseComment { get; }
        public CloseCommentSetted(string closeComment)
        {
            this.CloseComment = closeComment;
        }
    }
}
