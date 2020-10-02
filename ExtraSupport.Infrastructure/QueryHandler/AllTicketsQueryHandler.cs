using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.MongoDB.ReadStores;
using EventFlow.Queries;
using ExtraSupport.Application.ReadModels;
using ExtraSupport.Domain.Queries;
using MongoDB.Driver;

namespace ExtraSupport.Infrastructure.QueryHandler
{
    public class AllTicketsQueryHandler : MongoDBQueryHandlerBase<AllTicketsQuery,List<TicketReadModel>>
    {
        public AllTicketsQueryHandler(IMongoDatabase mongoDatabase, IReadModelDescriptionProvider descriptionProvider) 
            : base(mongoDatabase, descriptionProvider)
        {
        }

        public override async Task<List<TicketReadModel>> ExecuteQueryAsync(AllTicketsQuery query, CancellationToken cancellationToken)
        {
            var result = (await GetCollection<TicketReadModel>().FindAsync(x => x.Id != null && !x.Deleted)).ToList();
            return result;
        }
    }
}
