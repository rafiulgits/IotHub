using System.Threading.Tasks;

namespace IotHub.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public Task<DomainModels.User> CreateAsync(DomainModels.User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.User> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DomainModels.User> UpdateAsync(DomainModels.User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
