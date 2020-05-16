using IotHub.API.Settings;
using Microsoft.Extensions.Configuration;

namespace IotHub.API.Configuration
{
    public class SettingsBinder
    {
        private IConfiguration configuration;
        private SettingsBinder(IConfiguration configuration)
        {
            this.configuration = configuration;
            BindJwtSettings();
            BindInternalAuthSettings();
        }

        public static void Bind(IConfiguration configuration)
        {
            new SettingsBinder(configuration);
        }

        private void BindJwtSettings()
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
            SettingsProvider.JwtSettings = jwtSettings;
        }

        private void BindInternalAuthSettings()
        {
            var internalAuthSettings = new InternalAuthSettings();
            configuration.GetSection(nameof(InternalAuthSettings)).Bind(internalAuthSettings);
            SettingsProvider.InternalAuthSettings = internalAuthSettings;
        }
    }
}
