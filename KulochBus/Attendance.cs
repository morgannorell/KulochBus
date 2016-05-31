﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KulochBus
{
    class Attendance
    {
        public DataTable GetTrainingGroups()
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT name FROM traininggroup";
            dt = querry.Select(sql);
            
            return dt;
        }

        public DataTable GetMembers(string group)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT memberid AS \"Medlemsnr\", p.securitynr AS \"Personnr\", p.firstname AS \"Förnamn\", p.lastname AS \"Efternamn\"" +
                " FROM person AS p JOIN membergroup AS m ON m.memberid = p.personid" +
                " JOIN traininggroup AS t on m.groupid = t.groupid WHERE t.name = '" + group + "'";


            dt = querry.Select(sql);

            dt.Columns.Add(new DataColumn("Närvaro", typeof(bool)));

            return dt;
        }

        public DataTable GetLeaders(string group)
        {
            Sql querry = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT securitynr, firstname, lastname " +
                "from member_base join membergroup on member_base.memberid = membergroup.memberid " +
                "join traininggroup on membergroup.groupid = traininggroup.groupid " +
                "WHERE name = '" + group + "' AND isleader = TRUE";

            dt = querry.Select(sql);


            return dt;
        }

        public int findGroupID(string selectedgroup)
        {
            Sql newList = new Sql();

            string sql = "SELECT groupid FROM traininggroup WHERE name = '" + selectedgroup + "'";

            int find = newList.SelectID(sql);

            return find;
        }

        public DataTable CreateMemberlist(List<string> members, string selectedgroup, string description, string place, string date, string start, string end)
        {
            Sql newList = new Sql();
            int sg = findGroupID(selectedgroup);
            DataTable dt = new DataTable();

            string sql = " INSERT INTO attendance (groupid, description, place, date, timestart, timeend) VALUES ('" + sg + "', '" + description + "', '" + place + "', '" + date + "', '" + start + "', '" + end + "')";

            newList.Insert(sql);


            Sql querry = new Sql();

            string getAttendanceID = "select max(attendanceid) from attendance";
            
            dt = querry.Select(getAttendanceID);
            string attendance = "";
            foreach (DataRow row in dt.Rows)
            {
                attendance = row["max"].ToString();
            }

            foreach (string id in members)
            {
                string add = "INSERT INTO memberattendance (memberid, attendanceid) " +
                    "VALUES (" + id + ", " + attendance + ")";
                Sql sql1 = new Sql();
                sql1.Insert(add);
            }

            return dt;
        }

        public DataTable countParticipant()
        {
            Sql newSql = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT a.date AS \"Datum\", tg.name AS \"Gruppnamn\", COUNT(ma.memberid) AS \"Antal närvarande\" FROM memberattendance AS ma JOIN attendance AS a ON ma.attendanceid = a.attendanceid JOIN traininggroup AS tg ON tg.groupid = a.groupid GROUP BY ma.attendanceid, a.date, tg.name";

            dt = newSql.Select(sql);

            return dt;
        }

        public DataTable showAttendance(string attendance)
        {
            Sql newSql = new Sql();
            DataTable dt = new DataTable();

            string sql = "SELECT a.date AS \"Datum\", a.timestart AS \"Starttid\", a.timeend AS \"Sluttid\", a.place AS \"Plats\", a.description AS \"Aktivitet\", COUNT(ma.memberid) AS \"Antal närvarande\" FROM memberattendance AS ma JOIN attendance AS a ON ma.attendanceid = a.attendanceid GROUP BY a.date, a.timestart, a.timeend, a.description, a.place";
               
            dt = newSql.Select(sql);

            return dt;
        }

    }
}
