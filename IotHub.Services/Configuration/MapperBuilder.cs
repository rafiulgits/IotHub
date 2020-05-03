namespace IotHub.Services.Configuration
{
    public class MapperBuilder : AutoMapper.MapperConfiguration
    {
        public MapperBuilder() : base(config =>
        {
            config.AddProfile<MapperProfile>();
        })
        { }
    }
}
