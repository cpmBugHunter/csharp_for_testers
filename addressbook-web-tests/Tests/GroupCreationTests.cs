using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("New Group");

            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, mngr.Group.GetCount());

            List<GroupData> newGroups = mngr.Group.GetList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");

            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, mngr.Group.GetCount());

            List<GroupData> newGroups = mngr.Group.GetList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");

            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, mngr.Group.GetCount());

            List<GroupData> newGroups = mngr.Group.GetList();            
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
