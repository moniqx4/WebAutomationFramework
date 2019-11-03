using OpenQA.Selenium;
using System.Collections.Generic;

namespace BrowserController.Selenium.Interfaces
{
    public interface IPageActions
    {
        bool IsButtonEnabled(string elementid);

        bool IsUrlLoaded(string pageurl);

        void WaitsecondsId(int seconds, string elementId);

        void WaitSecsForUrl(int seconds, string pageurl);

        void WaitSecsForText(int seconds, string screentext);

        void WaitSecsForObjectByClass(int seconds, string classname);

        void WaitSecsForPageRefresh(int seconds);

        bool WaitForElementVisibile(string element);

        void WaitTilPageLoads(string csselement);

        string GetCurrentUrl();

        string GetSessionId();

        string GetPageSource();

        string GetBodyText();

        void GetLastBrowserTab();

        List<System.Net.Cookie> GetCookies();

        List<IWebElement> GetAllSelectBoxElements(string element);        

        void Close();
        void CloseBrowserTab();       

        void SwitchTab(int tabnumber);

        void SwitchToAlert(string expMessage);

        void SwitchtoModalPopup(string windowname);

        void SwitchTo(string windowname);

        void ClickRadioButtonByName(string radiobuttonname, string radiovalue);

        void ClickModalPopUps(string element);

        void ClickModalPopUps(string element, string windowname);

        void ClickJSPopups(string elementtext, string expMessage);

        void ClickWhenVisible(string element);

        void ClickWhenVisible(string element, int seconds);

        void ClickWhenVisibleCSS(string element);

        void SelectFromDropdownText(string elementname, string elementvalue);        

        void SelectFromDropdownByValue(string elementname, string elementvalue, string strategy = ElementAccessTypes.Id);

        void FillTextBox(string idname, string textvalue, string stategy = ElementAccessTypes.Id);

        void ChangeWindowSize(int width, int height);

    }
}
