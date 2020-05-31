using ExtraSupports.Enums;
using ExtraSupports.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public readonly ILiteCollection<Ticket> allTickets;
        private readonly LiteDatabase context;

        public DatabaseHelper()
        {
            context = new LiteDatabase("ticketDb - V2.db");
            allTickets = context.GetCollection<Ticket>("allTickets");
        }
        public void AddToDatabase(Ticket ticket)
        {
            allTickets.Insert(ticket);
        }



        public ICollection<Ticket> GetAllTickets()
        {
            return allTickets.FindAll().ToList();

        }

        public void RemoveItem(Ticket ticket)
        {
            allTickets.Delete(ticket.TicketId);
        }

        public void UpdateItem(Guid ticketId)
        {
            var ticket = allTickets.Find(x => x.TicketId == ticketId).FirstOrDefault();
            if(ticket != null)
            {
                ticket.TicketState = TicketState.Finished;
               
                allTickets.Update(ticket);
            }
        }
    }
}
