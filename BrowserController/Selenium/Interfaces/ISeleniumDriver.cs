using OpenQA.Selenium;

namespace BrowserController.Selenium.Interfaces
{
    public interface ISeleniumDriver
    {
        IWebDriver WebDriver(string drivertype = "chrome");

    }
}
