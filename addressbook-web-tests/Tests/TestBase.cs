using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager mngr;

        [SetUp]
        public void SetupApplicationManager()
        {            
            mngr = ApplicationManager.GetInstance();            
        }                
    }
}
