using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class ContactData
    {
        private string name;
        private string middleName;
        private string lastName;
        private string company;
        private string address;
        private string homePhone;
        private string workPhone;
        private string mobilePhone;
        private string eMail;
        private string eMail2;
        private string eMail3;

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
            this.Name = name;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Company = company;
            this.Address = address;
            this.HomePhone = homePhone;
            this.WorkPhone = workPhone;
            this.MobilePhone = mobilePhone;
            this.EMail = eMail;
            this.EMail2 = eMail2;
            this.EMail3 = eMail3;
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
