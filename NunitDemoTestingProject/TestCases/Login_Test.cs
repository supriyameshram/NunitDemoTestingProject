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
    class Login_Test
    {
        string Query = "select user_name, password from login_data";

        DatabaseConnection db = new DatabaseConnection();     


        [Test (Description = "Login test method")]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = ConfigurationManager.AppSettings["URL"]; //Passing the url to the driver

            Login_Page loginpage = new Login_Page(driver); //Creating the instance of login page

            Logout_Page logout_Page = new Logout_Page(driver); //creating the instance of logout page

            var credentials = db.Execute_query(Query); //Getting the result of query into variable

            foreach(KeyValuePair<String, String>entry in credentials) {
                loginpage.LoginToApplication(entry.Key, entry.Value); 
                

                IAlert alert = loginpage.alertHandle();
                if (alert == null)
                {
                    logout_Page.LogoutFromApplication();
                    loginpage.refresh();
                }
               
               // loginpage.refresh();
            }//end forEach
          

            driver.Close();
        }//end TestMethod
    }//end class
}//end namespace
