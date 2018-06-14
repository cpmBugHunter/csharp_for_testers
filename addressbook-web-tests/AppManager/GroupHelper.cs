using System;
using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        

        public GroupHelper(ApplicationManager manager) : base(manager)
        {            
        }

        public void Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            Select(index);
            Delete();
            manager.Navigator.ReturnToGroupsPage();
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitCreation();
            FillForm(group);
            SubmitCreation();
            return this;
        }

        public GroupHelper InitCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            if (!string.IsNullOrWhiteSpace(group.Header))
            {
                driver.FindElement(By.Name("group_header")).Clear();
                driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            }
            if (!string.IsNullOrWhiteSpace(group.Footer))
            {
                driver.FindElement(By.Name("group_footer")).Clear();
                driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            }
            return this;
        }

        public GroupHelper SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper Select(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper Delete()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
