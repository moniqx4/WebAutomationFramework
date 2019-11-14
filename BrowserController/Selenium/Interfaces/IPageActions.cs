using OpenQA.Selenium;
using System.Collections.Generic;

namespace BrowserController.Selenium.Interfaces
{
    public interface IPageActions
    {
        bool IsButtonEnabled(string elementid);

        bool IsUrlLoaded(string pageurl);

        void WaitsecondsId(int seconds, string elementId, string drivertype = "chrome");

        void WaitSecsForUrl(int seconds, string pageurl, string drivertype = "chrome");

        void WaitSecsForText(int seconds, string screentext, string drivertype = "chrome");

        void WaitSecsForObjectByClass(int seconds, string classname, string drivertype = "chrome");

        System.TimeSpan WaitSecsForPageRefresh(int seconds, string drivertype = "chrome");

        bool WaitForElementVisibile(string element);

        void WaitTilPageLoads(string csselement, string drivertype = "chrome");

        string GetCurrentUrl(string drivertype = "chrome");

        string GetSessionId(string drivertype = "chrome");

        string GetPageSource(string drivertype = "chrome");

        string GetBodyText();

        void GetLastBrowserTab(string drivertype = "chrome");

        List<System.Net.Cookie> GetCookies(string drivertype = "chrome");

        List<IWebElement> GetAllSelectBoxElements(string element);        

        void Close(string drivertype = "chrome");
        void CloseBrowserTab(string drivertype = "chrome");       

        void SwitchTab(int tabnumber, string drivertype = "chrome");

        void SwitchToAlert(string expMessage, string drivertype = "chrome");

        void SwitchtoModalPopup(string windowname, string drivertype = "chrome");

        void SwitchTo(string windowname, string drivertype = "chrome");

        void ClickRadioButtonByName(string radiobuttonname, string radiovalue);

        void ClickModalPopUps(string element);

        void ClickModalPopUps(string element, string windowname);

        void ClickJSPopups(string elementtext, string expMessage);

        void ClickWhenVisible(string element, string drivertype = "chrome");
        void ClickWhenVisible(string element, string strategy = "Id", string drivertype = "chrome");

        void ClickWhenVisible(string element, int seconds, string drivertype = "chrome");

        void ClickWhenVisibleCSS(string element, string drivertype = "chrome");

        void ClickPageElement(string element, string strategy = "Id");

        void SelectFromDropdownText(string elementname, string elementvalue);        

        void SelectFromDropdownByValue(string elementname, string elementvalue, string strategy = ElementAccessTypes.Id);

        void FillTextBox(string idname, string textvalue, string stategy = ElementAccessTypes.Id);

        void ChangeWindowSize(int width, int height, string drivertype = "chrome");

    }
}
