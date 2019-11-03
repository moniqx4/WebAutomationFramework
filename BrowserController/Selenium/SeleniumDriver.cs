using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using BrowserController.Selenium.Interfaces;

namespace BrowserController.Selenium
{
    public class SeleniumDriver : ISeleniumDriver
    {
        private readonly RemoteWebDriver _instance;
        public IWebDriver _driver;
        public SeleniumDriver(IWebDriver driver)
        {
            _driver = driver;

        }

        public IWebDriver WebDriver(string drivertype)
        {

            switch (drivertype)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;
                case "FireFox":
                    _driver = new FirefoxDriver();
                    break;
                case "MSEdge":
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
