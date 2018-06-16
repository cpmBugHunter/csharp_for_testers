using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class ContactData
    {
        private string name = "";
        private string middleName = "";
        private string lastName = "";
        private string company = "";
        private string address = "";
        private string homePhone = "";
        private string workPhone = "";
        private string mobilePhone = "";
        private string eMail = "";
        private string eMail2 = "";
        private string eMail3 = "";

        public ContactData()
        {
        }

        public ContactData(string name,            
            string lastName,            
            string address,
            string homePhone,
            string workPhone,
            string mobilePhone,
            string eMail,
            string eMail2,
            string eMail3)
        {
            Name = name;
            MiddleName = middleName;
            LastName = lastName;
            Company = company;
            Address = address;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
            EMail = eMail;
            EMail2 = eMail2;
            EMail3 = eMail3;
        }

        public string Name { get => name; set => name = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Company { get => company; set => company = value; }
        public string Address { get => address; set => address = value; }
        public string HomePhone { get => homePhone; set => homePhone = value; }
        public string WorkPhone { get => workPhone; set => workPhone = value; }
        public string MobilePhone { get => mobilePhone; set => mobilePhone = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string EMail2 { get => eMail2; set => eMail2 = value; }
        public string EMail3 { get => eMail3; set => eMail3 = value; }
    }
}
