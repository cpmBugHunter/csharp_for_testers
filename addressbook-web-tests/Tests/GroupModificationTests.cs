using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            if (!mngr.Group.IsPresent())
            {
                GroupData group = new GroupData("To be modified");

                mngr.Group.Create(group);
                mngr.Navigator.GoToHomePage();
            }
        }

        [Test]
        public void GroupModifyTest()
        {
            GroupData newGroup = new GroupData("Modified Group", "New header", "New footer");

            mngr.Group.Modify(1, newGroup);
        }
    }
}
