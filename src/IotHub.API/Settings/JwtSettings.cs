namespace IotHub.API.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int LifeTimeDays { get; set; }
    }
}
