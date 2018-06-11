using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(new GroupData("New Group"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }           
                
    }
}
