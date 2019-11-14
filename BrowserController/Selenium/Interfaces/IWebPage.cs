using OpenQA.Selenium;

namespace BrowserController.Selenium.Interfaces
{
    public interface IWebPage
    {
        // bool Displayed { get; }

        IWebElement FindElement(By by);

        IWebElement FindElementById(string element);

        IWebElement FindElementByClass(string elementclass);

        IWebElement FindElementByName(string elementname);

        IWebElement FindElementByLinkText(string linktext);

        IWebElement FindElementByPartialLinkText(string element);

        IWebElement FindElementByCSS(string elementcss);

        IWebElement FindElementByXPath(string elementxpath);

        IWebElement LocateElement(string element, string strategy = ElementAccessTypes.Id);

        IWebElement FindElementByTagName(string element);

        IJavaScriptExecutor ExecuteScriptExecutor();

        


    }
}
