using System;
using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        
        public ContactHelper(ApplicationManager manager) : base(manager)
        {                    
        }

        public ContactHelper InitCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        

        public ContactHelper FillForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.EMail);
            Type(By.Name("email2"), contact.EMail2);
            Type(By.Name("email3"), contact.EMail3);                        
          
            return this;
        }

        public ContactHelper SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper InitModification(int index, ContactData newContact)
        {
           // "//tr[@name = "entry"][2]//img[@title ="Edit"]"
            driver.FindElement(By.XPath("(//tr[@name='entry'])[" + index + "]//img[@title ='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            Select(index);
            Delete();
            return this;
        }
        
        private ContactHelper Select(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper Delete()
        {
            driver.FindElement(By.XPath("//input[@value = 'Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
