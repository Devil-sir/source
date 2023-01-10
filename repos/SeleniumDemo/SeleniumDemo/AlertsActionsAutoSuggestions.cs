using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class AlertsActionsAutoSuggestions
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        
        [Test]
        public void frames()
        {
            //Scroll
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);

            //id, name, index
            driver.SwitchTo().Frame(frameScroll);
            
            driver.FindElement(By.XPath("//a[@class='new-navbar-highlighter'][normalize-space()='All Access plan']")).Click();
            
            TestContext.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            
            driver.SwitchTo().DefaultContent();

            TestContext.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

        }


        [Test]
        public void testAlert()
        {
            driver.FindElement(By.Id("name")).SendKeys("Rahul");
            //Thread.Sleep(1000);
            driver.FindElement(By.Id("confirmbtn")).Click();

            String alert = driver.SwitchTo().Alert().Text;
            //Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("");


            StringAssert.Contains("Rahul", alert);

        }

        [Test]
        public void AutoSuggestion()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(2000);

            IList<IWebElement> options = driver.FindElements(By.XPath("//ul/li/div"));

            foreach(IWebElement opt in options)
            {
                if(opt.Text == "India")
                {
                    opt.Click();
                }
            }
            //This will not work for dynamic value
            //TestContext.WriteLine(driver.FindElement(By.Id("autocomplete")).Text);
            
            //Use  this instead of .Text to get the runtime  value
            TestContext.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }

        [Test]
        public void testAction()
        {
            //driver.Url = "https://rahulshettyacademy.com/";
            Actions a = new Actions(driver);

            
            /*a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();

            //driver.FindElement(By.XPath("//ul[@class = 'dropdown-menu']/li[1]/a")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class = 'dropdown-menu']/li[1]/a")));
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class = 'dropdown-menu']/li[1]/a"))).Click().Perform();           
            */
        
            //Drag and drop

            driver.Url = "https://demoqa.com/droppable/";
            a.DragAndDrop(driver.FindElement(By.Id("draggable")),driver.FindElement(By.Id("droppable"))).Perform();

        }
    }
}
