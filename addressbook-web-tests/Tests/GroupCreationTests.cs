using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            session.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            groupHelper.FillGroupForm(new GroupData("New Group"));
            groupHelper.SubmitGroupCreation();
            navigator.ReturnToGroupsPage();
            session.Logout();
        }           
                
    }
}
