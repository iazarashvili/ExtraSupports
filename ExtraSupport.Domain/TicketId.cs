using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Core;

namespace ExtraSupport.Domain
{
    public class TicketId : Identity<TicketId>
    {
        public TicketId(string value) : base(value)
        {
        }
    }
}
