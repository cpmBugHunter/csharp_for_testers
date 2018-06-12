using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            mngr.Navigator.GoToHomePage();
            mngr.Auth.Login(new AccountData("admin", "secret"));
            mngr.Navigator.GoToGroupsPage();
            mngr.GroupHelper.InitGroupCreation();
            mngr.GroupHelper.FillGroupForm(new GroupData("New Group"));
            mngr.GroupHelper.SubmitGroupCreation();
            mngr.Navigator.ReturnToGroupsPage();
            mngr.Auth.Logout();
        }           
                
    }
}
