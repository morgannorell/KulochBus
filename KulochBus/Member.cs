using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    class Member:Person
    {
        //ärver från person och skapar ny medlem (persontabell, medlemstabell och telefontabell)
        public void CreateMember()
        {
            Sql member = new Sql();
            member.Connect();

            string insert = "START TRANSACTION; " +
                "WITH id AS (" +
                "INSERT INTO person (securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
                "VALUES ('" + SecurityNr + "', '" + Firstname + "', '" + LastName + "', '" + Gender + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "') RETURNING personid),"
                + " mpid AS (INSERT INTO phone(personid, areacode, phone) SELECT id.personid, '" + Mobilecode + "', '" + Mobilephone + "' " +
                "FROM id RETURNING personid),"
                + " pid AS (INSERT INTO phone (personid, areacode, phone) SELECT mpid.personid, '" + Homeareacode + "', '" + Homephone + "' " +
                "FROM mpid RETURNING personid) INSERT INTO member (memberid, responsibility, membership, pictureallowed, isleader, price, ispayed) " +
                "SELECT pid.personid, '" + Responsibility + "', '" + Membership + "', " + Picture + ", " + Leader + ", " + Price + ", " + payed + " FROM pid; " +
                "COMMIT;";

            member.Insert(insert);
            member.Close();
        }
    }
}
