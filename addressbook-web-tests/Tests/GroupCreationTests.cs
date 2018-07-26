using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        [Test, TestCaseSource("GroupDataFromJson")]
        public void GroupCreationTest(GroupData group)
        {            
            List<GroupData> oldGroups = GroupData.GetAll();
            mngr.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, mngr.Group.GetCount());

            List<GroupData> newGroups = GroupData.GetAll();
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
        public void DbConnectivityTest()
        {
            DateTime start = DateTime.Now;
            GroupData group = new GroupData("");
            List<GroupData> fromUi = mngr.Group.GetList();
            DateTime end = DateTime.Now;
            Console.Out.WriteLine($"Get groups from UI time = {end.Subtract(start)}, items quantity = {fromUi.Count}");

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();            
            end = DateTime.Now;
            Console.Out.WriteLine($"Get groups from DB time = {end.Subtract(start)}, items quantity = {fromDb.Count}");            
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


        //Data providers
        public static IEnumerable<GroupData> GroupDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText("groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromXml()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))
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

    }
}
