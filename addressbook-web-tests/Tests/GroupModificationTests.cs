using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData newGroup = new GroupData("Modified Group", "New header", "New footer");

            mngr.Group.Modify(1, newGroup);
        }
    }
}
