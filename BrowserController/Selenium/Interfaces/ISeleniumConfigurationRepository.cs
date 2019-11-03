using System.Collections.Generic;

using BrowserController.Selenium;

namespace TestRunnerLibrary.Selenium.Interfaces
{
    public interface ISeleniumConfigurationRepository
    {
        List<SeleniumConfiguration> GetByActive();
    }
}
