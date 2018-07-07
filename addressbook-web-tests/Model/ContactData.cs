using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public string EMail2 { get; set; }
        public string EMail3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }
            return Regex.Replace(phone, "[-( )]", "") + "\r\n";
        }

        public string AllEmails { get => allEmails; set => allEmails = value; }

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
            FirstName = name;            
            LastName = lastName;            
            Address = address;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
            EMail = eMail;
            EMail2 = eMail2;
            EMail3 = eMail3;
        }        

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
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
            return FirstName == other.FirstName
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
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
            return $"ContactData{{name = {FirstName}, " +
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
