using ExtraSupports.Helpers;
using ExtraSupports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Services
{
    public class TicketService : ITicketService
    {
        private readonly IDatabaseHelper DatabaseHelper;
        public TicketService(IDatabaseHelper databaseHelper)
        {
            DatabaseHelper = databaseHelper;
        }

        public void CloseTicket(Guid ticketId, string closeComment)
        {
            DatabaseHelper.CloseTicket(ticketId, closeComment);
        }

        public int getActiveTicketsCount()
        {
           return  DatabaseHelper.getActiveTicketCount();
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return DatabaseHelper.GetAllTickets().ToList();
        }

        private  async Task<List<Ticket>> GetData()
        {
            return  DatabaseHelper.GetAllTickets().ToList();
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count;

        }

        public async Task<List<Ticket>> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            var data = await GetData();
            return data.OrderBy(d => d.TicketId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<Ticket> HandleReceivedTicketAsync(Ticket receivedTicket)
        {
            receivedTicket.CreateDate = DateTime.Now;
            DatabaseHelper.AddToDatabase(receivedTicket);
            return new Ticket(receivedTicket);
        }

        public void RemoveTisket(Guid ticket)
        {
             DatabaseHelper.RemoveItem(ticket);
        }

        
    }
}
