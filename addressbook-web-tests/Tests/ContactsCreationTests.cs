using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        private static int numbers;
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                numbers = DataGenerator.GetRandomIntBetween(1, 100);
                groups.Add(new ContactData()
                {
                    FirstName = DataGenerator.GenerateRandomString(10),
                    LastName = DataGenerator.GenerateRandomString(15),
                    Address = $"{DataGenerator.GenerateRandomString(10)}," +
                    $"{DataGenerator.GenerateRandomString(15)}," +
                    $"b {numbers}, ap.{DataGenerator.GetRandomIntBetween(1, 100)}",
                    HomePhone = $"{numbers}{DataGenerator.GetRandomIntBetween(1, 100)}",
                    WorkPhone = $"{numbers}-{DataGenerator.GetRandomIntBetween(1, 500)}",
                    MobilePhone = $"{numbers}-{numbers}-{DataGenerator.GetRandomIntBetween(1, 1000)}",
                    EMail = DataGenerator.GenerateRandomString(15),
                    EMail2 = DataGenerator.GenerateRandomString(15),
                    EMail3 = DataGenerator.GenerateRandomString(15)
                });

            }
            return groups;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {   

            List<ContactData> oldContacts = mngr.Contact.GetList();
            mngr.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, mngr.Contact.GetCount());

            List<ContactData> newContacts = mngr.Contact.GetList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }                              
                
    }
}
