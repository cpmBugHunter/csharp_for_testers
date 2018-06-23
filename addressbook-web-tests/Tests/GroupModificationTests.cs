using NUnit.Framework;
using System.Collections.Generic;

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
            GroupData newGroup = new GroupData("Modified Group");

            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Modify(0, newGroup);
            List<GroupData> newGroups = mngr.Group.GetList();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);           
        }
    }
}
