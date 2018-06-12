using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        

        public GroupHelper(IWebDriver driver) : base(driver)
        {            
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupData group)
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
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();

        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
