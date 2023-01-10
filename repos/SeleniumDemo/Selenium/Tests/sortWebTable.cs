using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.utilties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    [Parallelizable(ParallelScope.Self)]
    public class sortWebTable : BaseClass
    {
        
        [Test]
        public void SortTable()
        {
            ArrayList arr = new ArrayList();
            SelectElement dropDown = new SelectElement(driver.Value.FindElement(By.Id("page-menu")));
            dropDown.SelectByText("20");

            // setp 1 : Get All Veggie Name
            IList<IWebElement> veggies = driver.Value.FindElements(By.XPath("//tr/td[1]"));

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

            driver.Value.FindElement(By.XPath("//thead/tr/th[1]")).Click();

            // step 4:Get All veggie name in array List B
            ArrayList brr = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.Value.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                brr.Add(veggie.Text);
            }

            Assert.AreEqual(arr, brr);


        }
    }
}
