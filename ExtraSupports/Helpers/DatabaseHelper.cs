using ExtraSupports.Enums;
using ExtraSupports.Models;
using LiteDB;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public int getActiveTicketCount()
        {
            return allTickets.FindAll().Where(x => x.TicketState == TicketState.Active).Count();
        }

        public ICollection<Ticket> GetAllTickets()
        {
           
            return allTickets.FindAll().ToList();

        }

        public void RemoveItem(Guid ticket)
        {
            allTickets.Delete(ticket);
        }

       

      

        public void CloseTicket(Guid ticketId,string closeComment)
        {
            var ticket = allTickets.Find(x => x.TicketId == ticketId).FirstOrDefault();
            if (ticket != null)
            {
                ticket.CloseComment = closeComment;
                ticket.TicketState = TicketState.Finished;
                allTickets.Update(ticket);
            }
        }
    }
}
