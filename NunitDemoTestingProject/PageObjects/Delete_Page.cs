using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoTestingProject.PageObjects
{
    class Delete_Page
    {
        IWebDriver driver;
        [FindsBy(How = How.LinkText, Using = "Delete Customer")]
        IWebElement delete_link;

        [FindsBy(How = How.Name, Using = "cusid")]
        IWebElement cust_id;

        [FindsBy(How = How.Name, Using = "AccSubmit")]
        IWebElement submit;

        public Delete_Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void click_Deletecustomer_Link()
        {
            delete_link.Click();
        }

        public void enter_CustomerID(String id)
        {
            cust_id.SendKeys(id);
        }

        public void click_Submit()
        {
            submit.Click();
            IAlert alert = driver.SwitchTo().Alert();
            if (alert.Text == "Do you really want to delete this Customer?")
            {
                alert.Accept();
            }
        }

        public void handleAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            if(alert.Text == "Customer deleted Successfully")
            {
                alert.Accept();
            }
        }

    }
}
