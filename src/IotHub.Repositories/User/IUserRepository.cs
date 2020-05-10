using System;
using System.Threading.Tasks;

namespace IotHub.Repositories.User
{
    public interface IUserRepository : IBaseRepository<DomainModels.User>
    {
        Task<DomainModels.User> GetByNameAsync(string name);
        Task<bool> AddLog(string id, DateTime dateTime);
        Task<bool> SetConnectionStatus(string id, bool status);
        Task<bool> SetActiveStatus(string id, bool status);
    }
}
