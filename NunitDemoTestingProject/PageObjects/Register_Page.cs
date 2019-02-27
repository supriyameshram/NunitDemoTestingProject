using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoTestingProject.PageObjects
{
    class Register_Page
    {
        IWebDriver driver;

        //Locators
        [FindsBy(How = How.LinkText, Using = "New Customer")]
        IWebElement linktext;

        [FindsBy(How = How.Name, Using = "name")]
        IWebElement name;

        [FindsBy(How = How.Name, Using = "rad1")]
        IWebElement gender;

        [FindsBy(How = How.Name, Using = "dob")]
        IWebElement dob;

        [FindsBy(How = How.Name, Using = "addr")]
        IWebElement addr;

        [FindsBy(How = How.Name, Using = "city")]
        IWebElement city;

        [FindsBy(How = How.Name, Using = "state")]
        IWebElement state;

        [FindsBy(How = How.Name, Using = "pinno")]
        IWebElement pinno;

        [FindsBy(How = How.Name, Using = "telephoneno")]
        IWebElement telephoneno;

        [FindsBy(How = How.Name, Using = "emailid")]
        IWebElement emailid;

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement password;

        [FindsBy(How = How.Name, Using = "sub")]
        IWebElement sub;

        [FindsBy(How = How.XPath, Using = ".//*[@id='customer']/tbody/tr[4]/td[2]")]
        IWebElement id;

        [FindsBy(How = How.XPath, Using = "//A[@href='Managerhomepage.php'][text()='Continue']")]
        IWebElement continue_link;

        public Register_Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void open_Newcustomer_link()
        {
            linktext.Click();
        }

        public void set_name(string Name)
        {
            name.SendKeys(Name);
        }

        public void select_gender()
        {
            gender.Click();
        }

        public void set_dob(string DOB)
        {
            dob.SendKeys(DOB);
        }

        public void set_addr(string Addr)
        {
            addr.SendKeys(Addr);
        }

        public void set_city(string City)
        {
            city.SendKeys(City);
        }

        public void set_state(string State)
        {
            state.SendKeys(State);
        }

        public void set_pinno(string Pinno)
        {
            pinno.SendKeys(Pinno);
        }

        public void set_telephoneno(string Telephoneno)
        {
            telephoneno.SendKeys(Telephoneno);
        }

        public void set_emailid(string EmailID)
        {
            emailid.SendKeys(EmailID);
        }

        public void set_password(string Password)
        {
            password.SendKeys(Password);
        }

        public void click_submit()
        {
            sub.Click();
        }

        public int get_id()
        {
            int id_Text = Int32.Parse(id.Text);
            return id_Text;
        }

        public void click_continue_link()
        {
            continue_link.Click();
        }


        public void add_credentials(string Name, string DOB, string Addr, string City, string State, string Pinno, string Telephoneno, string EmailID, string Password)
        {
            open_Newcustomer_link();
            set_name(Name);
            select_gender();
            set_dob(DOB);
            set_addr(Addr);
            set_city(City);
            set_state(State);
            set_pinno(Pinno);
            set_telephoneno(Telephoneno);
            set_emailid(EmailID);
            set_password(Password);
            click_submit();

        }

    } 

}
