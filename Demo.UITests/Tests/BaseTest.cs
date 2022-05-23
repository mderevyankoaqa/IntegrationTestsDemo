using OpenQA.Selenium;
using Demo.UITests.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Demo.UITests.Tests
{
    [TestFixture(WebBrowser.Chrome)]
    [TestFixture(WebBrowser.Firefox)]
    [Parallelizable(ParallelScope.All)]
    public abstract class BaseTest
    {
        private WebBrowser webBrowser;
        private IWebDriver driver;

        private readonly ThreadLocal<IWebDriver> localDriver = new();

        protected IWebDriver Driver
        {
            get => this.driver;

            [MemberNotNull(nameof(driver))]
            set => this.driver = value ?? throw new ArgumentNullException("Driver is required.", nameof(driver));
        }
        protected WebBrowser WebBrowser { get => webBrowser; set => webBrowser = value; }

        protected BaseTest(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

        [SetUp]
        public void Init()
        {
            this.localDriver.Value = WebDriverFactory.CreateWebDriver(WebBrowser);
            this.Driver = this.localDriver.Value;
        }
        
        [TearDown]
        public void Close()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
