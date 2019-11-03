using BrowserController.Selenium.Interfaces;

namespace BrowserController.Selenium
{
    public class WebSiteContext
    {
        private IPageActions pageAction;
        private INavigator navigator;
        private IWebPage webPage;

        public string SiteUrl { get; internal set; }

        public bool IsMobile { get; internal set; }

        public IPageActions PageActions { get => pageAction; internal set => pageAction = value; }

        public INavigator Navigator { get => navigator; internal set => navigator = value; }

        public IWebPage WebPage { get => webPage; internal set => webPage = value; }

        internal void Close()
        {
            PageActions.Close();
        }

    }
}
