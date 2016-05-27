using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulochBus
{
    class Contact:Person
    {
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
