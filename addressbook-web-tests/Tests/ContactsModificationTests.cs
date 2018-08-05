
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsModificationTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            if (!mngr.Contact.IsPresent())
            {
                ContactData contact = new ContactData
                {
                    FirstName = "Name",
                    LastName = "LastName"
                };

                mngr.Contact.Create(contact);
                mngr.Navigator.GoToHomePage();
            }
        }

        [Test]
        public void ChangeContactAddressDbTest()
        {
            ContactData newContact = new ContactData
            {
                Address = $"New City, Street, b {DataGenerator.GetRandomIntBetween(1, 100)}"
            };

            List<ContactData> oldContacts = ContactData.GetAll();
            var toBeModified = oldContacts[0];
            mngr.Contact.Modify(toBeModified, newContact);

            Assert.AreEqual(oldContacts.Count, mngr.Contact.GetCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Address = newContact.Address;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ChangeContactAddressTest()
        {            
            ContactData newContact = new ContactData
            {
                Address = $"New City, Street, b {DataGenerator.GetRandomIntBetween(1, 100)}"
            };

            List<ContactData> oldContacts = mngr.Contact.GetList();
            mngr.Contact.Modify(0, newContact);

            Assert.AreEqual(oldContacts.Count, mngr.Contact.GetCount());

            List<ContactData> newContacts = mngr.Contact.GetList();
            oldContacts[0].Address = newContact.Address;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
