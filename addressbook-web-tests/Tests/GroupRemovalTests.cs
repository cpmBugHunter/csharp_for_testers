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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
        }

        private void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ index +"]")).Click();            
        }

        private void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
