using IotHub.DataTransferObjects.Profile;
using IotHub.DataTransferObjects.Subscription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotHub.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileDto> CreateProfileAsync(ProfileUpsertDto profile);
        Task<ProfileDto> GetProfileAsync(string id);
        Task<IEnumerable<ProfileDto>> GetAllAsync();
        Task<ProfileDto> GetProfileByUserIdAsync(string userId);
        Task<ProfileDto> UpdateProfileAsync(ProfileUpsertDto profile);
        Task<bool> DeleteProfileAsync(string id);
        Task<bool> AddSubscription(string profileId, ProfileSubscriptionDto profileSubscription);
        Task<bool> RemoveSubscription(string profileId, ProfileSubscriptionDto profileSubscription);
        Task<bool> HasSubscription(string profileId, string path);
        Task<IEnumerable<SubscriptionDto>> GetSubscriptionsAsync(string id);
    }
}
