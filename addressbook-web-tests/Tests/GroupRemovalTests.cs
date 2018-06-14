using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            mngr.Group.Remove(1);
            mngr.Navigator.GoToGroupsPage();
            mngr.Group
                .Select(1)
                .Delete();
            mngr.Navigator.ReturnToGroupsPage();
        }        
    }
}
