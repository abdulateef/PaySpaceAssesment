using System;
using OpenQA.Selenium;
using static TaxCalculator.SeleniumTest.Drivers.BrowserDriver;
using TaxCalculator.SeleniumTest.Drivers;

namespace TaxCalculator.SeleniumTest
{
    public class DriverFixture : IDisposable
    {
        public IWebDriver driver;
        public DriverFixture()
        {
            driver = GetWebDriver(BrowserType.Chrome);
        }
        private IWebDriver GetWebDriver(BrowserType browserType)
        {
            BrowserDriver browserDriver = new BrowserDriver();
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return browserDriver.GetChromeBrowserDriver();
                case BrowserType.Firefox:
                    return browserDriver.GetFirefoxBrowserDriver();
                case BrowserType.Edge:
                    return browserDriver.GetEdgeBrowserDriver();
                default:
                    return browserDriver.GetChromeBrowserDriver();
            }
        }
        public IWebDriver Driver => driver;

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

