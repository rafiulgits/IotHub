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
        Task<ProfileWithSubscriptionsDto> GetProfileWithSubscriptionsAsync(string id);
        Task<ProfileWithSubscriptionsDto> GetProfileWithSubscriptionByUserIdAsync(string userId);
        Task<IEnumerable<ProfileDto>> GetAllAsync();
        Task<ProfileDto> GetProfileByUserIdAsync(string userId);
        Task<ProfileDto> UpdateProfileAsync(ProfileUpsertDto profile);
        Task<bool> DeleteProfileAsync(string id);
        Task<bool> AddSubscription(string profileId, SubscriptionUpsertDto profileSubscription);
        Task<bool> RemoveSubscription(string profileId, SubscriptionUpsertDto profileSubscription);
        IEnumerable<SubscriptionDto> GetSubscriptions(string id);
    }
}
