using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    class Person
    {
        //public string FirstName;
        //public string LastName;
        //public string SecurityNr;
        //public string Address;
        //public string Zipcode;
        //public string City;
        //public string Email;
        //public string Gender;


        //public Person(string firstName, string lastName, string securityNr, string address, string zipcode, string city, string email, string gender)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    SecurityNr = securityNr;
        //    Address = address;
        //    Zipcode = zipcode;
        //    City = city;
        //    Email = email;
        //    Gender = gender;
        //}

        // TEST

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string SecurityNr { get; set; }
        public string Address { get; set;  }
        public string Zipcode { get; set; }
        public string City { get; set;  }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Responsibility { get; set; }
        public string Membership { get; set; }
        public bool Picture { get; set; }
        public bool Leader { get; set; }
        public bool payed { get; set; }
        public string Homeareacode { get; set; }
        public string Homephone { get; set; }
        public string Mobilecode { get; set; }
        public string Mobilephone { get; set; }

        public void CreatePersonTest()
        {
            Sql member = new Sql();
            member.Connect();

            string insert = "START TRANSACTION; " +
                "WITH id AS (" +
                "INSERT INTO person " +
                "(securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
                "VALUES ('" 
                + SecurityNr + "', '" 
                + Firstname + "', '" 
                + LastName + "', '" 
                + Gender + "', '" 
                + Address + "', '" 
                + Zipcode + "', '" 
                + City + "', '" 
                + Email + "') " + 
                "RETURNING personid), " + 
                "pid AS (" +
                "INSERT INTO phone (personid, areacode, phone) SELECT id.personid, '" + Homeareacode + "', '" + Homephone + "' " +
                "FROM id RETURNING personid) INSERT INTO member (memberid, responsibility, membership, pictureallowed, isleader, ispayed) " +
                "SELECT pid.personid, '" + Responsibility + "', '" + Membership + "', " + Picture + ", " + Leader + ", " + payed + " FROM pid; " +
                "COMMIT;";

            member.Insert(insert);
            member.Close();
        }

        //public int createPerson()
        //{
        //    NpgsqlConnection conn = new NpgsqlConnection
        //        ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");
        //    try
        //    {
        //        conn.Open();

        //        string sqlPerson = "INSERT INTO person (firstname, lastname, securitynr, address, zipcode, city, email, gender) values ('" + FirstName + "', '" + LastName + "', '" + SecurityNr + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "', '" + Gender + "') RETURNING personid;";
                
        //        //executes command string
        //        NpgsqlCommand cmd = new NpgsqlCommand(sqlPerson, conn);

        //        //fetch data
        //        NpgsqlDataReader dr = cmd.ExecuteReader();
        //        var id = 0;

        //        //sets id to that of personid through loop with datareader
        //        while(dr.Read())
        //        {
        //            id = (int)dr["personid"];
        //        }

        //        dr.Close();
        //        conn.Close();

        //        //returns id to be used in other classes
        //        return id;
        //    }

        //    catch (NpgsqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return 0;
        //    } 
        //}
    }
}
