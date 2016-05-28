using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KulochBus
{
    class Contact:Person
    {
        public DataTable GetMemberContact(string search)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT personid, firstname, lastname FROM person " +
                "JOIN member ON personid = memberid WHERE " +
                "firstname like '%" + search + "%' OR " +
                "lastname like '%" + search + "%'";

            dt = querry.Select(sql);

            return dt;
        }

        public DataTable AddContact(List<string> members)
        {
            Sql querry;
            DataTable dt = new DataTable();

            string sql =
                "START TRANSACTION; " +
                "WITH id AS (" +
                "INSERT INTO person " +
                "(firstname, lastname, securitynr, gender, address, zipcode, city, email) " +
                "VALUES ('" + Firstname + "', '" + LastName + "', '" + SecurityNr + "', '" +
                Gender + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" +
                Email + "') RETURNING personid)," +
                " mpid AS " +
                "(INSERT INTO phone (personid, phone, type) " +
                "SELECT id.personid, '" + Cellphone + "', '" + "cell' " +
                "FROM id RETURNING personid)," +
                " pid AS " +
                "(INSERT INTO phone (personid, phone, type) " +
                "SELECT mpid.personid, '" + Phone + "', '" + "phone' " +
                "FROM mpid RETURNING personid) " +
                "INSERT INTO contact " +
                "(contactid) " + "SELECT pid.personid " + " FROM pid; " +
                "COMMIT;";

            querry = new Sql();
            querry.Insert(sql);

            querry = new Sql();
            string getContactID = "select max(personid) from person";
            dt = querry.Select(getContactID);

            string contactid = "";

            foreach (DataRow row in dt.Rows)
            {
                contactid = row["max"].ToString();
            }

            foreach (string id in members)
            {
                string add = "INSERT INTO membercontact (memberid, contactid) " +
                    "VALUES (" + id + ", " + contactid + ")";
                querry = new Sql();
                querry.Insert(add);
            }

            return dt;
        }

        //ärver från person och skapar kontakt (persontabell och telefontabell)
        //public void CreateContact()
        //{
        //    Sql contact = new Sql();
        //    contact.Connect();

        //    string insert = "START TRANSACTION; " +
        //    "WITH id AS (" +
        //    "INSERT INTO person (securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
        //    "VALUES ('" + SecurityNr + "', '" + Firstname + "', '" + LastName + "', '" + Gender + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "') RETURNING personid),"
        //    + " mpid AS (INSERT INTO phone (personid, areacode, phone) SELECT id.personid, '" + Mobilecode + "', '" + Mobilephone + "' " +
        //    "FROM id RETURNING personid),"
        //    + " pid AS (INSERT INTO phone (personid, areacode, phone) SELECT mpid.personid, '" + Homeareacode + "', '" + Homephone + "' " +
        //    "FROM mpid RETURNING personid) INSERT INTO contact (contactid) " +
        //    "SELECT pid.personid FROM pid; COMMIT;";

        //    contact.Insert(insert);
        //    contact.Close();
        //}
        //public void CreateContact()
        //{
        //    Sql contact = new Sql();
        //    contact.Connect();

        //    string insert = "START TRANSACTION; " +
        //    "WITH id AS (" +
        //    "INSERT INTO person (securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
        //    "VALUES ('" + SecurityNr + "', '" + Firstname + "', '" + LastName + "', '" + Gender + "', '" + Address + "', '" + Zipcode + "', '" + City + "', '" + Email + "') RETURNING personid),"
        //    + " mpid AS (INSERT INTO phone (personid, areacode, phone) SELECT id.personid, '" + Mobilecode + "', '" + Mobilephone + "' " +
        //    "FROM id RETURNING personid),"
        //    + " pid AS (INSERT INTO phone (personid, areacode, phone) SELECT mpid.personid, '" + Homeareacode + "', '" + Homephone + "' " +
        //    "FROM mpid RETURNING personid),"
        //    + " cid AS (INSERT INTO contact (contactid) SELECT pid.personid FROM pid RETURNING contactid),"
        //    + " mcid AS (INSERT INTO membercontact (contactid, memberid) SELECT cid.contactid, " + MemberId + " FROM cid;";

        //    contact.Insert(insert);
        //}

    }
}
