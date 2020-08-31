using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExtraSupports.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using EventFlow;
using EventFlow.Queries;
using ExtraSupport.Application;
using ExtraSupport.Domain;
using ExtraSupport.Domain.Commands;
using ExtraSupports.Services;

namespace ExtraSupports.Pages.Tickets
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

       public ExtraSupportApplication Application { get; set; }

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

        public int FinishedCount { get; set; }

        public IndexModel(ExtraSupportApplication application)
        {
            Application = application;
        }

        public async Task OnGetAsync(string searchString)
        {
            var tickets = await Application.GetAllTickets();

            
            //tickets.Select(x => AllTickets.Add(x.Tickets.Select(y => new Ticket(y.TicketId, y.Title, y.Description, y.PhoneNumber, y.CloseComment, y.Email))));
            if (!String.IsNullOrEmpty(searchString))
            {
                AllTickets = AllTickets.Where(s => s.Title.Contains(searchString)).ToList();
                TicketCount = TicketService.getActiveTicketsCount();
                FinishedCount = TicketService.getFinishedTicketsCount();
                Count = await TicketService.GetCount();
            }
            else
            {
                FinishedCount = TicketService.getFinishedTicketsCount();
                TicketCount = TicketService.getActiveTicketsCount();
                Count = await TicketService.GetCount();
            }
          
        }
     
        public async Task<IActionResult> OnPostSendBugTicket()
        {
            
            if (ModelState.IsValid)
            {
                var identity = TicketId.New;
                var command = new AddTicket(identity, new ExtraSupport.Domain.ValueObjects.Ticket(CloseComment, Title, PhoneNumber, Email, Description));
                await  Application.PublishAsync(command);

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
