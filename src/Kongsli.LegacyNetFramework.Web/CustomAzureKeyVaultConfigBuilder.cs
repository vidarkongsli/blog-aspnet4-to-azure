using System;
using System.Collections.Specialized;
using Microsoft.Configuration.ConfigurationBuilders;

namespace Kongsli.LegacyNetFramework.Web
{
    public class CustomAzureKeyVaultConfigBuilder : AzureKeyVaultConfigBuilder
    {
        public override void Initialize(string name, NameValueCollection config)
        {
            var keyVaultUrl = Environment.GetEnvironmentVariable("KEYVAULT_BASE_URL");

            if (!string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                config["uri"] = keyVaultUrl;
            }

            base.Initialize(name, config);
        }
    }
}