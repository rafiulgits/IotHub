using System.Threading.Tasks;

namespace IotHub.Repositories.Profile
{
    public interface IProfileRepository : IBaseRepository<DomainModels.Profile>
    {
        Task<DomainModels.Profile> GetByUserIdAsync(string userId);
    }
}
