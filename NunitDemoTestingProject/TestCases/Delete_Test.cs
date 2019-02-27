using NUnit.Framework;
using NunitDemoTestingProject.PageObjects;
using NunitDemoTestingProject.testData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoTestingProject.TestCases
{
    [TestFixture]
    class Delete_Test
    {
        IWebDriver driver;

        string select_Query = "select cust_id from add_newaccount";
       
        string login_Query = "select user_name, password from valid_login_data";

        DatabaseConnection db = new DatabaseConnection();

        [Test(Description = "delete test method")]
        public void Deletetest()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Url = ConfigurationManager.AppSettings["URL"]; //Passing the url to the driver

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Login_Page loginpage = new Login_Page(driver); //Creating the instance of login page

            Logout_Page logout_Page = new Logout_Page(driver); //creating the instance of logout page

            Delete_Page delete_Page = new Delete_Page(driver);

            var credentials = db.Execute_query(login_Query); //Getting the result of query into variable

            foreach (KeyValuePair<String, String> entry in credentials)
            {
                loginpage.LoginToApplication(entry.Key, entry.Value);

            }

            delete_Page.click_Deletecustomer_Link();

            var result = db.Execute_delete_query(select_Query);

            delete_Page.enter_CustomerID(result[0]);

            String delete_Query = "delete from add_newaccount where cust_id = " + Int32.Parse(result[0]);

            String result1 = db.Execute_delete_query(delete_Query).ToString();       

            delete_Page.click_Submit();

            delete_Page.handleAlert();

            logout_Page.LogoutFromApplication();

            driver.Close();

        }

    }
}
