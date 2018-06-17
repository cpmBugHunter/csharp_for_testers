using NUnit.Framework;

namespace AddressbookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {            
            mngr.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
