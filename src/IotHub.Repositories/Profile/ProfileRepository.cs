using IotHub.Common.Exceptions;
using IotHub.DB.Mongo;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<bool> AddSubscription(string id, DomainModels.Subscription subscription)
        {
            var filter = Builders<DomainModels.Profile>.Filter.Eq(p => p.Id, id);
            var update = Builders<DomainModels.Profile>.Update.Push(p => p.Subscriptions, subscription);
            var result = await collection.UpdateOneAsync(filter, update);
            if (!result.IsAcknowledged && result.MatchedCount == 0)
            {
                throw new BadRequestException("No profile found to update");
            }
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<DomainModels.Profile> CreateAsync(DomainModels.Profile entity)
        {
            entity.Subscriptions = new List<DomainModels.Subscription>();
            await collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<DomainModels.Profile>.Filter.Eq(p => p.Id, id);
            var result = await collection.DeleteOneAsync(filter);
            if(!result.IsAcknowledged)
            {
                throw new BadRequestException("No profile found with this id");
            }
            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var cursor = await collection.FindAsync(p => true);
            return cursor.ToList();
        }

        public IQueryable<DomainModels.Profile> GetAsQueryable()
        {
            return collection.AsQueryable();
        }

        public async Task<DomainModels.Profile> GetAsync(string id)
        {
            var cursor = await collection.FindAsync(p => p.Id == id);
            var profile =  cursor.FirstOrDefault();
            if(profile == null)
            {
                throw new NotFoundException("No profile found with this id");
            }
            return profile;
        }

        public async Task<DomainModels.Profile> GetByUserIdAsync(string userId)
        {
            var cursor = await collection.FindAsync(p => p.UserId == userId);
            var profile = cursor.FirstOrDefault();
            if (profile == null)
            {
                throw new NotFoundException("No profile found with this id");
            }
            return profile;
        }

        public async Task<bool> RemoveSubscription(string id, DomainModels.Subscription subscription)
        {
            var filter = Builders<DomainModels.Profile>.Filter.Eq(p => p.Id, id);
            var update = Builders<DomainModels.Profile>.Update.PullFilter(p => p.Subscriptions,
                                                                          s => s.Id == subscription.Id);
            var result = await collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<DomainModels.Profile> UpdateAsync(DomainModels.Profile entity)
        {
            var filter = Builders<DomainModels.Profile>.Filter.Eq(p => p.Id, entity.Id);
            var update = Builders<DomainModels.Profile>.Update.Set(p => p.DisplayName, entity.DisplayName)
                                                              .Set(p => p.Type, entity.Type);
            var result = await collection.UpdateOneAsync(filter, update);
            if(!result.IsAcknowledged)
            {
                throw new InternalException($"Failed to update profile {entity.Id}");
            }
            if (result.MatchedCount == 0)
            {
                throw new BadRequestException("Profile is not available in database");
            }
            if(result.ModifiedCount == 0)
            {
                throw new InternalException($"Failed to update profile {entity.Id}");
            }
            return entity;
        }
    }
}
