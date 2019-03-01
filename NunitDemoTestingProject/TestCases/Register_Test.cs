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
    class Register_Test
    {
        IWebDriver driver;

        string register_Query = "select user_name, dob, addr, city, state, pin, mobile_no, email, password, gender from new_registration_data";

        string login_Query = "select user_name, password from valid_login_data";

        DatabaseConnection db = new DatabaseConnection();


        [Test(Description = "register test method")]
        public void Registertest()
        {
             
            IWebDriver driver = new ChromeDriver();

            driver.Url = ConfigurationManager.AppSettings["URL"]; //Passing the url to the driver

            Login_Page loginpage = new Login_Page(driver); //Creating the instance of login page

            Logout_Page logout_Page = new Logout_Page(driver); //creating the instance of logout page

            Register_Page register_Page = new Register_Page(driver);

            var credentials = db.Execute_query(login_Query); //Getting the result of query into variable

            foreach (KeyValuePair<String, String> entry in credentials)
            {
                loginpage.LoginToApplication(entry.Key, entry.Value);

            }

            var register_data = db.Execute_register_query(register_Query);

            register_Page.add_credentials(register_data["Name"], register_data["Gender"], register_data["DOB"], register_data["Addr"], register_data["City"], register_data["State"], register_data["Pinno"], register_data["Telephoneno"], register_data["EmailID"], register_data["Password"]);

            int cust_id = register_Page.get_id();
            string insert_Query = "insert into add_newaccount(cust_id, initial_deposit) " + "Values('"+ cust_id + "', '" + 10000 +"')";
            db.Execute_insert_query(insert_Query);

            register_Page.click_continue_link();
            logout_Page.LogoutFromApplication();
            driver.Close();


               
            }

        }
    }


