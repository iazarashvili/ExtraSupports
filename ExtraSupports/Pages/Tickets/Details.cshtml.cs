using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExtraSupports.Data;
using ExtraSupports.Models;

namespace ExtraSupports.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly ExtraSupports.Data.ExtraSupportsContext _context;

        public DetailsModel(ExtraSupports.Data.ExtraSupportsContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.TicketId == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
