using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoTestingProject.PageObjects
{
    class Login_Page
    {
        IWebDriver driver;

        //Locator for username
        [FindsBy(How = How.Name, Using = "uid")]
        IWebElement UserName;

        //Locator for password
        [FindsBy(How = How.Name, Using = "password")]
        IWebElement Password;

        //Locator for login button
        [FindsBy(How = How.Name, Using = "btnLogin")]
        IWebElement login;

        //Locator for logout button
        [FindsBy(How = How.LinkText, Using = "Log out")]
        IWebElement logout;


        //Constructor for initialization 
        public Login_Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //Login method 
        public void LoginToApplication(string username, string password)
        {
            try
            {
                UserName.SendKeys(username);
                Password.SendKeys(password);
                login.Submit();
            }

            catch (StaleElementReferenceException ex)
            {         
                UserName.SendKeys(username);
                Password.SendKeys(password);
            }
            //end try-catch


        }//end method LoginToApplication


        ////Logout method
        //public void LogoutFromApplication()
        //{
        //    logout.Click();
        //    IAlert alert = driver.SwitchTo().Alert();
        //    if (alert.Text == "You Have Succesfully Logged Out!!")
        //        {
        //        alert.Accept();
        //        }
        //}//end method LogoutFromApplication


        //method for handling alert
        public IAlert alertHandle()
        {
            IAlert alert = null;
            try
            {
                 alert = driver.SwitchTo().Alert();
                if (alert != null)
                {
                    if (alert.Text == "User or Password is not valid")
                    {
                        alert.Accept();

                        Console.WriteLine("Username or password is not valid.");
                    }

                }
            }

            catch (NoAlertPresentException)
            {
                Console.WriteLine("Login Successful");
            }
            return alert;
        }//end method alertHandle


        //start method refresh
        public void refresh()
        {
            this.driver.Navigate().GoToUrl("http://demo.guru99.com/v4/");
        }//end method refresh
    }//end class
}//end namespace
