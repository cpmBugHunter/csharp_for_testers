using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager mngr;

        [SetUp]
        public void SetupTest()
        {
            mngr = ApplicationManager.GetInstance();            
        }                
    }
}
