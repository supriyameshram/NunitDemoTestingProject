using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoTestingProject.PageObjects
{
    class Logout_Page
    {
        IWebDriver driver;

        //Locator for logout button
        [FindsBy(How = How.LinkText, Using = "Log out")]
        IWebElement logout;


        public Logout_Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Logout method 
        public void LogoutFromApplication()
        {
            logout.Click();
            IAlert alert = driver.SwitchTo().Alert();
            if (alert.Text == "You Have Succesfully Logged Out!!")
            {
                alert.Accept();
            }
        }//end method LogoutFromApplication


    }
}
