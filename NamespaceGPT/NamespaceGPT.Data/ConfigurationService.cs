using NamespaceGPT.Common.ConfigurationManager.Module.JsonManager;
using NamespaceGPT.Common.ConfigurationManager.Module.JsonManager.JsonParser;

namespace NamespaceGPT.Data
{
    internal class ConfigurationService
    {
        private readonly JsonObject? _jsonObject;

        public ConfigurationService()
        {
            _jsonObject = (JsonObject?)JsonFileReader.ParseJsonFile("appsettings.json");
        }

        public string GetConnectionString()
        {
            var connectionString = (string?)((JsonObject?)_jsonObject?.Properties["ConnectionStrings"])?.Properties["defaultConnection"];

            if (connectionString == null)
            {
                return string.Empty;
            }

            return connectionString;
        }
    }
}
