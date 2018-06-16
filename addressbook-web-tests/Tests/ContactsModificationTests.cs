using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactsModificationTests : TestBase
    {
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
