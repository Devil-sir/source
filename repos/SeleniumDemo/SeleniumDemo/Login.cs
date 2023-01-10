using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class Login
    {
        IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;   
        }
       /* [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }*/
        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            
            driver.FindElement(By.Name("password")).SendKeys("learning");

            //Radio Button Access
            IList<IWebElement> radio = driver.FindElements(By.CssSelector("input[type = 'radio']"));
            foreach(IWebElement radioElement in radio)
            {
                if (radioElement.GetAttribute("value").Equals("user"))
                {
                    radioElement.Click();
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            //Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            //Assert.That(result, Is.True);

            // Drop Down Element Access
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement select = new SelectElement(dropDown);
            select.SelectByText("Teacher");
             
            driver.FindElement(By.CssSelector(".text-info span input")).Click();

            driver.FindElement(By.XPath("//input[@id = 'signInBtn']")).Click();

        }

    }
}
