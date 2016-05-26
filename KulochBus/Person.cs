using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    //abstract klass (går endast att ärva från)
    public abstract class Person
    {
        public string MemberId { get; set; }
        public string PersonId { get; set; }
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
        public int Price { get; set; }
        public bool Leader { get; set; }
        public bool Payed { get; set; }
        public string Homeareacode { get; set; }
        public string Homephone { get; set; }
        public string Mobilecode { get; set; }
        public string Mobilephone { get; set; }

        //public void CreatePerson()
        //{
        //    Sql member = new Sql();
        //    member.Connect();

        //    string insert = "START TRANSACTION; " +
        //        "WITH id AS (" +
        //        "INSERT INTO person (securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
        //        "VALUES ('" + SecurityNr + "', '" + Firstname + "', '" + LastName + "', '" + Gender + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "') RETURNING personid)," 
        //        + " mpid AS (INSERT INTO phone(personid, areacode, phone) SELECT id.personid, '" + Mobilecode + "', '" + Mobilephone + "' " +
        //        "FROM id RETURNING personid),"
        //        + " pid AS (INSERT INTO phone (personid, areacode, phone) SELECT mpid.personid, '" + Homeareacode + "', '" + Homephone + "' " +
        //        "FROM mpid RETURNING personid) INSERT INTO member (memberid, responsibility, membership, pictureallowed, isleader, price, ispayed) " +
        //        "SELECT pid.personid, '" + Responsibility + "', '" + Membership + "', " + Picture + ", " + Leader + ", " + Price + ", " + payed + " FROM pid; " +
        //        "COMMIT;";


        //    member.Insert(insert);
        //    member.Close();
        //}
    }
}
