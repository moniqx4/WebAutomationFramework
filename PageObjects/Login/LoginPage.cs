using BrowserController.Selenium.Interfaces;

namespace PageObjects.Login
{
    public class LoginPage
    {
        public IWebPage WebPage { get; }        
        private readonly IPageActions _pageActions;
        public LoginPage(IWebPage webPage, IPageActions pageActions)
        {
            WebPage = webPage;
            _pageActions = pageActions;
        }

        

        public void LoginToAccount(string email, string password,string emailElementname, string passwordElementName, string submitElementName )
        {
            _pageActions.FillTextBox(emailElementname, email);
            _pageActions.FillTextBox(passwordElementName, password);
            _pageActions.ClickPageElement(submitElementName);
        }


    }
}
