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

            //lägger till items i combobox + tilldelar värden
            comboBoxMembership.Items.Add(new Membership("Vanlig medlem", 150));
            comboBoxMembership.Items.Add(new Membership("Prova-på", 50));
            comboBoxMembership.Items.Add(new Membership("Cirkusvän", 0));

            // Döljer alla paneler
            HidePanels();
        }

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

        private void medlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panNewMember.Show();            
            
            //ändrar visibility på buttons osv
            btnCreateNewMember.Visible = true;
            btnContact.Visible = false;
            btnSave.Visible = false;
            txtMemberId.Visible = false;
            lblMemberID.Visible = false;
            lblCreateNewMember.Text = "Skapa ny medlem";

        }

        private void arkivToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            panNewMember.Hide();
        }

        private void btnCreateNewMember_Click(object sender, EventArgs e)
        {
            bool picture = false;
            bool leader = false;
            bool payed = false;

            if (checkBoxPicture.Checked) { picture = true; }
            if (checkBoxLeader.Checked) { leader = true; }
            if (checkPayed.Checked) { payed = true; }
            var membership = (Membership)comboBoxMembership.SelectedItem;
            
            Member ps = new Member()
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
                Homeareacode = txtPhoneAreaCode.Text,
                Homephone = txtPhone.Text,
                Mobilecode = txtCellphoneAreaCode.Text,
                Mobilephone = txtCellphone.Text
            };

            ps.CreateMember();
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

            Sql getMemberList = new Sql();
            getMemberList.Connect();

            string sql = "SELECT personid, firstname, lastname, securitynr, gender, membership, ispayed, isleader " +
                "FROM person " +
                "Join member ON personid = memberid";

            DataTable tb = new DataTable();
            BindingSource bs = new BindingSource();

            tb = getMemberList.Select(sql);
            bs.DataSource = tb;
            dgrViewMember.DataSource = bs;

            getMemberList.Close();            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panNewTraininggroup_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnMemberSearch_Click(object sender, EventArgs e)
        {
            string memberSearch = txtMemberSearch.Text;

            Sql getMemberList = new Sql();
            getMemberList.Connect();

            string sql =
                "SELECT personid, firstname, lastname, securitynr, gender, membership, ispayed " +
                "FROM person " +
                "JOIN member ON personid = memberid " +
                "WHERE firstname like '%" + memberSearch + "%' OR " +
                "lastname like '%" + memberSearch + "%' OR " +
                "securitynr like '%" + memberSearch + "%' OR " +
                "gender like '%" + memberSearch + "%' OR " +
                "membership like '%" + memberSearch + "%'";

            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();
            
            dt = getMemberList.Select(sql);
            bs.DataSource = dt;
            dgrViewMember.DataSource = bs;

            getMemberList.Close();
        }

        private void dgrViewMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //visibility på members
            HidePanels();
            panNewMember.Show();
            btnContact.Visible = true;
            btnSave.Visible = true;
            lblCreateNewMember.Text = "Medlem";
            lblMemberID.Visible = true;
            txtMemberId.Visible = true;

            // Get memberid
            string selectedMember;
            DataGridViewRow selectedRow = dgrViewMember.Rows[e.RowIndex];
            selectedMember = selectedRow.Cells[0].Value.ToString();

            Sql getMemberDetails = new Sql();
            getMemberDetails.Connect();

            //la till personid så det gick att hämta ut i en textbox
            string querry =
                "SELECT personid, firstname, lastname, securitynr, address, " +
                "zipcode, city, email, gender " +
                "FROM person " +
                "WHERE personid = " + selectedMember;

            DataTable dt = new DataTable();
            dt = getMemberDetails.Select(querry);

            Phone ph = new Phone()
            {
                Areacode = "0650",
                Phonenumber = "111 22"
            };

            foreach (DataRow row in dt.Rows)
            {
                txtMemberId.Text = row["personid"].ToString();
                txtFirstName.Text = row["firstname"].ToString();
                txtLastName.Text = row["lastname"].ToString();
                txtSecurityNr.Text = row["securitynr"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtCity.Text = row["city"].ToString();
                txtZipcode.Text = row["zipcode"].ToString();
                txtEmail.Text = row["email"].ToString();
                comboBoxGender.Text = row["gender"].ToString();              
            }
            btnCreateNewMember.Visible = false;
        }

        private void träningsgrupperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panTGGroupList.Show();

            Traininggroup tg = new Traininggroup();
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

        private void btnContact_Click(object sender, EventArgs e)
        {
          HidePanels();
          panNewContact.Show();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
  
            Contact ct = new Contact()
            {
                MemberId = txtMemberIdContact.Text,
                Firstname = txtContactFn.Text,
                LastName = txtContactLn.Text,
                SecurityNr = txtContactSc.Text,
                Address = txtContactAddress.Text,
                Zipcode = txtContactZipcode.Text,
                City = txtContactCity.Text,
                Email = txtContactEmail.Text,
                Gender = comboBoxContactGender.SelectedItem.ToString(),
                Homeareacode = txtContactPAC.Text,
                Homephone = txtContactPhone.Text,
                Mobilecode = txtContactMPAC.Text,
                Mobilephone = txtContactMobilephone.Text
            };

            ct.CreateContact();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool picture = false;
            bool leader = false;
            bool payed = false;

            if (checkBoxPicture.Checked) { picture = true; }
            if (checkBoxLeader.Checked) { leader = true; }
            if (checkPayed.Checked) { payed = true; }
            var membership = (Membership)comboBoxMembership.SelectedItem;

            Phone ph = new Phone();

            ph.Phonenumber = txtPhone.Text;

            //Member updateMember = new Member()
            //{
            //    PersonId = txtMemberId.Text,
            //    Firstname = txtFirstName.Text,
            //    LastName = txtLastName.Text,
            //    SecurityNr = txtSecurityNr.Text,
            //    Address = txtAddress.Text,
            //    Zipcode = txtZipcode.Text,
            //    City = txtCity.Text,
            //    Email = txtEmail.Text,
            //    Gender = comboBoxGender.SelectedItem.ToString(),
            //    Responsibility = txtResponsibility.Text,
            //    Membership = membership.Name,
            //    Price = membership.Price,
            //    Picture = picture,
            //    Leader = leader,
            //    Payed = payed,
            //    Homeareacode = txtPhoneAreaCode.Text,
            //    Homephone = txtPhone.Text,
            //    Mobilecode = txtCellphoneAreaCode.Text,
            //    Mobilephone = txtCellphone.Text
            //};

            

            //updateMember.UpdateMember();

        }

    }
}
