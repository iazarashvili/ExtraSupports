using System;
using EventFlow.ValueObjects;

namespace ExtraSupport.Domain.ValueObjects
{
    public class Ticket:ValueObject
    {
        public Guid TicketId { get; set; }
        public string CloseComment { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        public Ticket(Guid ticketId,string closeComment, string title, string phoneNumber, string email, string description)
        {
            TicketId = ticketId;
            CloseComment = closeComment;
            Title = title;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
        }
    }


}
