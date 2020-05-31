using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExtraSupports.Models;
using ExtraSupports.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExtraSupports.Pages.Tickets
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string CloseComment { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Description { get; set; }
        private readonly ITicketService TicketService;
        public List<Ticket> AllTickets { get; set; } = new List<Ticket>();

        public IndexModel(ITicketService ticketService)
        {
            TicketService = ticketService;
        }
       public void OnGet()
        {
            AllTickets = TicketService.GetAllTickets().Result;
        }

        public async Task<IActionResult> OnPostSendBugTicket()
        {
            
            if (ModelState.IsValid)
            {
                //createBugTicket:
                var ticket = new Ticket()
                {
                    TicketId = Guid.NewGuid(),
                    Title = Title,
                    Description = Description,
                    PhoneNumber=PhoneNumber,
                    Email=Email

                };

                await TicketService.HandleReceivedTicketAsync(ticket);

                return RedirectToPage("/Tickets/Index");
            }

            return this.Page();
        }


        public async Task<IActionResult> OnPostChangeTicketStatus()
        {

            if (ModelState.IsValid)
            {
                //ChangeTicketStatus:
                var ticketId = Request.Form["TicketId"];
                Guid newGuid = Guid.Parse(ticketId);
                TicketService.UpdateTicketStatus(newGuid);

                return RedirectToPage("/Tickets/Index");
            }

            return this.Page();
        }
    }
}
