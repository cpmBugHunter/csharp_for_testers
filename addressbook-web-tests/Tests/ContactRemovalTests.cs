using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {        
        [SetUp]
        public void BeforeTest()
        {
            if (!mngr.Contact.IsPresent())
            {
                ContactData contact = new ContactData
                {
                    Name = "Name",
                    LastName = "LastName"
                };

                mngr.Contact.Create(contact);                
                mngr.Navigator.GoToHomePage(); 
            }
        }

        [Test]
        public void ContactRemoveTest()
        {
            mngr.Contact.Remove(1);
        }        
    }
}
