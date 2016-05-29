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
    public partial class frmDisciplin : Form
    {
        public frmDisciplin()
        {
            InitializeComponent();
            ListDisciplin();
        }

        private DataTable dt;
        private BindingSource bs;


        private void btnDisciplinSave_Click(object sender, EventArgs e)
        {
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
                    Sql disciplin = new Sql();

                    disciplin.Connect();
                    disciplin.Insert(insert);
                }
            }

            else if (rbnDisciplinRemove.Checked)
            {

            }

            else
                MessageBox.Show("Du måste välja att lägga till eller ta bort nivå.");

            ListDisciplin();
        }

        private void ListDisciplin()
        {
            Sql listDisciplin = new Sql();
            //listDisciplin.Connect();

            string querry = "SELECT name FROM diciplin";

            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            dt = listDisciplin.Select(querry);
            bs.DataSource = dt;
            dgrViewDisciplin.DataSource = bs;
        }

        private void dgrViewDisciplin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                txtDisciplin.Text = dgrViewDisciplin.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}
