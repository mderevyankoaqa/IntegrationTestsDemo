using Demo.IntegrationTests.Pages;
using Demo.UITests.Pages;
using OpenQA.Selenium;


namespace Demo.UITests.Steps
{
    internal class LoginSteps : BaseStep
    {
        private readonly HomePage homePage;
        protected LoginPage loginPage;

        private string login;

        public LoginSteps(IWebDriver driver) : base(driver)
        {
            this.homePage = new HomePage(driver);
        }

        public LoginSteps OpenHomePage()
        {
            this.homePage.NavigateToCurrentPage();
            return this;
        }

        public LoginSteps GoToLoginPage()
        {
            this.loginPage = homePage.PressLoginBtn();
            return this;
        }


        public LoginSteps DoUserLogin(string login, string pwd)
        {
            this.login = login;

            loginPage.NavigateToCurrentPage();
            loginPage.SetEmail(login);
            loginPage.SetPassword(pwd);

            loginPage.PressLogin();

           
            return this;
        }

        public bool IsUserLoggedIn()
        {
            string welcomeMessage = loginPage.GetWelcomeMessga();
            bool isUserLoggedIn = false;

            if (welcomeMessage.Contains(this.login))
            {
                isUserLoggedIn = true;
                return isUserLoggedIn;
            }

            return isUserLoggedIn;
        }
    }
}
