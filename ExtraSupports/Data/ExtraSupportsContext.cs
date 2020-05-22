using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExtraSupports.Models;

namespace ExtraSupports.Data
{
    public class ExtraSupportsContext : DbContext
    {
        public ExtraSupportsContext (DbContextOptions<ExtraSupportsContext> options)
            : base(options)
        {
        }

        public DbSet<ExtraSupports.Models.Ticket> Ticket { get; set; }
    }
}
