using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {        
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {                
                groups.Add(new GroupData(DataGenerator.GenerateRandomString(30))
                {
                    Header = DataGenerator.GenerateRandomString(100),
                    Footer = DataGenerator.GenerateRandomString(100)
                });

            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {            
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

            Assert.AreEqual(oldGroups.Count, mngr.Group.GetCount());

            List<GroupData> newGroups = mngr.Group.GetList();            
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
