using NUnit.Framework;

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
            mngr.Group.Remove(1);           
        }        
    }
}
