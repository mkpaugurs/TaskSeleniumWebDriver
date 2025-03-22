using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TaskSeleniumWebDriver.PageObjects
{
    public class PastebinHomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _pasteTextArea = By.Id("postform-text");
        private readonly By _pasteNameInput = By.Id("postform-name");
        private readonly By _submitButton = By.XPath("//button[contains(@class, 'btn') and contains(@class, '-big')]");

        public PastebinHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public PastebinHomePage EnterPasteText(string text)
        {
            _driver.FindElement(_pasteTextArea).SendKeys(text);
            return this;
        }

        public PastebinHomePage SelectPasteExpiration(string visibleText)
        {
            // This is the clickable "fake" dropdown. Clicking it will open the options list.
            var dropdownContainer = By.CssSelector("span#select2-postform-expiration-container");

            // After opening the dropdown, these <li> elements represent the actual options
            // Use the displayed text (e.g., "10 Minutes") to find the matching option.
            var optionToSelect = By.XPath($"//li[contains(text(), '{visibleText}')]");

            // 1) Click on the dropdown container to open the list
            _driver.FindElement(dropdownContainer).Click();

            // 2) Click on the matching option
            _driver.FindElement(optionToSelect).Click();

            return this;
        }

        public PastebinHomePage EnterPasteName(string pasteName)
        {
            _driver.FindElement(_pasteNameInput).SendKeys(pasteName);
            return this;
        }

        public void SubmitPaste()
        {
            _driver.FindElement(_submitButton).Click();
        }
    }
}
