using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class browserExample
    {
        public IWebDriver driver;
        [SetUp]
        public void invoke()
        {
            //Chrome Driver
            /*new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();*/


            //FireFox Driver
            /*new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();*/

            //Edge Driver
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            driver.Url= "https://www.google.com/";
            TestContext.WriteLine(driver.Title); 
            TestContext.WriteLine(driver.Url);
            Thread.Sleep(5000);
        }
        [TearDown]
        public void close()
        {
            driver.Quit();
        }
    }
}
