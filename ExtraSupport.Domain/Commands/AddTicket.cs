using EventFlow.Commands;
using EventFlow.Core;
using ExtraSupport.Domain.ValueObjects;

namespace ExtraSupport.Domain.Commands
{
    public class AddTicket:Command<TicketAggregate,TicketId>
    {
        public Ticket Ticket { get; set; }

       
        public AddTicket(TicketId aggregateId, Ticket ticket) : base(aggregateId)
        {
            Ticket = ticket;
        }
    }
}
