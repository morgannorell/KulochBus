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
        public string FirstName;
        public string LastName;
        public string SecurityNr;
        public string Address;
        public string Zipcode;
        public string City;
        public string Email;
        public string Gender;


        public Person(string firstName, string lastName, string securityNr, string address, string zipcode, string city, string email, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            SecurityNr = securityNr;
            Address = address;
            Zipcode = zipcode;
            City = city;
            Email = email;
            Gender = gender;
        }

        public int createPerson()
        {
            NpgsqlConnection conn = new NpgsqlConnection
                ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");
            try
            {
                conn.Open();

                string sqlPerson = "INSERT INTO person (firstname, lastname, securitynr, address, zipcode, city, email, gender) values ('" + FirstName + "', '" + LastName + "', '" + SecurityNr + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "', '" + Gender + "') RETURNING personid;";
                
                //executes command string
                NpgsqlCommand cmd = new NpgsqlCommand(sqlPerson, conn);

                //fetch data
                NpgsqlDataReader dr = cmd.ExecuteReader();
                var id = 0;

                //sets id to that of personid through loop with datareader
                while(dr.Read())
                {
                    id = (int)dr["personid"];
                }

                dr.Close();
                conn.Close();

                //returns id to be used in other classes
                return id;
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            } 
        }
    }
}
