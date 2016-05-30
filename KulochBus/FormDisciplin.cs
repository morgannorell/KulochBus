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
    public partial class FormDisciplin : Form
    {
        public FormDisciplin()
        {
            InitializeComponent();
            ListDiciplin();
        }

        private void ListDiciplin()
        {
            Sql listDisciplin = new Sql();

            string querry = "SELECT name FROM diciplin";

            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            dt = listDisciplin.Select(querry);
            bs.DataSource = dt;
            dgrViewDisciplin.DataSource = bs;
        }

        private void btnDisciplinSave_Click_1(object sender, EventArgs e)
        {
            Sql disciplin = new Sql();

            if (rbnDisciplinAdd.Checked)
            {
                string newDisciplin = txtDisciplin.Text;
                if (String.IsNullOrWhiteSpace(newDisciplin))
                {
                    MessageBox.Show("Du måste ge din disciplin ett namn.");
                }

                else
                {
                    string insert = "INSERT INTO diciplin (name) VALUES ('" + newDisciplin + "')";
                    

                    disciplin.Insert(insert);
                }
            }

            else if (rbnDisciplinRemove.Checked)
            {
                string a = dgrViewDisciplin.CurrentCell.FormattedValue.ToString();
                string delete = "DELETE FROM diciplin WHERE name='" + a + "'";
                disciplin.Insert(delete);
            }

            else
                MessageBox.Show("Du måste välja att lägga till eller ta bort en disciplin.");

            ListDiciplin();
        }

        private void btnLDisciplinClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
