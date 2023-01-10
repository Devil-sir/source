using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.pageObject
{
    public class ConfirmPage
    {
        IWebDriver driver;
        By alertSuccess = By.ClassName("alert-success");
        public ConfirmPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement textCountry;

        [FindsBy(How = How.LinkText, Using ="India")]
        private IWebElement country;

        [FindsBy(How = How.XPath, Using = "//label[@for = 'checkbox2']")]
        private IWebElement checkbox;

        [FindsBy(How = How.XPath, Using = "//input[@value = 'Purchase']")]
        private IWebElement purchaseButton;
        public void wait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public IWebElement getTextCountry()
        {
            return textCountry;
        }
        public IWebElement getCountry()
        {
            return country;
        }
        public IWebElement getCheckBox()
        {
            return checkbox;
        }
        public IWebElement getPurchaseButton()
        {
            return purchaseButton;
        }
        public By getAlertSuccess()
        {
            return alertSuccess;
        }

    }
}
