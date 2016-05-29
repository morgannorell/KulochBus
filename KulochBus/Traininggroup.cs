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


    }
}
