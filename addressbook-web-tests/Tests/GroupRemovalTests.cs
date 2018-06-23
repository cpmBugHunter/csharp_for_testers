using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            if (!mngr.Group.IsPresent())
            {
                GroupData group = new GroupData("To be removed");                

                mngr.Group.Create(group);
                mngr.Navigator.GoToHomePage();
            }
        }

        [Test]
        public void GroupRemoveTest()
        {
            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Remove(0);
            List<GroupData> newGroups = mngr.Group.GetList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }        
    }
}
