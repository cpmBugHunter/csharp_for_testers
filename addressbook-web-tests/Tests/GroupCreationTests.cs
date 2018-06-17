using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("New Group");
            
            mngr.Group.Create(group);
            mngr.Navigator.ReturnToGroupsPage();            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            
            mngr.Group.Create(group);
            mngr.Navigator.ReturnToGroupsPage();
        }
        
    }
}
