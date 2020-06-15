using ExtraSupports.Enums;
using ExtraSupports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Helpers
{
    public interface IDatabaseHelper
    {
        void AddToDatabase(Ticket ticket);
        void CloseTicket(Guid ticketID,string closeComment);
        ICollection<Ticket> GetAllTickets();
        void RemoveItem(Guid ticket);
        int getActiveTicketCount();
        int getFinishedTicketsCount();

    }
}
