namespace BrowserController.Selenium.Interfaces
{
    public interface INavigator
    {
        void NavigateTo(string pagePath, string isSecure = "N");

        void NavigateTo(string pagePath, object query, string isSecure = "N");
    }
}
