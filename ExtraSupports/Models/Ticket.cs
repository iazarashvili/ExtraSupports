using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSupports.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
