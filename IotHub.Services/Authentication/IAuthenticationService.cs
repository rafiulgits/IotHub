using IotHub.DataTransferObjects.User;
using System.Threading.Tasks;

namespace IotHub.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserDto> Authenticate(string username, string password);
    }
}
