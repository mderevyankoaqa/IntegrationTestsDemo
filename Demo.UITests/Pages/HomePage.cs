using Demo.IntegrationTests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Demo.UITests.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "[h1.display-4]")]
        [CacheLookup]
        private readonly IWebElement welcomeMessage;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Identity/Account/Login']")]
        [CacheLookup]
        private readonly IWebElement loginBtn;

        public override Uri PageUrl
        {
            get => new(UriProvider.GetRootUri());
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage()
        {
        }

        public string GetWelcomeMessage()
        {
            return welcomeMessage.Text;
        }

        public LoginPage PressLoginBtn()
        {
            this.loginBtn.Click();
            this.WaitPageComapletion();

            return this.Transfer<LoginPage>();
        }
    }
}
