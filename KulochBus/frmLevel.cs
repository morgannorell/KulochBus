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
    public partial class frmLevel : Form
    {
        public frmLevel()
        {
            InitializeComponent();
            ListLevels();
        }

        private void btnLevelSave_Click(object sender, EventArgs e)
        {
            if (rbnLevelAdd.Checked)
            {
                string newLevel = txtLevel.Text;
                if (String.IsNullOrWhiteSpace(newLevel))
                {
                    MessageBox.Show("Du måste ge din nivå ett namn.");
                }

                else
                {
                    string insert = "Insert into level (name) values ('" + newLevel + "')";
                    Sql level = new Sql();

                    level.Connect();
                    level.Insert(insert);
                    level.Close();
                }
            }

            else if (rbnLevelRemove.Checked)
            {

            }

            else
                MessageBox.Show("Du måste välja att lägga till eller ta bort nivå.");

            ListLevels();
        }

        private void ListLevels()
        {
            Sql listLevels = new Sql();
            listLevels.Connect();

            string querry = "SELECT name FROM level";

            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            dt = listLevels.Select(querry);
            bs.DataSource = dt;
            dgrViewLevels.DataSource = bs;

            listLevels.Close();
        }

        private void btnLevelClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
