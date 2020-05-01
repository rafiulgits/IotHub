using AutoMapper;
using IotHub.DataTransferObjects.User;
using IotHub.Repositories.User;
using System.Threading.Tasks;

namespace IotHub.Services.User
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(UserUpsertDto userDto)
        {
            var userToCreate = mapper.Map<DomainModels.User>(userDto);
            var createdUser = await userRepository.CreateAsync(userToCreate);
            return mapper.Map<UserDto>(createdUser);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user =  await userRepository.GetAsync(id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(UserUpsertDto user)
        {
            var userToUpdate = mapper.Map<DomainModels.User>(user);
            var updatedUser = await userRepository.UpdateAsync(userToUpdate);
            return mapper.Map<UserDto>(updatedUser);
        }
    }
}
