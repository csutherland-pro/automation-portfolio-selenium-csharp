using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharp {
    public class Tests {
        IWebDriver driver;

        [SetUp]
        public void Setup() {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            driver = new ChromeDriver(options);
        }

        [TearDown]
        public void Teardown() {
            driver.Quit(); // Closes the browser window and ends the session
            driver.Dispose(); // Releases all managed and unmanaged resources
        }

        [Test]
        public void ValidLogin() {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("button[type=submit]")).Click();
            Assert.That(driver.PageSource.Contains("You logged into a secure area!"), Is.True);
        }
    }
}
