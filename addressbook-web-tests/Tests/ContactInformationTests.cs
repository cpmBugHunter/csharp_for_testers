using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            if (!mngr.Contact.IsPresent())
            {
                ContactData contact = new ContactData
                {
                    FirstName = "Name",
                    LastName = "LastName",
                    Address = "Some address 1/2",
                    EMail = "email@mail.net",
                    EMail3 = "email3@mail.net",
                    MobilePhone = "3565768-456"
                };

                mngr.Contact.Create(contact);
                mngr.Navigator.GoToHomePage();
            }
        }

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

        [Test]
        public void ContactInfoFromDetails_IsEqualTo_ContactInfoFromEditFormTest()
        {
            mngr.Navigator.GoToHomePage();
            ContactData fromForm = mngr.Contact.GetContactInfoFromEditForm(0);
            string fromDetails = mngr.Contact.GetInfoFromDetails(0);
            string fullName = MergeNames(fromForm);
            string phones = MergePhones(fromForm);            
            StringBuilder sb = new StringBuilder();
            string expected = sb.Append(fullName)
                .Append("\r\n")
                .Append(fromForm.Address)
                .Append("\r\n")
                .Append(phones)
                .Append(fromForm.AllEmails)
                .ToString();
            Assert.AreEqual(expected.Trim(), CleanedPhones(fromDetails).Trim());
        }

        private string MergePhones(ContactData contact)
        {
            string[] phones = new string[] { contact.HomePhone, contact.MobilePhone, contact.WorkPhone };
            StringBuilder sb = new StringBuilder();
            foreach (var phone in phones)
            {
                if (!string.IsNullOrEmpty(phone))
                {
                    sb.Append(phone);
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }

        private string MergeNames(ContactData contact)
        {
            string[] names = new string[] { contact.FirstName, contact.MiddleName, contact.LastName };
            StringBuilder sb = new StringBuilder();
            foreach (var name in names)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    sb.Append(name);
                    sb.Append(" ");                    
                }
            }
            return sb.ToString().Trim();
        }

        private string CleanedPhones(string phones)
        {            
            Regex regex1 = new Regex(@"[HMW]: ");
            string result = regex1.Replace(phones, "");
            Regex regex2 = new Regex("(\r\n){2,}");
            return regex2.Replace(result, "\r\n");
        }
    }
}
