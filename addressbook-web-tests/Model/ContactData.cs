using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }        

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name
                && LastName == other.LastName
                && Address == other.Address;
                //&& HomePhone == other.HomePhone
                //&& WorkPhone == other.WorkPhone
                //&& MobilePhone == other.MobilePhone
                //&& EMail == other.EMail
                //&& EMail2 == other.EMail2
                //&& EMail3 == other.EMail3;
        }

        public override int GetHashCode()
        {
            var hashCode = 1257958748;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HomePhone);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WorkPhone);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MobilePhone);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EMail);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EMail2);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EMail3);
            return hashCode;
        }

        public override string ToString()
        {
            return $"ContactData{{name = {Name}, " +
                $"lastName = {LastName}, " +
                $"address = {Address}, " +
                $"homePhone = {HomePhone}, " +
                $"workPhone = {WorkPhone}, " +
                $"mobilePhone = {MobilePhone}," +
                $"email = {EMail}, " +
                $"email2 = {EMail2}, " +
                $"email3 = {EMail3}}}";
        }
    }
}
