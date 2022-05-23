using Demo.UITests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Diagnostics.CodeAnalysis;

namespace Demo.IntegrationTests.Pages
{
    public abstract class BasePage: IPage
    {
        private IWebDriver driver;
        
        public IWebDriver Driver { 
            get => this.driver;

            [MemberNotNull(nameof(driver))]
            set => this.driver = value ?? throw new ArgumentNullException("Driver is required.", nameof(driver));
        }

        protected BasePage()
        {
        }

        protected BasePage(IWebDriver driver)
        { 
            this.Driver = driver;
            this.Reload();
        }

        public virtual Uri PageUrl { get;private set; }

        public string GetPageTitle()
        { 
            return this.Driver.Title;
        }

        public virtual void NavigateToCurrentPage()
        {
            this.Driver.Navigate().GoToUrl(this.PageUrl);

            this.WaitPageComapletion();
        }

        public void Reload()
        {
            PageFactory.InitElements(this.Driver, this);
        }

        public void WaitPageComapletion(int timeout=2000)
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromMilliseconds(timeout));

            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public TPage Transfer<TPage>() where TPage : BasePage, new()
        {
            var page = new TPage { Driver = this.Driver };
            this.PageUrl = page.PageUrl;
            page.Reload();
            return page;
        }

        public virtual TPage NavigateToPage<TPage>() where TPage : BasePage, new()
        {
            var page = this.Transfer<TPage>();
            this.NavigateToCurrentPage();
            return page;
        }
    }
}
