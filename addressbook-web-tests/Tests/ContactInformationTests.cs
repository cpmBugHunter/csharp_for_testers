using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInfoFromTable_IsEqualTo_ContactInfoFromEditFormTest()
        {
            mngr.Navigator.GoToHomePage();
            ContactData fromTable = mngr.Contact.GetContactInfoFromTable(0);
            ContactData fromForm = mngr.Contact.GetContactInfoFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}
