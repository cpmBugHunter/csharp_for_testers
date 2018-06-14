using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsTests : TestBase
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
            mngr.Navigator.GoToHomePage();
            mngr.Auth.Login(new AccountData("admin", "secret"));
            mngr.Contact.InitContactCreation();
            mngr.Contact.FillContactForm(contact);
            mngr.Contact.SubmitContactCreation();            
        }                              
                
    }
}
