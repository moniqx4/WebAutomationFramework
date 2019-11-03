using BrowserController.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Net;

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

        public void ClickWhenVisible(string element)
        {
            try
            {
                new WebDriverWait(_webDriver,
                                  TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementToBeClickable(_webPage.FindElement(By.Id(element)))).Click();
            }
            catch (StaleElementReferenceException)
            {
                _webPage.FindElement(By.Id(element)).Click();
            }
        }

        public void ClickWhenVisible(string element, int seconds)
        {
            try
            {
                new WebDriverWait(_instance, TimeSpan.FromSeconds(seconds)).Until(_instance => _instance.FindElement(By.Id(element)).Displayed);

                //.ElementToBeClickable(FindElement(By.Id(element)))).Click(); // TODO: Fix this
            }
            catch (StaleElementReferenceException)
            {

                _webPage.FindElement(By.Id(element)).Click();
            }
        }

        public void ClickWhenVisibleCSS(string element)
        {
            try
            {
                new WebDriverWait(_instance, TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementToBeClickable(_webPage.FindElement(By.CssSelector(element)))).Click();

            }
            catch (StaleElementReferenceException)
            {

                _webPage.FindElement(By.CssSelector(element)).Click();
            }
        }


        public void Close()
        {
            _instance.Quit();
        }

        public void CloseBrowserTab()
        {
            //CTRL W to close tab
            Actions act = new Actions(_instance);
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

        public List<System.Net.Cookie> GetCookies()
        {
            var cookies = _instance.Manage().Cookies;

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

        public string GetCurrentUrl()
        {
            return _instance.Url;
        }

        public void GetLastBrowserTab()
        {
            _instance.SwitchTo().Window(_instance.WindowHandles.Last());
        }

        public string GetPageSource()
        {
            return _instance.PageSource;
        }

        public string GetSessionId()
        {
            return _instance.SessionId.ToString();
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

        public void NavigateTo(string pagePath, string isSecure = "N")
        {
            var protocol = isSecure == "Y" ? "https" : "http";

            var url = new Uri($"{protocol}://{_siteUrl.AppendPathSegment(pagePath)}"); //TODO: Fix this

            Console.WriteLine($"Host: {url.AbsoluteUri}");

            try
            {
                _instance.Navigate().GoToUrl(url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to navigate to : {url.AbsoluteUri}", ex);
            }
        }

        public void NavigateTo(string pagePath, object query, string isSecure = "N")
        {
            var protocol = isSecure == "Y" ? "https" : "http";

            var url = new Uri($"{protocol}://{_siteUrl.AppendPathSegment(pagePath).SetQueryParams(query)}");

            Console.WriteLine($"Host: {url.AbsoluteUri}");

            try
            {
                _instance.Navigate().GoToUrl(url.AbsoluteUri);
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

        public void SwitchTab(int tabnumber)
        {
            _instance.SwitchTo().Window(_instance.WindowHandles[tabnumber]);
        }

        public void SwitchTo(string windowname)
        {
            _instance.SwitchTo().Window(windowname);
        }

        public void SwitchToAlert(string expMessage)
        {
            IAlert alert = _instance.SwitchTo().Alert();
            if (alert.Text.Equals(expMessage))
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
        }

        public void SwitchtoModalPopup(string windowname)
        {
            SwitchTo(windowname);
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

       

        public void WaitsecondsId(int seconds, string elementId)
        {
            new WebDriverWait(_instance, TimeSpan.FromSeconds(seconds))
              .Until(ExpectedConditions.ElementIsVisible(By.Id(elementId)));
        }

        public void WaitSecsForObjectByClass(int seconds, string classname)
        {
            new WebDriverWait(_instance, TimeSpan.FromSeconds(seconds))
               .Until(ExpectedConditions.ElementIsVisible(By.ClassName(classname)));
        }

        public void WaitSecsForPageRefresh(int seconds)
        {
            _instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public void WaitSecsForText(int seconds, string screentext)
        {
            new WebDriverWait(_instance, TimeSpan.FromSeconds(seconds))
                .Until(ExpectedConditions.ElementIsVisible(By.LinkText(screentext)));
        }

        public void WaitSecsForUrl(int seconds, string pageurl)
        {
            new WebDriverWait(_instance, TimeSpan.FromSeconds(seconds)).Equals(IsUrlLoaded(pageurl));
        }

        public void WaitTilPageLoads(string csselement)
        {
            new WebDriverWait(_instance, TimeSpan.FromSeconds(60))
               .Until(ExpectedConditions.ElementSelectionStateToBe(By.CssSelector(csselement), true));
        }
                
        public void ChangeWindowSize(int width, int height)
        {
            _instance.Manage().Window.Size = new System.Drawing.Size(width, height);
        }
    }
}
