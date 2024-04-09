using Microsoft.Extensions.Configuration;

namespace NamespaceGPT.Data
{
    internal class ConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string GetConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("defaultConnection");

            if (connectionString == null) 
            {
                return string.Empty;
            }

            return connectionString;
        }
    }
}
