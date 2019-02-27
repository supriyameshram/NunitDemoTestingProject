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

        string register_Query = "select user_name, dob, addr, city, state, pin, mobile_no, email, password from new_registration_data";

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

            register_Page.open_Newcustomer_link();

            var register_data = db.Execute_register_query(register_Query);
          
                register_Page.set_name(register_data[0]);
                register_Page.set_dob(register_data[1]);
                register_Page.set_addr(register_data[2]);
                register_Page.set_city(register_data[3]);
                register_Page.set_state(register_data[4]);
                register_Page.set_pinno(register_data[5]);
                register_Page.set_telephoneno(register_data[6]);
                register_Page.set_emailid(register_data[7]);
                register_Page.set_password(register_data[8]);


            register_Page.click_submit();

            int cust_id = register_Page.get_id();
            string insert_Query = "insert into add_newaccount(cust_id, initial_deposit) " + "Values('"+ cust_id + "', '" + 10000 +"')";
            db.Execute_insert_query(insert_Query);

            register_Page.click_continue_link();
            logout_Page.LogoutFromApplication();
            driver.Close();


               
            }

        }
    }


