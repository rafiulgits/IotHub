using IotHub.DataTransferObjects.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotHub.Services.User
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserUpsertDto user);
        Task<UserDto> GetUserAsync(string id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> UpdateAsync(UserUpsertDto user);
        Task<bool> DeleteAsync(string id);
        Task<bool> SetActive(string id);
        Task<bool> SetDeactive(string id);
        Task<bool> SetConnected(string id);
        Task<bool> SetDisconnected(string id);
        Task<bool> AddLog(string id);
    }
}
