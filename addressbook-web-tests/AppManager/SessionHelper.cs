﻿using System;
using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class SessionHelper : HelperBase
    {        

        public SessionHelper(ApplicationManager manager) : base(manager)
        {            
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);            
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Username;                
        }

        public string GetLoggedUsername()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;                
            return text.Substring(1, text.Length - 2);
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Name("logout")).Click(); 
            }
        }
    }
}
