using AngleSharp.Text;
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
    public class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void EndToEndFlow()
        {

            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            Login login = new Login(driver);
            
            login.Test1();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));


            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach(IWebElement prod in products)
            {
                //TestContext.WriteLine(prod.FindElement(By.CssSelector(".card-title a")).Text);
                if (expectedProducts.Contains(prod.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    prod.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }



            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for(int i =0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }


            Assert.AreEqual(expectedProducts, actualProducts);


            driver.FindElement(By.ClassName("btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.XPath("//label[@for = 'checkbox2']")).Click();

            driver.FindElement(By.XPath("//input[@value = 'Purchase']")).Click();

            String msg = driver.FindElement(By.ClassName("alert-success")).Text;

            StringAssert.Contains("Success", msg);

        }
    }
}
