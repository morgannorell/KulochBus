﻿using System;
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
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                myTable.Load(da);

                return myTable;
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return myTable;
            }           
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

        public int SelectID(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        int id = Convert.ToInt32(da["groupid"]);
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

        public int SelectMemberCount(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        int id = Convert.ToInt32(da["membercount"]);
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

        public string SelectedGID(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();


                while (da.Read())
                {
                    string id = da["groupid"].ToString();
                    return id;
                }
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int SelectATSum(string sql)
        {
            try
            {
                int id;
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                id = Convert.ToInt32(cmd.ExecuteScalar());

                return id;
            }

            catch (NpgsqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public int SelectTGSum (string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        int id = Convert.ToInt32(da["memberid"]);
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
