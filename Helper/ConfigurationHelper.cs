using Microsoft.Extensions.Configuration;

namespace NotificationService.Helper
{
    public static class ConfigurationHelper
    {
        public static string GetByName(string configKeyName)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IConfigurationSection section = config.GetSection(configKeyName);

            return section.Value;
        }
    }
}
