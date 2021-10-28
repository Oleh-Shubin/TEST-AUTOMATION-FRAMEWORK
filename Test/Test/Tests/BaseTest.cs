using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestFrameworkHomeTask.Factory;
using TestFrameworkHomeTask.Service.TestRail.Client;
using TestFrameworkHomeTask.Service.TestRail.Entities;
using TestRail.Enums;

namespace TestFrameworkHomeTask.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string url = "https://www.twitch.tv/";
        protected WebDriverWait waiter;
        protected string browser = "chrome";
        protected Client Client;
        protected readonly string Url = "https://webres.testrail.io";
        protected readonly string User = "thewebres@gmail.com";
        protected readonly string Password = "ax4885ax";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Client = new Client(Url, User, Password);         
        }

        [SetUp]
        public void BeforeTest()
        {
            driver = WebDriverFactory.CreateWebDriver(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(6000);
        }


        [TearDown]
        public virtual void BaseTeardown()
        {
            driver.Dispose();
            var id = TestContext.CurrentContext.Test.Properties.Get("Description").ToString().Replace("C", "");
            var result = TestContext.CurrentContext.Result.Outcome.Status;
            var testrailStatus = result switch
            {
                TestStatus.Failed => ResultStatus.Failed,
                TestStatus.Passed => ResultStatus.Passed,
                _ => ResultStatus.Retest
            };
            Client.AddResultToTestById(id, new AddResultEntity() { StatusId = ((int)testrailStatus) });
            }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

    }
}
