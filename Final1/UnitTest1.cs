using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;


namespace TestProject1
{
    public class Tests
    {
        String test_url = "https://www.saucedemo.com/";
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Uc1()
        {
            driver.Url = test_url;

            System.Threading.Thread.Sleep(5000);
            //Type any credentials into "Username" and "Password" fields.
            IWebElement user = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
            user.SendKeys("Any user");

            IWebElement pass = driver.FindElement(By.XPath("//*[@id='password']"));
            pass.SendKeys("Any pass");

            System.Threading.Thread.Sleep(5000);
            //Clear the inputs.
            user.Clear();
            pass.Clear();

            System.Threading.Thread.Sleep(5000);
            //Hit the "Login" button.
            IWebElement loginb = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            loginb.Click();

            //Check the error messages: "Username is required".
            IWebElement msg = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("Epic sadface: Username is required", msg.Text);
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Uc2()
        {
            driver.Url = test_url;

            System.Threading.Thread.Sleep(5000);
            //Type any credentials in "Username" and enter "Password.
            IWebElement user = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
            user.SendKeys("Any user");

            IWebElement pass = driver.FindElement(By.XPath("//*[@id='password']"));
            pass.SendKeys("Any pass");

            System.Threading.Thread.Sleep(5000);
            //Clear the password.
            pass.Clear();

            System.Threading.Thread.Sleep(5000);
            //Hit the "Login" button.
            IWebElement loginb = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            loginb.Click();

            //Check the error messages: "Password is required".
            IWebElement msg = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("Password is required", msg.Text);
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Uc3()
        {
            driver.Url = test_url;

            System.Threading.Thread.Sleep(5000);
            //Type credentials in username which are under Accepted username are sections.
            IWebElement user = driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
            user.SendKeys("standard_user");

            //Enter password as secret sauce.
            IWebElement pass = driver.FindElement(By.XPath("//*[@id='password']"));
            pass.SendKeys("secret_sauce");
            System.Threading.Thread.Sleep(5000);

            //Hit the "Login" button.
            IWebElement loginb = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            loginb.Click();

            //validate the title “Swag Labs” in the dashboard.
            IWebElement swag = driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div"));
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("Swag Labs", swag.Text);
            System.Threading.Thread.Sleep(5000);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}