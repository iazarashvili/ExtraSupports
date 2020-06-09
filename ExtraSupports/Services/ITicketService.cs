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
        Task<List<Ticket>> GetPaginatedResult(int currentPage, int pageSize = 10);
        void CloseTicket(Guid ticketId,string closeComment);
        void RemoveTisket(Guid ticket);
        int getActiveTicketsCount();

        Task<int> GetCount();
    }
}
