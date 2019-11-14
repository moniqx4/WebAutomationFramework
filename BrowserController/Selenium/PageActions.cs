using BrowserController.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Net;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserController.Selenium
{
    public class PageActions : IPageActions
    {
        private readonly string _siteUrl;
        private ISeleniumDriver _webDriver;
        private readonly IWebPage _webPage;

        public PageActions(ISeleniumDriver webDriver, IWebPage webPage)
        {
            _webDriver = webDriver;
            _webPage = webPage;
        }

        public void ClickModalPopUps(string element)
        {
            SwitchToAlert(element); //switches to active element

            _webPage.FindElementById(element).Click();
        }

        public void ClickModalPopUps(string element, string windowname)
        {
            SwitchTo(windowname); //switches to active element

            _webPage.FindElementById(element).Click();
        }

        public void ClickRadioButtonByName(string radiobuttonname, string radiovalue)
        {
            var htmlElement = _webPage.FindElementByName(radiobuttonname);

            if (htmlElement.GetAttribute("value").Equals(radiovalue))
            {
                if (!htmlElement.Selected)
                {
                    htmlElement.Click();
                }
            }
        }

        public void ClickJSPopups(string elementtext, string expMessage)
        {
            _webPage.FindElementByXPath($"//input[contains(@value,'{elementtext}')]").Click();

            SwitchToAlert(expMessage);
        }

        public void ClickWhenVisible(string element, string drivertype = "chrome")
        {
            try
            {
                new WebDriverWait(_webDriver.WebDriver(drivertype),
                                  TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementToBeClickable(_webPage.FindElement(By.Id(element)))).Click();
            }
            catch (StaleElementReferenceException)
            {
                _webPage.FindElement(By.Id(element)).Click();
            }
        }

        public void ClickWhenVisible(string element, int seconds, string drivertype = "chrome")
        {
            try
            {
                new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(seconds)).Until(_instance => _instance.FindElement(By.Id(element)).Displayed);

                //.ElementToBeClickable(FindElement(By.Id(element)))).Click(); // TODO: Fix this
            }
            catch (StaleElementReferenceException)
            {

                _webPage.FindElement(By.Id(element)).Click();
            }
        }

        public void ClickPageElement(string element, string strategy = "Id")
        {
            _webPage.LocateElement(element, strategy).Click();

        }

        public void ClickWhenVisibleCSS(string element, string drivertype = "chrome")
        {
            try
            {
                new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementToBeClickable(_webPage.FindElement(By.CssSelector(element)))).Click();

            }
            catch (StaleElementReferenceException)
            {

                _webPage.FindElement(By.CssSelector(element)).Click();
            }
        }

        public void ClickWhenVisible(string element, string strategy = "Id", string drivertype = "chrome")
        {
            var pageObj = _webPage.LocateElement(element, strategy);
            

            try
            {
                if (!pageObj.Displayed)
                {

                    new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementToBeClickable(_webPage.FindElement(By.CssSelector(element)))).Click();
                }
                else
                {
                    _webPage.LocateElement(element, strategy).Click();
                }
               
            }
            catch (StaleElementReferenceException)
            {

                _webPage.LocateElement(element, strategy).Click();
            }
        }


        public void Close(string drivertype = "chrome")
        {
            _webDriver.WebDriver(drivertype).Quit();

        }

        public void CloseBrowserTab(string drivertype = "chrome")
        {
            //CTRL W to close tab
            Actions act = new Actions(_webDriver.WebDriver(drivertype));
            act.KeyDown(Keys.Control).SendKeys("w").Perform();
        }

        public void FillTextBox(string elementname, string textvalue, string strategy = "Id")
        {
            IWebElement element;

            try
            {
                element = _webPage.LocateElement(elementname, strategy);

            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n");
                throw new Exception($"Finding the element failed. idname : {elementname}", ex);

            }

            try
            {
                if (element.Displayed)
                {
                    element.SendKeys(textvalue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n");
                throw new Exception($"Sending keys to the element failed. txtvalue : {textvalue}");
            }
        }

        public string GetBodyText()
        {
            IWebElement body = _webPage.FindElementByTagName("body");
            string text = body.Text;
            return text;
        }

        public List<System.Net.Cookie> GetCookies(string drivertype = "chrome")
        {
            var cookies = _webDriver.WebDriver(drivertype).Manage().Cookies;

            var result = new List<System.Net.Cookie>();

            foreach (var cookie in cookies.AllCookies)
            {
                var c = new System.Net.Cookie();

                c.Name = cookie.Name;
                c.Value = cookie.Value;
                c.Domain = cookie.Domain;

                if (cookie.Expiry.HasValue)
                {
                    c.Expires = cookie.Expiry.Value;
                }

                c.Path = cookie.Path;

                result.Add(c);
            }

            return result;
        }

        public string GetCurrentUrl(string drivertype = "chrome")
        {
            return _webDriver.WebDriver(drivertype).Url;
        }

        public void GetLastBrowserTab(string drivertype)
        {
            var numTabs = _webDriver.WebDriver(drivertype).WindowHandles.Count;
            _webDriver.WebDriver(drivertype).SwitchTo().Window((numTabs - 1).ToString());
        }

        public string GetPageSource(string drivertype = "chrome")
        {
            return _webDriver.WebDriver(drivertype).PageSource;
        }

        public string GetSessionId(string drivertype = "chrome")
        {
            return _webDriver.WebDriver(drivertype).SessionId.ToString(); //TODO: Fix
        }

        public List<IWebElement> GetAllSelectBoxElements(string element)
        {
            SelectElement listboxelement = new SelectElement(_webPage.FindElementById(element));
            var alloptions = listboxelement.Options;
            return (List<IWebElement>)alloptions;
        }

        public bool IsButtonEnabled(string elementid)
        {
            var htmlelement = _webPage.FindElementById(elementid).Enabled;

            if (htmlelement)
            {
                return true;
            }
            return false;
        }

        public bool IsUrlLoaded(string pageurl)
        {
            return (GetCurrentUrl() == pageurl);
        }

        public void NavigateTo(string pagePath, string drivertype, string isSecure = "N")
        {
            var protocol = isSecure == "Y" ? "https" : "http";

            var url = new Uri($"{protocol}://{_siteUrl.AppendPathSegment(pagePath)}"); //TODO: Fix this

            Console.WriteLine($"Host: {url.AbsoluteUri}");

            try
            {
                _webDriver.WebDriver(drivertype).Navigate().GoToUrl(url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to navigate to : {url.AbsoluteUri}", ex);
            }
        }

        public void NavigateTo(string pagePath, object query, string drivertype = "chrome", string isSecure = "N")
        {
            var protocol = isSecure == "Y" ? "https" : "http";

            var url = new Uri($"{protocol}://{_siteUrl.AppendPathSegment(pagePath).SetQueryParams(query)}");

            Console.WriteLine($"Host: {url.AbsoluteUri}");

            try
            {
                _webDriver.WebDriver(drivertype).Navigate().GoToUrl(url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to navigate to : {url.AbsoluteUri}", ex);
            }
        }

        public void SelectFromDropdownByValue(string elementname, string elementvalue, string strategy = "Id")
        {
            try
            {
                var htmlElement = _webPage.LocateElement(elementname, strategy);

                var selectElement = new SelectElement(htmlElement);

                selectElement.SelectByValue(elementvalue);

            }
            catch (Exception ex)
            {
                throw new Exception($"Finding the element failed. idname : {elementname}", ex);
            }
        }

        public void SelectFromDropdownText(string elementname, string elementvalue)
        {
            var htmlElement = _webPage.LocateElement(elementname);

            var selectElement = new SelectElement(htmlElement);

            selectElement.SelectByText(elementvalue);
        }

        public void SwitchTab(int tabnumber, string drivertype = "chrome")
        {
            _webDriver.WebDriver(drivertype).SwitchTo().Window(_webDriver.WebDriver(drivertype).WindowHandles[tabnumber]);
        }

        public void SwitchTo(string windowname, string drivertype = "chrome")
        {
            _webDriver.WebDriver(drivertype).SwitchTo().Window(windowname);
        }

        public void SwitchToAlert(string expMessage, string drivertype ="chrome")
        {
            IAlert alert = _webDriver.WebDriver(drivertype).SwitchTo().Alert();
            if (alert.Text.Equals(expMessage))
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
        }

        public void SwitchtoModalPopup(string windowname, string drivertype = "chrome")
        {
            SwitchTo(windowname,drivertype);
        }

        public bool WaitForElementVisibile(string element)
        {
            try
            {
                return _webPage.FindElement(By.Id(element)).Displayed;
            }
            catch (ElementNotVisibleException)
            {

                return false;
            }
        }

       

        public void WaitsecondsId(int seconds, string elementId, string drivertype = "chrome")
        {
            new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(seconds))
              .Until(ExpectedConditions.ElementIsVisible(By.Id(elementId)));
        }

        public void WaitSecsForObjectByClass(int seconds, string classname, string drivertype = "chrome")
        {
            new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(seconds))
               .Until(ExpectedConditions.ElementIsVisible(By.ClassName(classname)));
        }

        public TimeSpan WaitSecsForPageRefresh(int seconds, string drivertype = "chrome")
        {
            return _webDriver.WebDriver(drivertype).Manage().Timeouts().ImplicitWait;
        }

        public void WaitSecsForText(int seconds, string screentext, string drivertype = "chrome")
        {
            new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(seconds))
                .Until(ExpectedConditions.ElementIsVisible(By.LinkText(screentext)));
        }

        public void WaitSecsForUrl(int seconds, string pageurl, string drivertype = "chrome")
        {
            new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(seconds)).Equals(IsUrlLoaded(pageurl));
        }

        public void WaitTilPageLoads(string csselement, string drivertype = "chrome")
        {
            new WebDriverWait(_webDriver.WebDriver(drivertype), TimeSpan.FromSeconds(60))
               .Until(ExpectedConditions.ElementSelectionStateToBe(By.CssSelector(csselement), true));
        }
                
        public void ChangeWindowSize(int width, int height, string drivertype = "chrome")
        {
            _webDriver.WebDriver(drivertype).Manage().Window.Size = new System.Drawing.Size(width, height);
        }
    }
}
