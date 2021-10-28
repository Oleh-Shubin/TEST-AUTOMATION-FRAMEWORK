using NUnit.Framework;
using TestFrameworkHomeTask.PageObject.Authentication.Login;
using TestFrameworkHomeTask.Tests;

namespace Test
{
    public class Tests : BaseTest
    {
        protected string incorrectName = "Oleh";
        protected string incorrectPassword = "1234567";
        protected string correctName = "webres_";
        protected string correctPassword = "ax4885vn";

        [Test(Description = "C2")]
        public void LoginWithIncorectData()
        {
            OpenPage();
            LoginWebPart loginwebpart = new LoginWebPart(driver);
            loginwebpart.Login(incorrectName, incorrectPassword);
            loginwebpart.VerifyFailLogin();
        }

        [Test(Description = "C1")]
        public void LoginWithCorectData()
        {
            OpenPage();
            LoginWebPart loginwebpart = new LoginWebPart(driver);
            loginwebpart.Login(correctName, correctPassword);
            loginwebpart.VerifySuccessLogin();
        }
    }
}