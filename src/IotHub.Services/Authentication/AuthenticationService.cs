using AutoMapper;
using IotHub.Common.Exceptions;
using IotHub.DataTransferObjects.User;
using IotHub.Repositories.User;
using System.Threading.Tasks;

namespace IotHub.Services.Authentication
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public AuthenticationService(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            try
            {
                var user = await userRepository.GetByNameAsync(username);
                if (user.Password != password)
                {
                    throw new UnauthorizedException("Incorrect password");
                }
                return mapper.Map<UserDto>(user);
            }
            catch(NotFoundException notFound)
            {
                throw new UnauthorizedException(notFound.Message);
            }
        }
    }
}
