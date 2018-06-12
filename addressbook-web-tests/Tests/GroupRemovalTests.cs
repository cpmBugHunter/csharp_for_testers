using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            mngr.Navigator.GoToHomePage();
            mngr.Auth.Login(new AccountData("admin", "secret"));
            mngr.Navigator.GoToGroupsPage();
            mngr.GroupHelper.SelectGroup(1);
            mngr.GroupHelper.DeleteGroup();
            mngr.Navigator.ReturnToGroupsPage();
        }        
    }
}
