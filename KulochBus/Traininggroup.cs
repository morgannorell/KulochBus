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
        public int GroupId { get; set; }
        bool Leader { get; set; }
        public string Notes { get; set; }

        public Traininggroup()
        {
        }

        public void CreateTG()
        {
            Sql TG = new Sql();

            string sql = "INSERT INTO traininggroup (description, name, notes, levelid, diciplinid) VALUES ('" + Description + "', '" + Name + "', '" + Notes + "', " + LevelId + ", " + DiciplinId + ")";

            TG.Insert(sql);
        }

        // Methods
        public DataTable GetTGLevelList()
        {
            Sql query = new Sql();

            string sql = "SELECT name, levelid FROM level";

            DataTable dt = new DataTable();
            dt = query.Select(sql);

            return dt;
        }

        public DataTable GetTGDiciplinList()
        {
            Sql query = new Sql();

            string sql = "SELECT name FROM diciplin";

            DataTable dt = new DataTable();
            dt = query.Select(sql);

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

            string sql = "SELECT groupid AS \"GruppID\", notes AS \"Noteringar\", t.name AS \"Gruppnamn\", l.name AS \"Nivå\", d.name AS \"Disciplin\", description AS \"Beskrivning\" FROM traininggroup AS t" +
            " JOIN level AS l ON t.levelid = l.levelid" +
            " JOIN diciplin AS d ON t.diciplinid = d.diciplinid WHERE groupid = " + traininggroup;

            DataTable dt = new DataTable();

            dt = querry.Select(sql);
            return dt;
        }

        public void UpdateTG()
        {
            Sql tg = new Sql();

            string update = "UPDATE traininggroup SET description = '" + Description + "', name = '" + Name + "', notes = '" + Notes + "', levelid = " + LevelId + ", diciplinid = " + DiciplinId + " WHERE groupid = " + GroupId + ";";

            tg.Insert(update);
        }
        public void AddTGMember(int memberid, int groupid, bool leader)
        {
            Sql TG = new Sql();

            string sql = "INSERT INTO membergroup (memberid, groupid, isleader) VALUES (" + memberid + ", " + groupid + ", '" + leader + "')";

            TG.Insert(sql);
        }

        public DataTable GetTGMemberList(int groupid)
        {
            Sql querry = new Sql();

            string sql = "SELECT memberid AS \"Medlemsnr\", firstname AS \"Förnamn\", lastname AS \"Efternamn\" FROM membergroup JOIN person ON personid = memberid AND groupid = " + groupid + ";";

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }

        public DataTable GetTGLeaderList(int groupid)
        {
            Sql querry = new Sql();

            string sql = "SELECT memberid AS \"Medlemsnr\", firstname AS \"Förnamn\", lastname AS \"Efternamn\" FROM membergroup JOIN person ON personid = memberid AND groupid = " + groupid + " WHERE isleader = true;";

            DataTable dt = new DataTable();
            dt = querry.Select(sql);

            return dt;
        }

        public void deleteTGMember (string delete)
        {
            Sql tg = new Sql();

            string sql = "DELETE FROM membergroup WHERE memberid = " + delete + "";

            tg.Insert(sql);
        }

        public void deleteTGLeader(string delete)
        {
            Sql tg = new Sql();

            string sql = "DELETE FROM membergroup WHERE memberid = " + delete + " AND isleader = true";

            tg.Insert(sql);
        }

        public void deleteTG(int delete)
        {
            Sql tg = new Sql();

            string sql = "START TRANSACTION; DELETE FROM membergroup WHERE groupid = " + delete + "; DELETE FROM traininggroup WHERE groupid = " + delete + "; COMMIT;";

            tg.Insert(sql);
        }

        //public string GetTGnameid(string selectedAttendance)
        //{
        //    Sql querry = new Sql();

        //    string sql = "SELECT groupid FROM attendance WHERE date = '" + selectedAttendance + "'";

        //    querry.SelectedGID(sql);

        //    return id;
        //}

    }
}
