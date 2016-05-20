using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    class Phone
    {
        public int PersonId;
        public string StrPhoneAreaCode;
        public string StrPhone;
        public string StrCellphoneAreaCode;
        public string StrCellphone;

        
        public Phone(int newPersonId, string strPhoneAreaCode, string strPhone, string strCellphoneAreaCode, string strCellphone)
        {
            StrPhoneAreaCode = strPhoneAreaCode;
            StrPhone = strPhone;
            StrCellphoneAreaCode = strCellphoneAreaCode;
            StrCellphone = strCellphone;
            PersonId = newPersonId;
        }

        public void createPhone()
        {
            NpgsqlConnection conn = new NpgsqlConnection
                ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");
            try
            {
                conn.Open();

                string sqlPhone = "INSERT INTO phone (personid, areacode, phone) values (" + PersonId + ",'" + StrPhoneAreaCode + "', '" + StrPhone + "')";

                NpgsqlCommand cmd = new NpgsqlCommand(sqlPhone, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void createCellphone()
        {
            NpgsqlConnection conn = new NpgsqlConnection
                ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");
            try
            {
                conn.Open();

                string sqlCellphone = "INSERT INTO phone (personid, areacode, phone) values (" + PersonId + ",'" + StrCellphoneAreaCode + "', '" + StrCellphone + "')";

                NpgsqlCommand cmd1 = new NpgsqlCommand(sqlCellphone, conn);
                cmd1.ExecuteNonQuery();

                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
