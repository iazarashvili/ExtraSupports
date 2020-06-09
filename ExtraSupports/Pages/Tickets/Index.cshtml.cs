using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExtraSupports.Models;
using ExtraSupports.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ExtraSupports.Pages.Tickets
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

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
        public List<Ticket> AllTickets { get; set; } 
        public int TicketCount { get; set; }

        public IndexModel(ITicketService ticketService)
        {
            TicketService = ticketService;
        }

        public async Task OnGetAsync(string searchString)
        {
            AllTickets = await TicketService.GetPaginatedResult(CurrentPage, PageSize);
           
            if (!String.IsNullOrEmpty(searchString))
            {
                AllTickets = AllTickets.Where(s => s.Title.Contains(searchString)).ToList();
                TicketCount = TicketService.getActiveTicketsCount();
                Count = await TicketService.GetCount();
            }
            else
            {
                TicketCount = TicketService.getActiveTicketsCount();
                Count = await TicketService.GetCount();
            }
          
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

        public async Task<IActionResult> OnPostDeleteTicket()
        {
            if (ModelState.IsValid)
            {
                var ticketId = Request.Form["TicketId"];
                Guid newguid = Guid.Parse(ticketId);
                TicketService.RemoveTisket(newguid);
                return RedirectToPage("/Tickets/Index");
            }
            return this.Page();
        }

        public async Task<IActionResult> OnPostCloseTicket()
        {
            if (ModelState.IsValid)
            {
                var ticketId = Request.Form["closeTicketId"];
                Guid newguid = Guid.Parse(ticketId);
                TicketService.CloseTicket(newguid, CloseComment);
                return RedirectToPage("/Tickets/Index");
            }
            return this.Page();
        }

    }
}
