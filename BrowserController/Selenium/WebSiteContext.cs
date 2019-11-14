using BrowserController.Selenium.Interfaces;

namespace BrowserController.Selenium
{
    public class WebSiteContext
    {
        public string SiteUrl { get; internal set; }

        public bool IsMobile { get; internal set; }

        public IPageActions PageActions { get; internal set; }

        public INavigator Navigator { get; internal set; }

        public IWebPage WebPage { get; internal set; }

        internal void Close()
        {
            PageActions.Close();
        }

    }
}
