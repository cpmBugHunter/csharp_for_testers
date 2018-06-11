using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected SessionHelper session;
        protected ContactHelper contactHelper;
        protected GroupHelper groupHelper;
        protected NavigationHelper navigator;
        protected string baseURL;
        


        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
            session = new SessionHelper(driver);
            contactHelper = new ContactHelper(driver);
            groupHelper = new GroupHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }                     

    }
}
