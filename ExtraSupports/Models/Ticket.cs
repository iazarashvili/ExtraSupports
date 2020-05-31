﻿using ExtraSupports.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public TicketState TicketState { get; set; } = TicketState.Active;

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? DateFinished { get; set; }
        public Ticket()
        {
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
            DateFinished = ticket.DateFinished;
        }

    }
}
