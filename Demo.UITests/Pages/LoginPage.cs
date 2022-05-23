using Demo.UITests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Demo.IntegrationTests.Pages
{
    public class LoginPage : BasePage
    {
 
        [FindsBy(How = How.Id, Using = "Input_Email")]
        [CacheLookup]
        private readonly IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "Input_Password")]
        [CacheLookup]
        private readonly IWebElement passwordlInput;

        [FindsBy(How = How.Id, Using = "login-submit")]
        [CacheLookup]
        private readonly IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        [CacheLookup]
        private readonly IWebElement welcomeTitle;
              
        public override Uri PageUrl
        {
            get => new(UriProvider.GetRootUri() + "/Identity/Account/Login");           
        }


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage()
        {

        }

        public void SetEmail(string email)
        { 
            this.emailInput.SendKeys(email); 
        }

        public void SetPassword(string pwd)
        { 
            this.passwordlInput.SendKeys(pwd); 
        }

        public void PressLogin()
        {
            this.loginButton.Click();
            this.WaitPageComapletion();
        }

        public string GetWelcomeMessga()
        {
            return this.welcomeTitle.Text;
        }
    }
}
