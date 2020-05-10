using IotHub.Common.Exceptions;
using IotHub.DB.Mongo;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Linq;
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

        public async Task<bool> AddLog(string id, DateTime dateTime)
        {
            var filter = Builders<DomainModels.User>.Filter.Eq(u => u.Id, id);
            var update = Builders<DomainModels.User>.Update.Push(u => u.Logs, dateTime);
            // TODO: update LastConnected
            var result = await collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<DomainModels.User> CreateAsync(DomainModels.User entity)
        {
            entity.Logs = new System.Collections.Generic.List<DateTime>();
            await collection.InsertOneAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var cursor = await collection.FindAsync(p => true);
            return cursor.ToList();
        }

        public IQueryable<DomainModels.User> GetAsQueryable()
        {
            return collection.AsQueryable();
        }

        public async Task<DomainModels.User> GetAsync(string id)
        {
            var cursor = await collection.FindAsync(doc => doc.Id == id);
            var user = cursor.FirstOrDefault();
            if(user == null)
            {
                throw new NotFoundException($"No user exists with ID {id}");
            }
            return user;
        }

        public async Task<DomainModels.User> GetByNameAsync(string name)
        {
            var cursor = await collection.FindAsync(doc => doc.Name == name);
            var user = cursor.FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException($"No user exists with name {name}");
            }
            return user;
        }

        public async Task<bool> SetActiveStatus(string id, bool status)
        {
            var filter = Builders<DomainModels.User>.Filter.Eq(u => u.Id, id);
            var update = Builders<DomainModels.User>.Update.Set(u => u.IsActive, status);
            var result = await collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> SetConnectionStatus(string id, bool status)
        {
            var filter = Builders<DomainModels.User>.Filter.Eq(u => u.Id, id);
            var update = Builders<DomainModels.User>.Update.Set(u => u.IsConnected, status);
            var result = await collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public Task<DomainModels.User> UpdateAsync(DomainModels.User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
