using System.Collections.Generic;
using EventFlow.Queries;
using ExtraSupport.Application.ReadModels;

namespace ExtraSupport.Domain.Queries
{
    public class AllTicketsQuery : IQuery<List<TicketReadModel>>
    {
    }
}
