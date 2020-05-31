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
    public class IndexModel : PageModel
    {
        private readonly ExtraSupports.Data.ExtraSupportsContext _context;

        public IndexModel(ExtraSupports.Data.ExtraSupportsContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket.ToListAsync();
        }
    }
    public enum Status
    {
        ღია, დახურული
    }
}
