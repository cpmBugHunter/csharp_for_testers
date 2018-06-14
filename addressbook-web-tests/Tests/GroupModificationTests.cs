using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            mngr.Group.Modify(1);
        }
    }
}
