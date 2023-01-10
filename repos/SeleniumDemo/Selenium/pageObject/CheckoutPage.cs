using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.pageObject
{
    public class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;
        

        [FindsBy(How =How.ClassName,Using = "btn-success")]
        private IWebElement checkoutButton;
        public IList<IWebElement> getCheckoutCards()
        {
            return checkoutCards;
        }

        public ConfirmPage getCheckoutButton()
        {
            checkoutButton.Click();
            return new ConfirmPage(driver);
        }

    }
}
