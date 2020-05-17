namespace IotHub.API.Settings
{
    public class SettingsProvider
    {
        public static InternalAuthSettings InternalAuthSettings { get; set; }
        public static JwtSettings JwtSettings { get; set; }
        public static CorsSettings CorsSettings { get; set; }
    }
}
