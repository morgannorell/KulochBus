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
            // Döljer alla paneler
            HidePanels();
            // och visa startpanelen
            panStart.Show();
        }

        private DataTable dt;
        private BindingSource bs;

        // Metod för att dölja alla paneler
        private void HidePanels()
        {
            foreach (Control c in Controls)
            {
                if (c is Panel)
                {
                    c.Hide();
                    continue;
                }
            }           
        }

        // Tömmer alla textboxar
        private void EmptyTxtBoxes(Panel name)
        {
            foreach (Control c in name.Controls)
            {
                if (c is TextBox)              
                    (c as TextBox).Clear();
                if (c is ComboBox)
                    (c as ComboBox).ResetText();
                if (c is CheckBox)
                    (c as CheckBox).Checked = false;
            }
        }

        //
        //Medlemmar
        //
        private void medlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Visa panel för medlem
            HidePanels();
            panMember.Show();
            EmptyTxtBoxes(panMember);

            // Ändrar visibility på buttons osv
            btnCreateNewMember.Show();
            btnContact.Hide();
            btnMemberSave.Hide();
            txtMemberId.Hide();
            lblMemberID.Hide();
            btnViewList.Hide();
            lblCreateNewMember.Text = "Skapa ny medlem";
            
            //lägger till items i combobox + tilldelar värden
            cmbMembership.Items.Add(new Membership("Medlem", 150));
            cmbMembership.Items.Add(new Membership("Prova-på", 50));
            cmbMembership.Items.Add(new Membership("Cirkusvän", 0));
        }
        
        private void btnCreateNewMember_Click(object sender, EventArgs e)
        {
            bool picture = false;
            bool leader = false;
            bool payed = false;

            if (checkBoxPicture.Checked) { picture = true; }
            if (checkBoxLeader.Checked) { leader = true; }
            if (checkPayed.Checked) { payed = true; }
            string felmeddelande = string.Empty;


            foreach (Control control in panMember.Controls)
            {
                string controlType = control.GetType().ToString();
                if (controlType == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;
                    if (string.IsNullOrEmpty(txtBox.Text))
                    {
                        if (txtBox.Tag.ToString() == "Medlemsnummer")
                        {
                            continue;
                        }
                        felmeddelande += txtBox.Tag.ToString() + " ";
 
                    }
                }
            }

            if (comboBoxGender.SelectedItem == null)
            {
                MessageBox.Show("Du måste ange om det är en man eller kvinna.");
                return;
            }

            else if (cmbMembership.SelectedItem == null)
            {
                MessageBox.Show("Du måste tala om vilken typ av medlem det är.");
                return;
            }

            if (!string.IsNullOrEmpty(felmeddelande))
            {
                MessageBox.Show(felmeddelande + "måste fyllas i.");
                return;
            }

            Membership membership = (Membership)cmbMembership.SelectedItem;  
            Member mb = new Member()
            {
                Firstname = txtFirstName.Text,
                LastName = txtLastName.Text,
                SecurityNr = txtSecurityNr.Text,
                Address = txtAddress.Text,
                Zipcode = txtZipcode.Text,
                City = txtCity.Text,
                Email = txtEmail.Text,
                Gender = comboBoxGender.SelectedItem.ToString(),
                Responsibility = txtResponsibility.Text,
                Membership = membership.Name,
                Price = membership.Price,
                Picture = picture,
                Leader = leader,
                Payed = payed,
                Phone = txtPhone.Text,
                Cellphone = txtCellphone.Text
            };

            mb.CreateMember();
            EmptyTxtBoxes(panMember);
            MessageBox.Show("Medlem tillagd");
        }

        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            bool picture = false;
            bool leader = false;
            bool payed = false;
            //var membership = (Membership)cmbMembership.SelectedItem;    
            Membership membership = new Membership();

            if (checkBoxPicture.Checked) { picture = true; }
            if (checkBoxLeader.Checked) { leader = true; }
            if (checkPayed.Checked) { payed = true; }
            if (cmbMembership.Text == "Medlem") { membership.Name = "Medlem"; membership.Price = 150; }
            if (cmbMembership.Text == "Prova-på") { membership.Name = "Prova-på"; membership.Price = 50; }
            if (cmbMembership.Text == "Cirkusvän") { membership.Name = "Cirkusvän"; membership.Price = 0; }

            Member updateMember = new Member()
            {
                PersonId = txtMemberId.Text,
                Firstname = txtFirstName.Text,
                LastName = txtLastName.Text,
                SecurityNr = txtSecurityNr.Text,
                Address = txtAddress.Text,
                Zipcode = txtZipcode.Text,
                City = txtCity.Text,
                Email = txtEmail.Text,
                Gender = comboBoxGender.SelectedItem.ToString(),
                Responsibility = txtResponsibility.Text,
                Membership = membership.Name,
                Price = membership.Price,
                Picture = picture,
                Leader = leader,
                Payed = payed,
                Phone = txtPhone.Text,
                Cellphone = txtCellphone.Text
            };

            updateMember.UpdateMember();
            MessageBox.Show("Medlem " + txtMemberId.Text + " är nu uppdaterad");
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            HidePanels();
            panContact.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HidePanels();
            panStart.Show();
        }        
        //
        // Medlemslista
        //
        private void ShowMemberlist(string condition, string search)
        {
            HidePanels();
            panViewMember.Show();

            Member mb = new Member();

            dt = new DataTable();
            bs = new BindingSource();

            dt = mb.GetMemberList(condition, search);
            bs.DataSource = dt;
            dgrViewMember.DataSource = bs;
        }
        private void medlemmarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string condition = "";
            string search = "";
            ShowMemberlist(condition, search);
        }

        private void btnMemberSearch_Click(object sender, EventArgs e)
        {
            string search = txtMemberSearch.Text;
            string condition = "";

            if (cmbFilter.SelectedItem == null)
                condition = "";
            else if (cmbFilter.SelectedItem.ToString() == "Ledare")
                condition = "leader";
            else if (cmbFilter.SelectedItem.ToString() == "Betalt")
                condition = "payed";
            else if (cmbFilter.SelectedItem.ToString() == "Ej betalt")
                condition = "notPayed";

            ShowMemberlist(condition, search);
        }
        private void dgrViewMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //visibility på members
            HidePanels();
            btnCreateNewMember.Hide();
            panMember.Show();
            btnContact.Show();
            btnMemberSave.Show();
            lblCreateNewMember.Text = "Redigera medlem";
            lblMemberID.Show();
            txtMemberId.Show();
            btnViewList.Show();

            //lägger till items i combobox + tilldelar värden
            cmbMembership.Items.Add(new Membership("Medlem", 150));
            cmbMembership.Items.Add(new Membership("Prova-på", 50));
            cmbMembership.Items.Add(new Membership("Cirkusvän", 0));

            // Get memberid
            string selectedMember;
            DataGridViewRow selectedRow = dgrViewMember.Rows[e.RowIndex];
            selectedMember = selectedRow.Cells[0].Value.ToString();

            Member mb = new Member();

            dt = new DataTable();
            dt = mb.GetMemberDetail(selectedMember);
 
            foreach (DataRow row in dt.Rows)
            {
                txtMemberId.Text = row["personid"].ToString();
                txtFirstName.Text = row["firstname"].ToString();
                txtLastName.Text = row["lastname"].ToString();
                txtSecurityNr.Text = row["securitynr"].ToString();
                comboBoxGender.Text = row["gender"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtCity.Text = row["city"].ToString();
                txtZipcode.Text = row["zipcode"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtResponsibility.Text = row["responsibility"].ToString();
                cmbMembership.Text = row["membership"].ToString();
                txtMemberId.Text = row["memberid"].ToString();
                if ((bool)row["isleader"] == true) { checkBoxLeader.Checked = true; }
                if ((bool)row["pictureallowed"] == true) { checkBoxPicture.Checked = true; }
                if ((bool)row["ispayed"] == true) { checkPayed.Checked = true; }
            }

            dt = new DataTable();
            dt = mb.GetPhone(selectedMember);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["type"] == "phone") { txtPhone.Text = row["phone"].ToString(); }
                if ((string)row["type"] == "cell") { txtCellphone.Text = row["phone"].ToString(); }
            }            
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            string condition = "";
            string search = "";
            ShowMemberlist(condition, search);
        }

        //
        // Kontakt
        //
        private void kontaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panContact.Show();
        }

        private void btnCTsearch_Click(object sender, EventArgs e)
        {
            string search = txtCTsearch.Text;

            Contact ct = new Contact();
            dt = new DataTable();
            bs = new BindingSource();

            dt = ct.GetMemberContact(search);
            bs.DataSource = dt;

            dt.Columns.Add(new DataColumn("Selected", typeof(bool)));

            //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            //checkColumn.Name = "addCheck";
            //checkColumn.HeaderText = "Lägg till";
            //checkColumn.Width = 50;
            //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
            //dgrCTsearchmedlem.Columns.Add(checkColumn);

            dgrCTsearchmedlem.DataSource = bs;
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {

            Contact ct = new Contact()
            {
                Firstname = txtCTfirstname.Text,
                LastName = txtCTlastname.Text,                
                SecurityNr = txtCTSecuritynr.Text,
                Gender = cmbCTgender.SelectedItem.ToString(),
                Address = txtCTaddress.Text,
                Zipcode = txtCTzipcode.Text,
                City = txtCTcity.Text,
                Email = txtCTemail.Text,                
                Phone = txtCTphone.Text,
                Cellphone = txtCTcellphone.Text,
            };

            //ct.CreateContact();
        }

        private void btnCTcancel_Click(object sender, EventArgs e)
        {
            HidePanels();
            panStart.Show();
        }
        //
        // Träningsgrupp
        //
        private void träningsgrupperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panTGGroupList.Show();

            Traininggroup tg = new Traininggroup();
        }

        private void träningsgruppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            rbnTGAdd.Hide();
            rbnTGRemove.Hide();
            cmbTGMember.Hide();
            btnTGSave.Hide();
            lblTGMembers.Hide();
            dgrListTGMembers.Hide();

            panTGGroup.Show();
            btnTGCreate.Show();
            btnTGDiciplin.Show();
            btnTGLevel.Show();
        }

        

        private void btnTGCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnTGDiciplin_Click(object sender, EventArgs e)
        {

        }

        private void btnTGLevel_Click(object sender, EventArgs e)
        {
            frmLevel level = new frmLevel();
            level.Show();
        }

        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        
    }
}
