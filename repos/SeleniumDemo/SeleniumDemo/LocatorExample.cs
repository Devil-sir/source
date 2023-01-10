using NUnit.Framework;
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
    public class LocatorExample
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            
            //implicit Wait -- global timeout
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();



        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            //By Id
            /*driver.FindElement(By.Id("username")).SendKeys("rahul");
            Thread.Sleep(1000);
            */
            //By Name
            driver.FindElement(By.Name("username")).Clear();
            
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");

            driver.FindElement(By.Name("password")).SendKeys("123456");
            //Thread.Sleep(1000);



            //By cssSelector ---- tagname[attribute  = 'value']
            //driver.FindElement(By.CssSelector("input[value = 'Sign In']")).Click();
            driver.FindElement(By.CssSelector(".text-info span input")).Click();

            //By Xpath ---- //tagname[@attribute = 'value']

            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.XPath("//input[@id = 'signInBtn']")).Click();

            //Thread.Sleep(3000);
            //Explict Wait
            WebDriverWait wait = new WebDriverWait( driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath("//input[@value = 'Sign In']")), "Sign In"));

            String errorMessagre = driver.FindElement(By.ClassName("alert-danger")).Text;

            TestContext.WriteLine(errorMessagre);

            //By LinkText
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            String href = link.GetAttribute("href");
            String expectedhref = "https://rahulshettyacademy.com/documents-request";
            
            Assert.AreEqual(expectedhref, href);    
            //TestContext.WriteLine();





        }
    }
}
