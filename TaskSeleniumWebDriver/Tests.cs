using OpenQA.Selenium.Chrome;
using TaskSeleniumWebDriver.PageObjects;

namespace TaskSeleniumWebDriver
{
    [TestFixture]
    public class Tests
    {
        ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void CreateNewPaste_ShouldSucceed()
        {
            _driver.Navigate().GoToUrl("https://pastebin.com/");

            var pastebinHomePage = new PastebinHomePage(_driver);
            pastebinHomePage
                .EnterPasteText("Hello from WebDriver")
                .SelectPasteExpiration("10 Minutes")
                .EnterPasteName("helloweb")
                .SubmitPaste();

            Assert.Pass("Paste was created successfully");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}