using BrowserController.Selenium.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserController.Selenium
{
    public class webPage : IWebPage
    {
        // private readonly IPageActions 
        public webPage()
        {

        }

        public IJavaScriptExecutor ExecuteScriptExecutor()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            FindElement(by);

            return FindElement(by);
        }

        public IWebElement FindElementByClass(string elementclass)
        {
            var locator = By.ClassName(elementclass);
            var htmlelement = FindElement(locator);
            return htmlelement;
        }

        public IWebElement FindElementByCSS(string elementcss)
        {
            var locator = By.CssSelector(elementcss);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementById(string element)
        {
            var locator = By.Id(element);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementByLinkText(string linktext)
        {
            var locator = By.LinkText(linktext);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementByName(string elementname)
        {
            var locator = By.Name(elementname);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementByPartialLinkText(string element)
        {
            var locator = By.PartialLinkText(element);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementByTagName(string element)
        {
            var locator = By.TagName(element);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement FindElementByXPath(string elementxpath)
        {
            var locator = By.XPath(elementxpath);
            var htmlelement = FindElement(locator);

            return htmlelement;
        }

        public IWebElement LocateElement(string elementname, string strategy = "Id")
        {
            switch (strategy)
            {
                case ElementAccessTypes.Id:
                    return FindElementById(elementname);

                case ElementAccessTypes.CSS:
                    return FindElementByCSS(elementname);

                case ElementAccessTypes.ClassName:
                    return FindElementByClass(elementname);

                case ElementAccessTypes.LinkText:
                    return FindElementByLinkText(elementname);

                case ElementAccessTypes.Name:
                    return FindElementByName(elementname);

                case ElementAccessTypes.PartialLinkText:
                    return FindElementByPartialLinkText(elementname);

                case ElementAccessTypes.TagName:
                    return FindElementByTagName(elementname);

                case ElementAccessTypes.XPath:
                    return FindElementByXPath(elementname);

                default:

                    Console.WriteLine($"Not able to locate the element : {elementname}");
                    return null;
            }
        }
    }
}
