using System;
using System.Collections.Generic;
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

        public bool IsPresent()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));            
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

        public int GetCount()
        {            
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper Modify(int index, ContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            InitModification(index);
            FillForm(newContact);
            SubmitModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id"),
                        LastName = element.FindElement(By.XPath("./td[2]")).Text,
                        Name = element.FindElement(By.XPath("./td[3]")).Text,
                        Address = element.FindElement(By.XPath("./td[4]")).Text
                    };
                    contactCache.Add(contact);
                }
            }
            
            return contactCache;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitCreation();
            FillForm(contact);
            SubmitCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitModification(int index)
        {           
            driver.FindElement(By.XPath("(//tr[@name='entry'])[" + (index + 1) + "]//img[@title ='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            Select(index);
            Delete();
            contactCache = null;
            manager.Navigator.GoToHomePage();
            return this;
        }
        
        private ContactHelper Select(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
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
