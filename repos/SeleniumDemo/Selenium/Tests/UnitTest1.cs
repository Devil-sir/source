using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using Selenium.utilties;
using Selenium.pageObject;
using NUnit.Framework;

namespace Selenium
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETest : BaseClass
    {
        [Test,Category("smoke")]
        [TestCaseSource("AddTestDataConfig")]
        //[TestCase("rahulshettyacademy","learning")]
        //[TestCase("rahulshetty", "learning")]
        [Parallelizable(ParallelScope.All)]
        public void EndToEndFlow(string userName, string password, String[] expectedProducts)
        {
            //String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());
            //loginPage.getUserName().SendKeys("rahulshettyacademy");
            productPage productPage = loginPage.validLogin(userName, password);
            productPage.waitForPageDisplay();
            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement prod in products)
            {
                //TestContext.WriteLine(prod.FindElement(By.CssSelector(".card-title a")).Text);
                if (expectedProducts.Contains(prod.FindElement(productPage.getCardTitle()).Text))
                {
                    prod.FindElement(productPage.getaddToCartButton()).Click();
                }
            }



            CheckoutPage checkoutPage = productPage.getCheckoutButton();
            IList<IWebElement> checkoutCards = checkoutPage.getCheckoutCards();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }


            Assert.AreEqual(expectedProducts, actualProducts);

            ConfirmPage confirmPage = checkoutPage.getCheckoutButton();
            confirmPage.getTextCountry().SendKeys("ind");
            confirmPage.wait();
            confirmPage.getCountry().Click();
            confirmPage.getCheckBox().Click();
            confirmPage.getPurchaseButton().Click();
            String msg = driver.Value.FindElement(confirmPage.getAlertSuccess()).Text;

            StringAssert.Contains("Success", msg);

        }

        [Test, Category("Regression")]
        public void invalidLogin()
        {
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");
            driver.Value.FindElement(By.CssSelector(".text-info span input")).Click();
            driver.Value.FindElement(By.XPath("//input[@id = 'signInBtn']")).Click();

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.Value.FindElement(By.XPath("//input[@value = 'Sign In']")), "Sign In"));

            String errorMessagre = driver.Value.FindElement(By.ClassName("alert-danger")).Text;

            TestContext.WriteLine(errorMessagre);

        }


        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            /*yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshetty", "learning");*/

            //yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"));
            yield return new TestCaseData(getDataParser().extractData("username1"), getDataParser().extractData("password1"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));

        }
    }

}