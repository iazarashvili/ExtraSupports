using EventFlow.Commands;

namespace ExtraSupport.Domain.Commands
{
    public class CloseTicket: Command<MainAggregate, TicketId>
    {
        public string ClosingComment { get; }

        public CloseTicket(TicketId aggregateId , string closeComment) : base (aggregateId)
        {
            this.ClosingComment = closeComment;
        }
    }
}
