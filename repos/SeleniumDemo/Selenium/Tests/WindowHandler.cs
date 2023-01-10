using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    [Parallelizable(ParallelScope.Self)]
    public class WindowHandler : BaseClass
    {
        [Test]
        public void WindowHandle()
        {
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();
            String parentWindowName = driver.Value.CurrentWindowHandle; 
            Assert.AreEqual(2, driver.Value.WindowHandles.Count);
            
            String childWindowName = driver.Value.WindowHandles[1];

            driver.Value.SwitchTo().Window(childWindowName);

            String email = "mentor@rahulshettyacademy.com";
            TestContext.WriteLine(driver.Value.FindElement(By.ClassName("red")).Text);

            String text = driver.Value.FindElement(By.ClassName("red")).Text;

            String[] s = text.Split("at");
            String[] trim = s[1].Trim().Split(' ');

            Assert.AreEqual(email, trim[0]);

            driver.Value.SwitchTo().Window(parentWindowName);

            driver.Value.FindElement(By.Id("username")).SendKeys(trim[0]);

        }
    }
}
