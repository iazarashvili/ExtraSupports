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

        public int getActiveTicketsCount()
        {
           return  DatabaseHelper.getActiveTicketCount();
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return DatabaseHelper.GetAllTickets().ToList();
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

        public void UpdateTicketStatus(Guid ticketId)
        {
            DatabaseHelper.UpdateItem(ticketId);
        }
    }
}
