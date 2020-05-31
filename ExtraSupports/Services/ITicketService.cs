using ExtraSupports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Services
{
    public interface ITicketService
    {
        Task<Ticket> HandleReceivedTicketAsync(Ticket receivedTicket);
        Task<List<Ticket>> GetAllTickets();
        void UpdateTicketStatus(Guid ticketId);
    }
}
