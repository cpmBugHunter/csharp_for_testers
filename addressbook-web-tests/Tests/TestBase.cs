using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager mngr;

        [SetUp]
        public void SetupTest()
        {
            mngr = new ApplicationManager();
            mngr.Navigator.GoToHomePage();
            mngr.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            mngr.Stop();
        }                     

    }
}
