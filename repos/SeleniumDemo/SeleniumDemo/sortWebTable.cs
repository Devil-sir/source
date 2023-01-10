using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class sortWebTable
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void SortTable()
        {
            ArrayList arr = new ArrayList();
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropDown.SelectByText("20");

            // setp 1 : Get All Veggie Name
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                arr.Add(veggie.Text);
            }

            //setp 2 : sorting the arrayList 
            arr.Sort();

            foreach(String s in arr)
            {
                TestContext.Progress.WriteLine(s);
            }

            //step 3 :go and click on cloumn

            driver.FindElement(By.XPath("//thead/tr/th[1]")).Click();

            // step 4:Get All veggie name in array List B
            ArrayList brr = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                brr.Add(veggie.Text);
            }

            Assert.AreEqual(arr, brr);


        }
    }
}
