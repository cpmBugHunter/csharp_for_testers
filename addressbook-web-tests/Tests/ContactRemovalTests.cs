using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    class ContactRemovalTests : TestBase
    {

        //Такой код не смог заставить работать
        /*[TestFixtureSetUp]
        public void Setup()
        {
            ContactData contact = new ContactData
            {
                Name = "Name",
                LastName = "LastName"
            };

            mngr.Contact.InitCreation();
            mngr.Contact.FillForm(contact);
            mngr.Contact.SubmitCreation();
        }*/

        [Test]
        public void ContactRemoveTest()
        {
            ContactData contact = new ContactData
            {
                Name = "Name",
                LastName = "LastName"
            };

            mngr.Contact.InitCreation();
            mngr.Contact.FillForm(contact);
            mngr.Contact.SubmitCreation();

            mngr.Contact.Remove(1);
        }
    }
}
