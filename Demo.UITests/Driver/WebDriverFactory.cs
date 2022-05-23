using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Demo.UITests.Driver
{
    public static class WebDriverFactory
    {
      
        public static IWebDriver CreateWebDriver(WebBrowser name)
        {
            string location = @"C:\personal_repos\AutomationDemo\IntegrationTestsDemo\Demo.UITests\Driver\";

            switch (name)
            {
                case WebBrowser.Firefox:                
                    return new FirefoxDriver(location);
               
                case WebBrowser.Chrome:
                default:
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddArguments("--disable-extensions");
                               
                    return new ChromeDriver(location, chromeOption);
            }
        }
    }
}

