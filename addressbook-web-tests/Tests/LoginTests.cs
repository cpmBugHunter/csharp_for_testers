using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            mngr.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            mngr.Auth.Login(account);
            Assert.IsTrue(mngr.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            mngr.Auth.Logout();
            AccountData account = new AccountData("admin", "123");
            mngr.Auth.Login(account);
            Assert.IsFalse(mngr.Auth.IsLoggedIn(account));
        }
    }
}
