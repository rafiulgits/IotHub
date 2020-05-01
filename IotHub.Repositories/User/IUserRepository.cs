using System.Threading.Tasks;

namespace IotHub.Repositories.User
{
    public interface IUserRepository : IBaseRepository<DomainModels.User>
    {
        Task<DomainModels.User> GetByNameAsync(string name);
    }
}
