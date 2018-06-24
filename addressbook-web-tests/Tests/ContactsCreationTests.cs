using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        private int numbers;

        [Test]
        public void ContactCreationTest()
        {
            numbers = mngr.Generator.GetRandomIntBetween(1, 100);
            ContactData contact = new ContactData()
            {
                Name = "John",
                LastName = "Galt",
                Address = $"City, Street, b {numbers}, ap.{mngr.Generator.GetRandomIntBetween(1, 100)}",
                HomePhone = $"{numbers}{mngr.Generator.GetRandomIntBetween(1, 100)}",
                WorkPhone = $"{numbers}-{mngr.Generator.GetRandomIntBetween(1, 500)}",
                MobilePhone = $"{numbers}-{numbers}-{mngr.Generator.GetRandomIntBetween(1, 1000)}",
                EMail = "Main@mail.net",
                EMail2 = "Mail2@mail.net",
                EMail3 = "Mail3@mail.net"
            };

            List<ContactData> oldContacts = mngr.Contact.GetList();
            mngr.Contact.Create(contact);
            List<ContactData> newContacts = mngr.Contact.GetList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }                              
                
    }
}
