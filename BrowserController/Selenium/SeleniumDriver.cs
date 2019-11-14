using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using BrowserController.Selenium.Interfaces;
using OpenQA.Selenium.Remote;

namespace BrowserController.Selenium
{
    public class SeleniumDriver : ISeleniumDriver
    {
        // public IWebDriver _driver;
        public RemoteWebDriver _driver;
        public SeleniumDriver(RemoteWebDriver driver)
        {
            _driver = driver;

        }

        public IWebDriver WebDriver(string drivertype)
        {

            switch (drivertype.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "ie":
                    _driver = new InternetExplorerDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "msedge":
                    _driver = new EdgeDriver();
                    break;
                default:
                    {
                        Console.WriteLine("Invalid Driver specified.");
                        break;
                    }
            }

            return _driver;
        }

        
    }
}
