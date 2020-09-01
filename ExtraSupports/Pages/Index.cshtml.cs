using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExtraSupports.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       public int TicketCount { get; set; }
        public int FinishedCount { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
         
        }

        public void OnGet()
        {
            
        }
    }
}
