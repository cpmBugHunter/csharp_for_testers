using NUnit.Framework;

namespace AddressbookWebTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {        

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager mngr = ApplicationManager.GetInstance();
            mngr.Navigator.GoToHomePage();
            mngr.Auth.Login(new AccountData("admin", "secret"));
        }        
    }
}
