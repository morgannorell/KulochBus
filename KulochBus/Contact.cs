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

            dt.Columns.Add(new DataColumn("Selected", typeof(bool)));

            return dt;
        }

        public DataTable HaveContact(string member)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string hasMember =
                "SELECT memberid, firstname, lastname " +
                "FROM person JOIN membercontact ON personid = memberid " +
                "WHERE contactid = " + member;

            dt = querry.Select(hasMember);

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

        public DataTable GetContactList()
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql =
                "SELECT contactid AS \"Kontaktnr\", firstname AS \"Förnamn\", " +
                "lastname AS \"Efternamn\" " +
                "FROM person " +
                "Join contact ON personid = contactid";

            dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetContactMembers(string contact)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql =
                "SELECT memberid AS \"Medlemsnr\", firstname AS \"Förnamn\", " +
                "lastname AS \"Efternamn\" " +
                "FROM person " +
                "Join membercontact ON personid = memberid " +
                "WHERE contactid = " + contact;

              dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetContactDetail(string member)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql =
                "SELECT personid, firstname, lastname, securitynr, gender, address, zipcode, city, email " +
                "FROM person JOIN contact ON personid = contactid " +
                "WHERE personid = " + member;

            dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetPhone(string member)
        {
            Sql querry = new Sql();

            string sql = "SELECT phone, type FROM phone WHERE personid = " + member;

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }
    }
}
