using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KulochBus
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Döljer alla paneler
            HidePanels();
        }

        private void HidePanels()
        {
            foreach (Control c in Controls)
            {
                if (c is Panel) c.Hide();
            }
        }

        private void medlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
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
            string strFirstName, strLastName;
            strFirstName = txtFirstName.Text;
            strLastName = txtLastName.Text;

            string sql = "INSERT INTO person (firstname, lastname) values ('" + strFirstName + "', '" + strLastName + "')";

            Sql conn = new Sql();
            conn.Connect();
            conn.Insert(sql);
            conn.Close();
        }

        private void träningsgruppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panNewTraininggroup.Show();
        }

        private void kontaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panNewContact.Show();
        }

        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void medlemmarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panViewMember.Show();

            Sql select = new Sql();

            select.Connect();

            string sql = "SELECT * FROM person";

            

            List<string> test = new List<string>();

            test = select.Select(sql);
        }
    }
}
