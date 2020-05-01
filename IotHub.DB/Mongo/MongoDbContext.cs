using MongoDB.Driver;

namespace IotHub.DB.Mongo
{
    public class MongoDbContext
    {
        public IMongoDatabase Database;
        public MongoDbContext(MongoDbSettings settings)
        {
            IMongoClient client = new MongoClient(settings.Host);
            Database = client.GetDatabase(settings.Name);
        }
    }
}
