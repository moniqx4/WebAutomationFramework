using BrowserController.Selenium.Interfaces;

namespace BrowserController.Selenium
{
    public class WebSiteContextBuilder
    {
        private readonly WebSiteContext _context;

        public WebSiteContextBuilder()
        {
            _context = new WebSiteContext();
        }


        public WebSiteContextBuilder AddSiteUrl(string siteUrl)
        {
            _context.SiteUrl = siteUrl;

            return this;
        }

        public WebSiteContextBuilder AddMobileFlag(bool isMobile)
        {
            _context.IsMobile = isMobile;

            return this;
        }

        public WebSiteContextBuilder AddSiteNavigator(INavigator siteNavigator)
        {
            _context.Navigator = siteNavigator;

            return this;
        }

        public WebSiteContextBuilder AddPageAction(IPageActions pageActions)
        {
            _context.PageActions = pageActions;

            return this;
        }

        public WebSiteContextBuilder AddDocumentHelper(IWebPage helper)
        {
            _context.WebPage = helper;

            return this;
        }

        public WebSiteContext Build()
        {
            return _context;
        }


    }
}
