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
            if (!string.IsNullOrWhiteSpace(contact.Name))
            {
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            }
            if (!string.IsNullOrWhiteSpace(contact.LastName))
            {
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName); 
            }
            if (!string.IsNullOrWhiteSpace(contact.Address))
            {
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(contact.Address); 
            }
            if (!string.IsNullOrWhiteSpace(contact.HomePhone))
            {
                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            }
            if (!string.IsNullOrWhiteSpace(contact.MobilePhone))
            {
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            }
            if (!string.IsNullOrWhiteSpace(contact.WorkPhone))
            {
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            }
            if (!string.IsNullOrWhiteSpace(contact.EMail))
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(contact.EMail);
            }
            if (!string.IsNullOrWhiteSpace(contact.EMail2))
            {
                driver.FindElement(By.Name("email2")).Clear();
                driver.FindElement(By.Name("email2")).SendKeys(contact.EMail2);
            }
            if (!string.IsNullOrWhiteSpace(contact.EMail3))
            {
                driver.FindElement(By.Name("email3")).Clear();
                driver.FindElement(By.Name("email3")).SendKeys(contact.EMail3);
            }  
          
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
