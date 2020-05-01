using IotHub.DataTransferObjects.User;
using System.Threading.Tasks;

namespace IotHub.Services.User
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserUpsertDto user);
        Task<UserDto> GetUserAsync(string id);
        Task<UserDto> UpdateAsync(UserUpsertDto user);
        Task<bool> DeleteAsync(string id);
    }
}
