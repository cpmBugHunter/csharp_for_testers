﻿using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            mngr.Navigator.GoToGroupsPage();
            if (!mngr.Group.IsPresent())
            {
                GroupData group = new GroupData("To be removed");                

                mngr.Group.Create(group);                
            }
            return;
        }

        [Test]
        public void GroupRemoveTest()
        {
            List<GroupData> oldGroups = mngr.Group.GetList();
            mngr.Group.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, mngr.Group.GetCount());

            List<GroupData> newGroups = mngr.Group.GetList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }        
    }
}
