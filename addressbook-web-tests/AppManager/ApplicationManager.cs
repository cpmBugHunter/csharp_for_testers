using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private string baseURL;
        protected SessionHelper session;
        protected ContactHelper contactHelper;
        protected GroupHelper groupHelper;
        protected NavigationHelper navigator;

        public SessionHelper Auth { get => session; set => session = value; }
        public ContactHelper Contact { get => contactHelper; set => contactHelper = value; }
        public GroupHelper Group { get => groupHelper; set => groupHelper = value; }
        public NavigationHelper Navigator { get => navigator; set => navigator = value; }
        public IWebDriver Driver { get => driver; set => driver = value; }
        public string BaseURL { get => baseURL; set => baseURL = value; }

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            session = new SessionHelper(this);
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);
            navigator = new NavigationHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
