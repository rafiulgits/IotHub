using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Repositories.Profile
{
    public class ProfileRepository : IProfileRepository
    {
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

        public Task<DomainModels.Profile> UpdateAsync(DomainModels.Profile entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
