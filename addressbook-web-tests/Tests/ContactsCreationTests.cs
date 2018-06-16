using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {
        ContactData contact = new ContactData("John",
                "Galt",
                "City, Street, 12 ap 34",
                "11111",
                "222-222",
                "333-333-333",
                "Main@mail.net",
                "Mail2@mail.net",
                "Mail3@mail.net");
        

        [Test]
        public void ContactCreationTest()
        {
            mngr.Contact.InitCreation();
            mngr.Contact.FillForm(contact);
            mngr.Contact.SubmitCreation();            
        }                              
                
    }
}
