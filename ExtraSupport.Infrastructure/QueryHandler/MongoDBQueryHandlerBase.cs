using System.Threading;
using System.Threading.Tasks;
using EventFlow.MongoDB.ReadStores;
using EventFlow.Queries;
using MongoDB.Driver;

namespace ExtraSupport.Infrastructure.QueryHandler
{
    public abstract class MongoDBQueryHandlerBase<TQuery, TResult>: IQueryHandler<TQuery, TResult>
    where TQuery: IQuery<TResult>
    {
        private readonly IMongoDatabase mongoDatabase;
        private IReadModelDescriptionProvider descriptionProvider;

        protected MongoDBQueryHandlerBase(IMongoDatabase mongoDatabase, IReadModelDescriptionProvider descriptionProvider)
        {
            this.mongoDatabase = mongoDatabase;
            this.descriptionProvider = descriptionProvider;
        }
        protected IMongoCollection<TReadModel> GetCollection<TReadModel>() where TReadModel : IMongoDbReadModel
        {
            var collectionName = descriptionProvider.GetReadModelDescription<TReadModel>().RootCollectionName;
            return mongoDatabase.GetCollection<TReadModel>(collectionName.Value);
        }

        public abstract Task<TResult> ExecuteQueryAsync(TQuery query, CancellationToken cancellationToken);

    }
}
