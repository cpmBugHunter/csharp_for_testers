using NUnit.Framework;
using System.Collections.Generic;

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
            List<ContactData> oldContacts = mngr.Contact.GetList();
            mngr.Contact.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, mngr.Contact.GetCount());

            List<ContactData> newContacts = mngr.Contact.GetList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }        
    }
}
