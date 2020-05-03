using IotHub.DataTransferObjects.Profile;
using IotHub.DataTransferObjects.User;

namespace IotHub.Services.Configuration
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateUserMaps();
            CreateProfileMaps();
        }

        private void CreateUserMaps()
        {
            CreateMap<DomainModels.User, UserDto>();
            CreateMap<DomainModels.User, UserLogsDto>();
            CreateMap<UserUpsertDto, DomainModels.User>();
        }

        private void CreateProfileMaps()
        {
            CreateMap<DomainModels.Profile, ProfileDto>();
            CreateMap<ProfileUpsertDto, DomainModels.Profile>();
            CreateMap<ProfileSubscriptionDto, DomainModels.Subscription>();
            CreateMap<DomainModels.Subscription, ProfileSubscriptionDto>();
        }
    }
}
