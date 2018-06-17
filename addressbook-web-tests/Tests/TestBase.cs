using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager mngr;

        [SetUp]
        public void SetupApplicationManager()
        {
            mngr = ApplicationManager.GetInstance();            
        }                
    }
}
