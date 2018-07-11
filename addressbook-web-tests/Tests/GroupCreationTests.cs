using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> GroupDataFromXml()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader("groups.xml"));            
        }

        public static IEnumerable<GroupData> GroupDataFromCsv()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines("groups.csv");
            foreach (var l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            } 
            return groups;
        }

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

        [Test, TestCaseSource("GroupDataFromXml")]
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
