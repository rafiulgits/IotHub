using AutoMapper;
using IotHub.DataTransferObjects.Profile;
using IotHub.DataTransferObjects.Subscription;
using IotHub.Repositories.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Services.Profile
{
    public class ProfileService : BaseService, IProfileService
    {
        private readonly IProfileRepository profileRepository;

        public ProfileService(IMapper mapper, IProfileRepository profileRepository) : base(mapper)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<bool> AddSubscription(string profileId, ProfileSubscriptionDto profileSubscription)
        {
            var subscription = mapper.Map<DomainModels.Subscription>(profileSubscription);
            return await profileRepository.AddSubscription(profileId, subscription);
        }

        public async Task<ProfileDto> CreateProfileAsync(ProfileUpsertDto profile)
        {
            var profileToCreate = mapper.Map<DomainModels.Profile>(profile);
            var createdProfile = await profileRepository.CreateAsync(profileToCreate);
            return mapper.Map<ProfileDto>(createdProfile);
        }

        public async Task<bool> DeleteProfileAsync(string id)
        {
            return await profileRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProfileDto>> GetAllAsync()
        {
            var profiles =  await profileRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ProfileDto>>(profiles);
        }

        public async Task<ProfileDto> GetProfileAsync(string id)
        {
            var profile = await profileRepository.GetAsync(id);
            return mapper.Map<ProfileDto>(profile);
        }

        public async Task<ProfileDto> GetProfileByUserIdAsync(string userId)
        {
            var profile = await profileRepository.GetByUserIdAsync(userId);
            return mapper.Map<ProfileDto>(profile);
        }

        public async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsAsync(string id)
        {
            var queryable = profileRepository.GetAsQueryable();
            var subscriptions = await Task.FromResult(queryable.Where(p => p.Id == id)
                                                               .FirstOrDefault()?.Subscriptions
                                                               .ToList());
            return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
        }

        public async Task<bool> HasSubscription(string userId, string path)
        {
            bool hasPermission = false;
            var profile = await profileRepository.GetByUserIdAsync(userId);
            if(profile != null)
            {
                if(profile.Type == Common.Enums.ProfileType.Agent)
                {
                    hasPermission = true;
                }
                else
                {
                    hasPermission = profile.Subscriptions.Any(sub => sub.Path == path);
                }
            }
            return hasPermission;
            
        }

        public async Task<bool> RemoveSubscription(string profileId, ProfileSubscriptionDto profileSubscription)
        {
            var subscription = mapper.Map<DomainModels.Subscription>(profileSubscription);
            return await profileRepository.RemoveSubscription(profileId, subscription);
        }

        public async Task<ProfileDto> UpdateProfileAsync(ProfileUpsertDto profile)
        {
            var profileToUpdate = mapper.Map<DomainModels.Profile>(profile);
            var updatedProfile = await profileRepository.UpdateAsync(profileToUpdate);
            return mapper.Map<ProfileDto>(updatedProfile);
        }
    }
}
