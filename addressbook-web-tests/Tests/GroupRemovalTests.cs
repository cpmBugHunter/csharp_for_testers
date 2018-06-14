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
        }        
    }
}
