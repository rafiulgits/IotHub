using IotHub.DB.Mongo;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace IotHub.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<DomainModels.User> collection;
        public UserRepository(MongoDbContext mongoDbContext)
        {
            collection = mongoDbContext.Database.GetCollection<DomainModels.User>("user");
        }

        public async Task<DomainModels.User> CreateAsync(DomainModels.User entity)
        {
            await collection.InsertOneAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DomainModels.User> GetAsync(string id)
        {
            var cursor = await collection.FindAsync(doc => doc.Id == id);
            return cursor.FirstOrDefault();
        }

        public Task<DomainModels.User> UpdateAsync(DomainModels.User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
