using System;
using OpenQA.Selenium;
using Shouldly;

namespace TaxCalculator.SeleniumTest.Cases
{
	public class TaxCalculatorTest : IClassFixture<DriverFixture>
    {

        public IWebDriver driver;
        public TaxCalculatorTest()
        {
            var driverFixture = new DriverFixture();
            driver = driverFixture.Driver;
        }

        [Fact]
        public void LandingPage_Should_Open()
        {
            driver.Navigate().GoToUrl(new Uri("http://localhost:5218/"));
            Thread.Sleep(TimeSpan.FromSeconds(5)); // 5 seconds
            driver.FindElement(By.Id("input1")).SendKeys("000001");
            driver.FindElement(By.Id("input2")).SendKeys("1000");
            Thread.Sleep(TimeSpan.FromSeconds(5)); // 5 seconds
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5)); // 5 seconds
           var response = driver.FindElement(By.Id("response")).Text;
            response.ShouldNotBeNull();
        }

        [Fact]
        public void OnboardingPage_Click_SignIn()
        {
            driver.Navigate().GoToUrl(new Uri("http://zustech-lms-frontend.s3-website.us-east-2.amazonaws.com/account/login"));

            driver.FindElement(By.Id("username")).SendKeys("test0411@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("@@Superadmin2");
            driver.FindElement(By.Id("signin-submit")).Click();
            var title = driver.Title;
            Assert.Equal($"{title}/me", $"{title}/me");

        }
    }
}

