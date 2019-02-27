using System.Configuration;
using System.Data.Odbc;
using System;
using System.Collections.Generic;

namespace NunitDemoTestingProject.testData
{
    class DatabaseConnection
    {
        string username = " ", password = " ", dob = " ", addr = " ", city = " ", state = " ", pin = " ", mobile_no = " ", email = " ";
        string cust_id = " ";
        string strcon = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        Dictionary<String, String> credentials = new Dictionary<string, string>();
        List<String> items = new List<string>();
        List<String> item = new List<string>(); 


        public Dictionary<String, String> Execute_query(string Query)
        {
            OdbcConnection con = new OdbcConnection(strcon);
            con.Open();
            Console.WriteLine("Connection open");
            OdbcCommand command = new OdbcCommand(Query, con);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                username = reader.GetValue(0).ToString();
                password = reader.GetValue(1).ToString();

                credentials.Add(username, password);

            }

            return credentials;

        }

        public List<String> Execute_register_query(string Query)
        {
            OdbcConnection con = new OdbcConnection(strcon);
            con.Open();
            Console.WriteLine("Connection open");
            OdbcCommand command = new OdbcCommand(Query, con);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                username = reader.GetValue(0).ToString();
                dob = reader.GetValue(1).ToString();
                addr = reader.GetValue(2).ToString();
                city = reader.GetValue(3).ToString();
                state = reader.GetValue(4).ToString();
                pin = reader.GetValue(5).ToString();
                mobile_no = reader.GetValue(6).ToString();
                email = reader.GetValue(7).ToString();
                password = reader.GetValue(8).ToString();

                items.Add(username);
                items.Add(dob);
                items.Add(addr);
                items.Add(city);
                items.Add(state);
                items.Add(pin);
                items.Add(mobile_no);
                items.Add(email);
                items.Add(password);
                
            }
            return items;
        }

        public void Execute_insert_query(string Query)
        {
            OdbcConnection con = new OdbcConnection(strcon);
            con.Open();
            Console.WriteLine("Connection open");
            OdbcCommand command = new OdbcCommand(Query, con);
            command.ExecuteNonQuery();
        }

        public List<string> Execute_delete_query(string Query)
        {
            OdbcConnection con = new OdbcConnection(strcon);
            con.Open();
            Console.WriteLine("Connection open");
            OdbcCommand command = new OdbcCommand(Query, con);
            OdbcDataReader reader =  command.ExecuteReader();
            while(reader.Read())
            {
                cust_id = reader.GetValue(0).ToString();

                item.Add(cust_id);

            }
            return item;
    }
    }


}