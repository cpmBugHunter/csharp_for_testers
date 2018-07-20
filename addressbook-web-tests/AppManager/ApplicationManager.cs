using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

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
        //protected DataGenerator generator;

        //делаем менеджера многопоточным
        private static ThreadLocal<ApplicationManager> mngr = new ThreadLocal<ApplicationManager>();

        public SessionHelper Auth { get => session; set => session = value; }
        public ContactHelper Contact { get => contactHelper; set => contactHelper = value; }
        public GroupHelper Group { get => groupHelper; set => groupHelper = value; }
        public NavigationHelper Navigator { get => navigator; set => navigator = value; }
        public IWebDriver Driver { get => driver; set => driver = value; }
        public string BaseURL { get => baseURL; set => baseURL = value; }
        //public DataGenerator Generator { get => generator; set => generator = value; }


        //спрятали конструктор, чтобы вызывать его только через GetInstance()
        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:81";
            session = new SessionHelper(this);
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);
            navigator = new NavigationHelper(this);
            //generator = new DataGenerator(this);
        }

        //destructor вызывается автоматически
        ~ApplicationManager()
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

        //Создаем менеджера для каждого потока
        public static ApplicationManager GetInstance()
        {
            if(!mngr.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                mngr.Value = newInstance;
            }
            return mngr.Value;
        }
        
    }
}
