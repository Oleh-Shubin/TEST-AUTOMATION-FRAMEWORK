using NUnit.Framework;
using OpenQA.Selenium;
using TestFrameworkHomeTask.Factory;

namespace TestFrameworkHomeTask.PageObject.Authentication.Login
{
    public class LoginWebPart : BasePageClass
    {
        public LoginWebPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(@data-test-selector, 'login')]"));
        private IWebElement Name => driver.FindElement(By.XPath("//input[contains(@aria-label,'Enter your username')]"));
        private IWebElement Password => driver.FindElement(By.XPath("//input[contains(@aria-label,'Enter your password')]"));
        private IWebElement ConfirmButton => driver.FindElement(By.XPath("//button[contains(@data-a-target,'passport-login-button')]"));
        private IWebElement FailLogin => driver.FindElement(By.XPath("//strong[contains(@class,'CoreText')]"));

        public void Login(string name, string password)
        {
            LoginButton.Click();
            Name.SendKeys(name);
            Password.SendKeys(password);
            ConfirmButton.Click();
        }

        public void VerifyFailLogin()
        {
            Assert.IsTrue(FailLogin.Displayed,"User was log in");
        }

        public void VerifySuccessLogin()
        {
            Assert.IsFalse(FailLogin.Displayed, "User was not login");
        }
    }
}
