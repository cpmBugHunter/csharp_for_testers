using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace addressbook_web_tests.Tests
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
            navigator.GoToHomePage();
            session.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();            
        }                              
                
    }
}
