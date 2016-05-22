using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Threading;

namespace KulochBus
{
    public class Sql
    {
        static private string connectionString = "Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus; Pooling=false";
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);

        public void Connect()
        {
            try
            {
                conn.Open();

                var startTime = DateTime.Now;
                var endTime = DateTime.Now.AddSeconds(5);
                var timeOut = false;

                while (conn.State != ConnectionState.Open)
                {
                    if (DateTime.Now.CompareTo(endTime) >= 0)
                    {
                        timeOut = true;
                        break;
                    }
                    Thread.Yield(); //tells the kernel to give other threads some time
                }

                if (timeOut)
                {
                    System.Windows.Forms.MessageBox.Show("Connection Timeout");
                    // TODO: Handle your time out here.
                }

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

        public DataTable Select(string sql)
        {     
            DataTable myTable = new DataTable();

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();

                da.SelectCommand = cmd; 
                da.Fill(myTable);

                return myTable;                
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return myTable;    
            }

        }
    }
}
