using System.Threading.Tasks;

namespace IotHub.Repositories.Profile
{
    public interface IProfileRepository : IBaseRepository<DomainModels.Profile>
    {
        Task<DomainModels.Profile> GetByUserIdAsync(string userId);
        Task<bool> AddSubscription(string id, DomainModels.Subscription subscription);
        Task<bool> RemoveSubscription(string id, DomainModels.Subscription subscription);
    }
}
