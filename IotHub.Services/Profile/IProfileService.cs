using IotHub.DataTransferObjects.Profile;
using System.Threading.Tasks;

namespace IotHub.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileDto> CreateProfileAsync(ProfileUpsertDto profile);
        Task<ProfileDto> GetProfileAsync(string id);
        Task<ProfileDto> GetProfileByUserIdAsync(string userId);
        Task<ProfileDto> UpdateProfileAsync(ProfileUpsertDto profile);
        Task<bool> DeleteProfileAsync(string id);
        Task<bool> AddSubscribablePath(string id, string path);
        Task<bool> RemoveSubscribablePath(string id, string path);
    }
}
