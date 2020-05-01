using IotHub.DataTransferObjects.User;

namespace IotHub.Services.Configuration
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateUserMaps();
        }

        private void CreateUserMaps()
        {
            CreateMap<DomainModels.User, UserDto>();
            CreateMap<DomainModels.User, UserLogsDto>();
            CreateMap<UserUpsertDto, DomainModels.User>();
        }
    }
}
