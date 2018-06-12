using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager mngr;

        [SetUp]
        public void SetupTest()
        {
            mngr = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            mngr.Stop();
        }                     

    }
}
