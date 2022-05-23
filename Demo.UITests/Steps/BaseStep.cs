using OpenQA.Selenium;

namespace Demo.UITests.Steps
{
    public abstract class BaseStep
    {
        protected IWebDriver webDriver;

        protected BaseStep(IWebDriver driver)
        {
            this.webDriver = driver;           
        }     
    }
}
