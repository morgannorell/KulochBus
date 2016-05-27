using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KulochBus
{
    class Member:Person
    {
        public string MemberId { get; set; }
        public string Responsibility { get; set; }
        public string Membership { get; set; }
        public int Price { get; set; }
        public bool Picture { get; set; }
        public bool Leader { get; set; }
        public bool Payed { get; set; }

        //ärver från person och skapar ny medlem (persontabell, medlemstabell och telefontabell)
        public void CreateMember()
        {
            Sql member = new Sql();

            string sql = 
                "START TRANSACTION; " +
                "WITH id AS (" +
                "INSERT INTO person " +
                "(securitynr, firstname, lastname, gender, address, zipcode, city, email) " +
                "VALUES ('" + 
                SecurityNr + "', '" + 
                Firstname + "', '" + 
                LastName + "', '" + 
                Gender + "', '" + 
                Address + "', '" + 
                Zipcode + "', '" + 
                City + "', '" + 
                Email + "') RETURNING personid)," + 
                " mpid AS " +
                "(INSERT INTO phone(personid, areacode, phone) " +
                "SELECT id.personid, '" + 
                Mobilecode + "', '" + 
                Mobilephone + "' " +
                "FROM id RETURNING personid)," + 
                " pid AS " +
                "(INSERT INTO phone (personid, areacode, phone) " +
                "SELECT mpid.personid, '" + 
                Homeareacode + "', '" + 
                Homephone + "' " +
                "FROM mpid RETURNING personid) " +
                "INSERT INTO member " +
                "(memberid, responsibility, membership, pictureallowed, isleader, price, ispayed) " +
                "SELECT pid.personid, '" + 
                Responsibility + "', '" + 
                Membership + "', " + 
                Picture + ", " + 
                Leader + ", " + 
                Price + ", " + 
                Payed + 
                " FROM pid; " +
                "COMMIT;";

            member.Insert(sql);
        }

        public void UpdateMember()
        {
            Sql member = new Sql();
            //member.Connect();

            string update = "START TRANSACTION; " +
                " UPDATE member SET responsibility = '" + Responsibility + "', membership = '" + Membership + "', pictureallowed = '" + Picture + "', isleader = '" + Leader + "', price = '" + Price + "', ispayed = '" + Payed + "' WHERE memberid = " + PersonId + ";" +
                " UPDATE person SET securitynr = '" + SecurityNr + "', firstname = '" + Firstname + "', lastname = '" + LastName + "', gender = '" + Gender + "', Address = '" + Address + "', zipcode = '" + Zipcode + "', city = '" + City + "', email = '" + Email + "' WHERE personid = " + PersonId + ";" +
                " UPDATE phone SET areacode = '" + Homeareacode + "', phone = '" + Homephone + "' WHERE phone = '" + Homephone + " AND areacode = '" + Homeareacode + "' AND personid = " + PersonId + ";" +
                " UPDATE phone SET areacode = '" + Mobilecode + "', phone = '" + Mobilephone + "' WHERE phone = '" + Mobilephone + " AND areacode = '" + Mobilecode + "' AND personid = " + PersonId + ";" +
                " COMMIT;";

            member.Insert(update);
        }

        public DataTable GetMemberList(string condition, string search)
        {
            Sql querry = new Sql();
          
            string sql =
                "SELECT personid AS \"Medlemsnr\", firstname AS \"Förnamn\", " +
                "lastname AS \"Efternamn\", securitynr AS \"Personnr\", " +
                "gender AS \"Kön\", membership AS \"Medlemstyp\", " +
                "ispayed AS \"Betalt\", isleader AS \"Ledare\" " +
                "FROM person " +
                "Join member ON personid = memberid";

            if (((condition == "") || (condition == "Inget filter")) && (search == ""))
            {
                // Show all
            }
            else
            {
                sql += " WHERE ";

                if (search != "")
                {
                    sql += "(firstname like '%" + search + "%' OR " +
                    "lastname like '%" + search + "%' OR " +
                    "securitynr like '%" + search + "%' OR " +
                    "gender like '%" + search + "%' OR " +
                    "membership like '%" + search + "%')";
                }
                if (search != "" && condition != "")
                {
                    sql += " AND ";
                }
                if (condition == "payed")
                {
                    sql += "ispayed = true";
                }
                else if (condition == "notPayed")
                {
                    sql += "ispayed = false";
                }
                else if (condition == "leader")
                {
                    sql += "isleader = true";
                } 
            }
            
            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }
    }
}
