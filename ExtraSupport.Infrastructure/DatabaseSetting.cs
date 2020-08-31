namespace ExtraSupport.Infrastructure
{
    public class DatabaseSetting
    {
        public string EventStoreUri { get; set; }
        public string Production_EventStoreUri { get; set; }
        public string MongoDBUri { get; set; }
        public string Production_MongoDBUri { get; set; }
        public string DatabaseReadModels { get; set; }
        public string EventstoreUser { get; set; }
        public string EventstorePW { get; set; }

        public DatabaseSetting()
        {
        }

        public DatabaseSetting(string eventStoreUri, string mongoDbUri, string databaseReadModels, string eventstoreUser,
            string eventstorePw, string productionEventStoreUri, string productionMongoDbUri)
        {
            EventStoreUri = eventStoreUri;
            MongoDBUri = mongoDbUri;
            DatabaseReadModels = databaseReadModels;
            EventstoreUser = eventstoreUser;
            EventstorePW = eventstorePw;
            Production_EventStoreUri = productionEventStoreUri;
            Production_MongoDBUri = productionMongoDbUri;
        }

        public DatabaseSetting(string eventStoreUri, string mongoDbUri, string databaseReadModels,
            string eventstoreUser,
            string eventstorePw)
        {
            EventStoreUri = eventStoreUri;
            MongoDBUri = mongoDbUri;
            DatabaseReadModels = databaseReadModels;
            EventstoreUser = eventstoreUser;
            EventstorePW = eventstorePw;
        }
    }
}
