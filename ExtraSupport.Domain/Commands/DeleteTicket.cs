using EventFlow.Commands;

namespace ExtraSupport.Domain.Commands
{
    public class DeleteTicket : Command<MainAggregate, TicketId>
    {
        public DeleteTicket(TicketId aggregateId) : base(aggregateId)
        {

        } 
    }
}
