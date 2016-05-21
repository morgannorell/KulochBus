using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace KulochBus
{
    public class Sql
    {
        static private string connectionString = "Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus";
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);

        public void Connect()
        {
            try
            {
                conn.Open();
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void Insert(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public List<string> Select(string sql)
        {
            List<string> data = new List<string>();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                
               

                while (dr.Read())
                {
                    data.Add(dr.GetString(0));
                }

                
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return data;
        }
    }
}
