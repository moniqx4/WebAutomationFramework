namespace ServiceProvider.BrowserCloudServices.BrowserStack
{
    public class BrowserStackSettingsProvider
    {
        private static readonly BrowserStackSettings _profile1Settings;
        private static readonly BrowserStackSettings _profile2Settings;


        static BrowserStackSettingsProvider() //TODO: Need to make it so user can set those setting for each profile
        {
            _profile1Settings = new BrowserStackSettings
            {
                BuildNumber = "",
                Project = "",
                SessionUrl = "www.browserstack.com/automate/sessions/",
                Local = false
            };

            _profile2Settings = new BrowserStackSettings
            {
                BuildNumber = "",
                Project = "",
                SessionUrl = "www.browserstack.com/automate/sessions/",
                Local = false
            };

        }

        public static BrowserStackSettings GetProfile1Settings()
        {
            return _profile1Settings;
        }

        public static BrowserStackSettings GetProfile2Settings()
        {
            return _profile2Settings;
        }

    }
}
