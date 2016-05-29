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

        // Methods

        public DataTable GetTGLevelList()
        {
            Sql querry = new Sql();

            string sql = "SELECT name FROM level";

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

    }
}
