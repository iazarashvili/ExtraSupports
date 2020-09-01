using System;
using EventFlow.ValueObjects;
using ExtraSupports.Enums;

namespace ExtraSupport.Domain.ValueObjects
{
    public class Ticket:ValueObject
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CloseComment { get; set; }
        public TicketState TicketState { get; set; } = TicketState.Active;

        public string Email { get; set; }

       public DateTime CreateDate { get; set; } = DateTime.Now;

        public Ticket(Guid ticketId, string title, string description, string phoneNumber, string closeComment, string email)
        {
            TicketId = ticketId;
            Title = title;
            Description = description;
            PhoneNumber = phoneNumber;
            CloseComment = closeComment;
            Email = email;
        }

        public Ticket(Ticket ticket)
        {
            TicketId = ticket.TicketId;
            Title = ticket.Title;
            Description = ticket.Description;
            PhoneNumber = ticket.PhoneNumber;
            TicketState = ticket.TicketState;
            Email = ticket.Email;
            CreateDate = ticket.CreateDate;
            CloseComment = ticket.CloseComment;
        }

    }


}
