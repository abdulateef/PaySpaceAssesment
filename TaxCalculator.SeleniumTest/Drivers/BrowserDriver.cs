using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TaxCalculator.SeleniumTest.Drivers
{
	public class BrowserDriver
	{
        public IWebDriver GetChromeBrowserDriver()
        {
            var chromeDriverInstaller = new ChromeDriverInstaller();
            var chromeVersion = chromeDriverInstaller.GetChromeVersion().Result;
            Console.WriteLine($"Chrome version {chromeVersion} detected");
            Task.FromResult(chromeDriverInstaller.Install(chromeVersion));
            Console.WriteLine("ChromeDriver installed");
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetFirefoxBrowserDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }
        public IWebDriver GetEdgeBrowserDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver();
        }
        public enum BrowserType
        {
            Chrome = 1,
            Firefox,
            Edge
        }
    }
}

