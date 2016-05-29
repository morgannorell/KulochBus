using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Threading;
using System.Configuration;

namespace KulochBus
{
    public class Sql
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader _dr;
        private DataTable _table;


        public Sql()
        {
            conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString);
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
                    Thread.Yield();
                }

                if (timeOut)
                {
                    // if sql connection times out
                    System.Windows.Forms.MessageBox.Show("Connection Timeout");
                }
            }
            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public void Connect()
        {
            ////try
            ////{
            ////    //conn.Open();

            ////    var startTime = DateTime.Now;
            ////    var endTime = DateTime.Now.AddSeconds(5);
            ////    var timeOut = false;

            ////    while (conn.State != ConnectionState.Open)
            ////    {
            ////        if (DateTime.Now.CompareTo(endTime) >= 0)
            ////        {
            ////            timeOut = true;
            ////            break;
            ////        }
            ////        Thread.Yield();
            ////    }

            ////    if (timeOut)
            ////    {
            ////        // if sql connection times out
            ////        System.Windows.Forms.MessageBox.Show("Connection Timeout");
            ////    }

            //}

            //catch (NpgsqlException ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
        }

        public void Insert(string sql)
        {
            try
            {
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            conn.Close();
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
            conn.Close();
        }

        public int SelectDiciplin(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        int id = Convert.ToInt32(da["diciplinid"]);
                        return id;
                    }
                }
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public int SelectLevel(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        int id = Convert.ToInt32(da["levelid"]);
                        return id;
                    }
                }
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }
    }
}
