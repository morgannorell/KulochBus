using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KulochBus
{
    class Traininggroup
    {
        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string LevelName { get; set; }
        public string DiciplinName { get; set; }
        public int LevelId { get; set; }
        public int DiciplinId { get; set; }

        public Traininggroup()
        {
        }

        public void CreateTG()
        {
            Sql TG = new Sql();

            string sql = "INSERT INTO traininggroup (description, name, levelid, diciplinid) VALUES ('" + Description + "', '" + Name + "', " + LevelId + ", " + DiciplinId + ")";

            TG.Insert(sql);
        }

        // Methods
        public DataTable GetTGLevelList()
        {
            Sql querry = new Sql();

            string sql = "SELECT name, levelid FROM level";

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }

        public DataTable GetTGDiciplinList()
        {
            Sql querry = new Sql();

            string sql = "SELECT name FROM diciplin";

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }

        public int GetTGDiciplin()
        {
            Sql querry = new Sql();

            string sql = "SELECT diciplinid FROM diciplin WHERE name = '" + DiciplinName +"'";

            int dt;

            dt = querry.SelectDiciplin(sql);

            return dt;
        }

        public int GetTGLevel()
        {
            Sql querry = new Sql();

            string sql = "SELECT levelid FROM level WHERE name = '" + LevelName + "'";

            int dt;

            dt = querry.SelectLevel(sql);

            return dt;
        }

        public DataTable GetTGList(string search)
        {
            Sql querry = new Sql();

            string sql = "SELECT groupid AS \"GruppID\", t.name AS \"Gruppnamn\", l.name AS \"Nivå\", d.name AS \"Disciplin\" FROM traininggroup AS t" +
                        " JOIN level AS l ON t.levelid = l.levelid" +
                        " JOIN diciplin AS d ON t.diciplinid = d.diciplinid";


                if (search != "")
                {
                    int result;
                    sql += " WHERE ";
                    if(int.TryParse(search, out result))
                    {
                        sql += "groupid = " + result + " OR ";
                    }
                    sql += 
                    "t.name like '%" + search + "%' OR " +
                    "l.name like '%" + search + "%' OR " +
                    "d.name like '%" + search + "%'";
                }
            

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }

        public DataTable GetTGDetail(string traininggroup)
        {
            Sql querry = new Sql();

            string sql = "SELECT groupid AS \"GruppID\", t.name AS \"Gruppnamn\", l.name AS \"Nivå\", d.name AS \"Disciplin\", description AS \"Beskrivning\" FROM traininggroup AS t" +
            " JOIN level AS l ON t.levelid = l.levelid" +
            " JOIN diciplin AS d ON t.diciplinid = d.diciplinid WHERE groupid = " + traininggroup;

            //string sql =
            //    "SELECT personid, firstname, lastname, securitynr, gender, address, zipcode, city, email, " +
            //    "memberid, responsibility, membership, isleader, pictureallowed, ispayed " +
            //    "FROM person JOIN member ON personid = memberid " +
            //    "WHERE personid = " + member;

            DataTable dt = new DataTable();

            dt = querry.Select(sql);
            return dt;
        }
    }
}
