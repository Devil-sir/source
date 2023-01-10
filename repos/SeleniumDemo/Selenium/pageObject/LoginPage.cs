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
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Pageobject Factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = ".text-info span input")]
        private IWebElement checkBox;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signInBtn']")]
        private IWebElement signInButton;


        public productPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new productPage(driver);
        }

        public IWebElement getUserName()
        {
            return username;
        }
        
        
    }

}
