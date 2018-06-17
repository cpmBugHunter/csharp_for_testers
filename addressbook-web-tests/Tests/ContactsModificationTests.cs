
using NUnit.Framework;
using OpenQA.Selenium;

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
                    Name = "Name",
                    LastName = "LastName"
                };

                mngr.Contact.Create(contact);
                mngr.Navigator.GoToHomePage();
            }
        }

        [Test]
        public void ChangeContactEmailTest()
        {
            ContactData newContact = new ContactData();
            newContact.EMail = "ModifiedMail@mail.org";

            mngr.Contact.InitModification(1, newContact);
            mngr.Contact.FillForm(newContact);
            mngr.Contact.SubmitModification();
        }
    }
}
