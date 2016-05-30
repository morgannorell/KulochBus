using System;
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

            string sql = "SELECT securitynr, firstname, lastname " +
                "from member_base join membergroup on member_base.memberid = membergroup.memberid " +
                "join traininggroup on membergroup.groupid = traininggroup.groupid " +
                "WHERE name = '" + group + "'";

            dt = querry.Select(sql);

            dt.Columns.Add(new DataColumn("Närvaro", typeof(bool)));

            return dt;
        }

        public void CreateMemberlist()
        {
            Sql newList = new Sql();
            DataTable dt = new DataTable();

            string sql = "INSERT INTO attendance (groupid, description, place) VALUES ()";
        }
    }
}
