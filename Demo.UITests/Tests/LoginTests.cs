using Demo.UITests.Driver;
using Demo.UITests.Steps;

namespace Demo.UITests.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginSteps loginSteps;
        public LoginTests(WebBrowser webBrowser) : base(webBrowser)
        {
        }

        [TestCase]
        public void UserShouldBeLoggedInSuccessfully()
        {
            this.loginSteps = new LoginSteps(this.Driver);
            this.loginSteps.OpenHomePage();
            this.loginSteps.GoToLoginPage();

            this.loginSteps.DoUserLogin("user1@email.com", "1qaz@WSX");

            Assert.That(loginSteps.IsUserLoggedIn(), "User login failed");
        }
    }
}
