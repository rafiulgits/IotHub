using AutoMapper;

namespace IotHub.Services
{
    public class BaseService
    {
        public IMapper mapper;
        public BaseService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
