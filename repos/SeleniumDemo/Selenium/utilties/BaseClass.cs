using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using NUnit.Framework;

namespace Selenium.utilties
{
    public class BaseClass
    {
        String browserName;
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void startBrowser()
        {
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];

            }
            initBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();

            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }
        public void initBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver.Value = new FirefoxDriver();
                        break;
                    }
                case "Chrome":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver.Value = new ChromeDriver();
                        break;
                    }
                case "Edge":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver.Value = new EdgeDriver();
                        break;
                    }
            }
        }

        public static jsonReader getDataParser()
        {
            return new jsonReader();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Value.Quit();
        }

    }
}
