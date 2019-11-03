using System.Collections.Generic;

namespace BrowserController.Selenium
{
    public class SeleniumConfiguration
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public string Browser { get; set; }

        public string Version { get; set; }

        public bool IsMobile { get; set; }

        public string Platform { get; set; }

        public List<SeleniumCapability> Capabilities { get; set; }
    }
}
