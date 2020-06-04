using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraSupports.Models;
using ExtraSupports.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExtraSupports.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService TicketService;
        public int TicketCount { get; set; }
        public IndexModel(ILogger<IndexModel> logger,ITicketService ticketService)
        {
            _logger = logger;
            TicketService = ticketService;
        }

        public void OnGet()
        {
            TicketCount =  TicketService.getActiveTicketsCount();
        }
    }
}
