using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            panNewMember.Hide();
        }

        private void medlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panNewMember.Show();
        }

        private void arkivToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panNewMember.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection
                ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");
            try
            {
                conn.Open();

                string strFirstName, strLastName;
                strFirstName = txtFirstName.Text;
                strLastName = txtLastName.Text;

                string sql = "INSERT INTO person (firstname, lastname) values ('" + strFirstName + "', '" + strLastName + "')";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
