using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace TestFrameworkHomeTask.Factory
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                default:
                    throw new System.Exception("Incorrect BrowserName");
            }
        }
    }
}

