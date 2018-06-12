using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AddressbookWebTests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;        
        protected string baseURL;
        private SessionHelper session;
        private ContactHelper contactHelper;
        private GroupHelper groupHelper;
        private NavigationHelper navigator;

        public SessionHelper Auth { get => session; set => session = value; }
        public ContactHelper ContactHelper { get => contactHelper; set => contactHelper = value; }
        public GroupHelper GroupHelper { get => groupHelper; set => groupHelper = value; }
        public NavigationHelper Navigator { get => navigator; set => navigator = value; }

        public ApplicationManager()
        {
            Auth = session;
            ContactHelper = contactHelper;
            GroupHelper = groupHelper;
            Navigator = navigator;
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
