using AutoMapper;
using IotHub.DataTransferObjects.Profile;
using IotHub.Repositories.Profile;
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

        public Task<bool> AddSubscription(string profileId, ProfileSubscriptionDto profileSubscription)
        {
            throw new System.NotImplementedException();
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

        public async Task<bool> HasSubscription(string profileId, string path)
        {
            var profile = await Task.FromResult(
                profileRepository
                    .GetAsQueryable()
                    .Where(p => p.Id == profileId)
                    .FirstOrDefault()?.Subscriptions
                    .Where(s => s.Path == path)
                    .FirstOrDefault());
            return profile != null;
            
        }

        public Task<bool> RemoveSubscription(string profileId, ProfileSubscriptionDto profileSubscription)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProfileDto> UpdateProfileAsync(ProfileUpsertDto profile)
        {
            var profileToUpdate = mapper.Map<DomainModels.Profile>(profile);
            var updatedProfile = await profileRepository.UpdateAsync(profileToUpdate);
            return mapper.Map<ProfileDto>(updatedProfile);
        }
    }
}
