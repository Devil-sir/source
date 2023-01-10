using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class WindowHandler
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void WindowHandle()
        {
            driver.FindElement(By.ClassName("blinkingText")).Click();
            String parentWindowName = driver.CurrentWindowHandle; 
            Assert.AreEqual(2, driver.WindowHandles.Count);
            
            String childWindowName = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindowName);

            String email = "mentor@rahulshettyacademy.com";
            TestContext.WriteLine(driver.FindElement(By.ClassName("red")).Text);

            String text = driver.FindElement(By.ClassName("red")).Text;

            String[] s = text.Split("at");
            String[] trim = s[1].Trim().Split(' ');

            Assert.AreEqual(email, trim[0]);

            driver.SwitchTo().Window(parentWindowName);

            driver.FindElement(By.Id("username")).SendKeys(trim[0]);

        }
    }
}
