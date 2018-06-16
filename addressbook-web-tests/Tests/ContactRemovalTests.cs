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
        [SetUp]
        public void BeforeTest()
        {
            if (true)
            {
                ContactData contact = new ContactData
                {
                    Name = "Name",
                    LastName = "LastName"
                };

                mngr.Contact.InitCreation();
                mngr.Contact.FillForm(contact);
                mngr.Contact.SubmitCreation();
                mngr.Navigator.GoToHomePage(); 
            }
        }

        [Test]
        public void ContactRemoveTest()
        {
            mngr.Contact.Remove(1);
        }

        [Test]
        public void ContactRemoveTest1()
        {
            mngr.Contact.Remove(1);
        }
    }
}
