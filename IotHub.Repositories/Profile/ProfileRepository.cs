using IotHub.DB.Mongo;
using IotHub.DomainModels;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Repositories.Profile
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IMongoCollection<DomainModels.Profile> collection;

        public ProfileRepository(MongoDbContext mongoDbContext)
        {
            collection = mongoDbContext.Database.GetCollection<DomainModels.Profile>("profile");    
        }
        public Task<bool> AddSubscription(string id, Subscription subscription)
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.Profile> CreateAsync(DomainModels.Profile entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<DomainModels.Profile> GetAsQueryable()
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.Profile> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.Profile> GetByUserIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveSubscription(string id, Subscription subscription)
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.Profile> UpdateAsync(DomainModels.Profile entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
