using System.Configuration;

namespace ServiceProvider.BrowserCloudServices.BrowserStack
{
    public class BrowserstackCredentialProvider //TODO: Fix CongigurationManager
    {
        private static readonly string AccountName = ConfigurationManager.AppSettings["user"];

        private static readonly string AccessKey = ConfigurationManager.AppSettings["key"];

        private static readonly string Server = ConfigurationManager.AppSettings["server"];
    }
}
