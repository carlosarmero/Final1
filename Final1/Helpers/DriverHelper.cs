using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace YourNamespace.Helpers
{
    public class DriverHelper
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (driver == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    default:
                        throw new ArgumentException("Browser not supported");
                }
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}

