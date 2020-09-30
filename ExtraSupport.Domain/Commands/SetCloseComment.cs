using EventFlow.Commands;

namespace ExtraSupport.Domain.Commands
{
    public class SetCloseComment: Command<MainAggregate, TicketId>
    {
        public string CloseComment { get; }

        public SetCloseComment(TicketId aggregateId , string closeComment) : base (aggregateId)
        {
            this.CloseComment = closeComment;
        }
    }
}
