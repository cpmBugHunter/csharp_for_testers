using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            navigator.GoToHomePage();
            session.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.DeleteGroup();
            navigator.ReturnToGroupsPage();
        }        
    }
}
