﻿using System;
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
                "(INSERT INTO phone(personid, phone, type) " +
                "SELECT id.personid, '" +
                Cellphone + "', '" + 
                "cell' " +
                "FROM id RETURNING personid)," + 
                " pid AS " +
                "(INSERT INTO phone (personid, phone, type) " +
                "SELECT mpid.personid, '" +
                Phone + "', '" + 
                "phone' " +
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

            string update = "START TRANSACTION; " +
                " UPDATE member SET responsibility = '" + Responsibility + "', membership = '" + Membership + "', pictureallowed = '" + Picture + "', isleader = '" + Leader + "', price = '" + Price + "', ispayed = '" + Payed + "' WHERE memberid = " + PersonId + ";" +
                " UPDATE person SET securitynr = '" + SecurityNr + "', firstname = '" + Firstname + "', lastname = '" + LastName + "', gender = '" + Gender + "', Address = '" + Address + "', zipcode = '" + Zipcode + "', city = '" + City + "', email = '" + Email + "' WHERE personid = " + PersonId + ";" +
                " UPDATE phone SET phone = '" + Phone + "' WHERE personid = '" + PersonId + "' AND type = 'phone';" +
                " UPDATE phone SET phone = '" + Cellphone + "' WHERE personid = '" + PersonId + "' AND type = 'cell';" +
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
                "Join member ON personid = memberid WHERE isactive = TRUE";

            if (((condition == "") || (condition == "Inget filter")) && (search == ""))
            {
                // Show all
            }
            else
            {
                sql += " AND ";

                if (search != "")
                {
                    sql += "(cast(memberid AS Character(6)) like '%" + search + "%' OR firstname like '%" + search + "%' OR " +
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

        public DataTable GetMemberDetail(string member)
        {
            Sql querry = new Sql();
            
            string sql =
                "SELECT personid, firstname, lastname, securitynr, gender, address, zipcode, city, email, " +
                "memberid, responsibility, membership, isleader, pictureallowed, ispayed " +
                "FROM person JOIN member ON personid = memberid " +
                "WHERE personid = " + member;

            DataTable dt = new DataTable();

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

        public DataTable GetTGMembers()
        {
            Sql querry = new Sql();

            string sql = "SELECT memberid, firstname, lastname, securitynr FROM member JOIN person ON personid = memberid";

            DataTable dt = new DataTable();

            dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetTGLeader()
        {
            Sql querry = new Sql();

            string sql = "SELECT memberid, firstname, lastname, securitynr FROM member JOIN person ON personid = memberid WHERE isleader = true";

            DataTable dt = new DataTable();

            dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetLeaderList()
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql =
                "SELECT memberid AS \"Medlemsnr\", firstname AS \"Förnamn\", lastname AS \"Efternamn\"" +
                " FROM person JOIN member ON personid = memberid WHERE isleader = TRUE";

            dt = querry.Select(sql);
            return dt;
        }

        public DataTable GetGroupLeader(int id)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql =
                "SELECT mg.groupid AS \"GruppID\", t.name AS \"Gruppnamn\", t.levelid AS \"Nivå\", t.diciplinid AS \"Diciplin\" FROM membergroup AS mg JOIN traininggroup AS t ON mg.groupid = t.groupid WHERE mg.memberid = '" + id + "' AND isleader = TRUE";

            dt = querry.Select(sql);
            return dt;
        }

        public void UpdateActivity(bool activity, int id)
        {
            Sql member = new Sql();

            string update = "UPDATE member SET isactive = " + activity +" WHERE memberid = " + id +"";

            member.Insert(update);
        }

    }
}
