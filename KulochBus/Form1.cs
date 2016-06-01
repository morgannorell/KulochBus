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
            cmbMembership.Items.Clear();

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
                        if (txtBox.Tag.ToString() == "Medlemsnummer" || txtBox.Tag.ToString() == "Ansvarsområde")
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
            EmptyTxtBoxes(panContact);
            dgrCTsearchmedlem.DataSource = null;
            //bs.Dispose();
            //dgrCTsearchmedlem.Rows.Clear();
            //dgrCTsearchmedlem.Refresh();
            lblCTTitle.Text = "Skapa ny kontakt";
            btnContactList.Hide();
            btnCTsave.Hide();
        }

        private void btnCTsearch_Click(object sender, EventArgs e)
        {
            string search = txtCTsearch.Text;

            Contact ct = new Contact();
            dt = new DataTable();
            bs = new BindingSource();

            dt = ct.GetMemberContact(search);
            bs.DataSource = dt;

            dgrCTsearchmedlem.DataSource = bs;
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {

            if (cmbCTgender.SelectedItem == null)
            {
                MessageBox.Show("Du måste ange om det är en man eller kvinna.");
                return;
            }

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



            List<string> memberids = new List<string>();

            foreach (DataGridViewRow row in dgrCTsearchmedlem.Rows)
            {
                if (row.Cells[3].Value.ToString() == "True")
                {
                    memberids.Add(row.Cells[0].Value.ToString());
                }
            }

            if (memberids.Count == 0)
            {
                MessageBox.Show("Du måste ange den medlem eller de medlemmar som kontakten är relaterad till.");
                return;
            }

            dt = new DataTable();
            dt = ct.AddContact(memberids);

            MessageBox.Show("Kontakt tillagd");
        }

        private void btnCTcancel_Click(object sender, EventArgs e)
        {
            HidePanels();
            panStart.Show();
        }
        //
        // Kontaktlista
        //
        private void ShowContactlist()
        {
            HidePanels();
            panViewContact.Show();

            Contact ct = new Contact();

            dt = new DataTable();
            bs = new BindingSource();

            dt = ct.GetContactList();
            bs.DataSource = dt;

            dgrViewContact.DataSource = bs;
        }

        private void kontaktlistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowContactlist();
        }

        private void dgrViewContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Contact ct = new Contact();

            dt = new DataTable();
            bs = new BindingSource();

            // Get memberid
            string selectedContact;
            DataGridViewRow selectedRow = dgrViewContact.Rows[e.RowIndex];
            selectedContact = selectedRow.Cells[0].Value.ToString();

            dt = ct.GetContactMembers(selectedContact);
            bs.DataSource = dt;

            dgrViewCTmember.DataSource = bs;
        }

        private void dgrViewContact_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //visibility på members
            HidePanels();
            btnNewContact.Hide();
            panContact.Show();
            btnCTsave.Show();
            lblCTTitle.Text = "Redigera kontakt";
            btnContactList.Show();

            // Get memberid
            string selectedContact;
            DataGridViewRow selectedRow = dgrViewContact.Rows[e.RowIndex];
            selectedContact = selectedRow.Cells[0].Value.ToString();

            Contact ct = new Contact();

            dt = new DataTable();
            dt = ct.GetContactDetail(selectedContact);

            foreach (DataRow row in dt.Rows)
            {
                txtCTfirstname.Text = row["firstname"].ToString();
                txtCTlastname.Text = row["lastname"].ToString();
                txtCTSecuritynr.Text = row["securitynr"].ToString();
                cmbCTgender.Text = row["gender"].ToString();
                txtCTaddress.Text = row["address"].ToString();
                txtCTcity.Text = row["city"].ToString();
                txtCTzipcode.Text = row["zipcode"].ToString();
                txtCTemail.Text = row["email"].ToString();
            }

            dt = new DataTable();
            dt = ct.GetPhone(selectedContact);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["type"] == "phone") { txtCTcellphone.Text = row["phone"].ToString(); }
                if ((string)row["type"] == "cell") { txtCTphone.Text = row["phone"].ToString(); }
            }

            string search = "";

            dt = new DataTable();
            bs = new BindingSource();

            dt = ct.GetMemberContact(search);
            bs.DataSource = dt;

            dgrCTsearchmedlem.DataSource = bs;
        }

        private void btnContactList_Click(object sender, EventArgs e)
        {
            ShowContactlist();
        }
        //
        // Träningsgrupp
        //

        private void ShowTGlist(string search)
        {
            HidePanels();
            panTGGroupList.Show();

            Traininggroup tg = new Traininggroup();

            dt = new DataTable();
            bs = new BindingSource();

            dt = tg.GetTGList(search);
            bs.DataSource = dt;
            dgrViewTGGroupList.DataSource = bs;
        }

        private void träningsgrupperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();

            string search = "";
            ShowTGlist(search);
        }

        private void träningsgruppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyTxtBoxes(panTGGroup);
            HidePanels();
            btnRemoveTG.Hide();
            rbnTGAddMember.Hide();
            rbnTGRemoveMember.Hide();
            cmbAddMember.Hide();
            btnTGSave.Hide();
            lblTGMembers.Hide();
            dgrListTGMembers.Hide();
            txtGroupID.Hide();
            dgvAddLeader.Hide();
            lblGroupID.Hide();
            lblLeader.Hide();
            rbnTGAddLeader.Hide();
            rbnRemoveLeader.Hide();
            cmbAddLeader.Hide();
            btnAddLeader.Hide();
            btnAddMember.Hide();

            panTGGroup.Show();
            btnTGCreate.Show();
            btnTGDiciplin.Show();
            btnTGLevel.Show();

            Traininggroup tg = new Traininggroup();
            dt = new DataTable();
            dt = tg.GetTGLevelList();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbLevel.Items.Add(dt.Rows[i]["name"]);
            }

            dt = tg.GetTGDiciplinList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbDisciplin.Items.Add(dt.Rows[i]["name"]);
            }
        }

        private void btnTGCreate_Click(object sender, EventArgs e)
        {
            Traininggroup nntg = new Traininggroup()
            {
                LevelName = cmbLevel.SelectedItem.ToString(),
                DiciplinName = cmbDisciplin.SelectedItem.ToString()
            };

            int diciplinId;
            int levelId;

            diciplinId = nntg.GetTGDiciplin();
            levelId = nntg.GetTGLevel();

            Traininggroup ntg = new Traininggroup()
            {
                Description = txtTGDescription.Text,
                Name = txtTGName.Text,
                DiciplinId = diciplinId,
                DiciplinName = cmbDisciplin.SelectedItem.ToString(),
                LevelName = cmbLevel.SelectedItem.ToString(),
                LevelId = levelId,
                Notes = txtNotes.Text
            };

            ntg.CreateTG();
            MessageBox.Show("Träningsgrupp skapad");
            EmptyTxtBoxes(panTGGroup);
        }
        
        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        // Närvarolista
        //
        private void närvaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panAdendence.Show();

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("sv-SE"));
            lblATdate.Text = currentDate;

            Attendance at = new Attendance();
            dt = new DataTable();
            bs = new BindingSource();

            dt = at.GetTrainingGroups();
            bs.DataSource = dt;

            

            lstATtraininggroups.DataSource = dt;
            lstATtraininggroups.DisplayMember = "name";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
            string now = date.ToString("yyyy-MM-dd");
            lblATdate.Text = now;
        }

        private void lstATtraininggroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup;
            
            if (lstATtraininggroups.GetItemText(lstATtraininggroups.SelectedValue) != null)
            {
                selectedGroup = lstATtraininggroups.GetItemText(lstATtraininggroups.SelectedValue);

                Attendance at = new Attendance();
                dt = new DataTable();
                bs = new BindingSource();

                dt = at.GetMembers(selectedGroup);
                bs.DataSource = dt;
                dgrATmemberlist.DataSource = bs;


                DataTable _dt = new DataTable();
                BindingSource _bs = new BindingSource();
                dt = at.GetLeaders(selectedGroup);
                bs.DataSource = dt;
                lstATleader.DataSource = bs;
                lstATleader.DisplayMember = "firstname";
            }
        }

        private void btnATsave_Click(object sender, EventArgs e)
        {
            string selectedGroup = lstATtraininggroups.GetItemText(lstATtraininggroups.SelectedValue);
            string description = txtDescription.Text;
            string place = txtLocation.Text;
            string date = lblATdate.Text;
            string starttime = txtTimestart.Text;
            string endtime = txtTimeEnd.Text;

            Attendance at = new Attendance();                       
            List<string> memberids = new List<string>();

            foreach (DataGridViewRow row in dgrATmemberlist.Rows)
            {
                if (row.Cells[4].Value.ToString() == "True")
                {
                    memberids.Add(row.Cells[0].Value.ToString());
                }
            }

            if (memberids.Count == 0)
            {
                MessageBox.Show("Du måste ange den medlem eller de medlemmar som har varit närvarande.");
                return;
            }

            dt = new DataTable();
            dt = at.CreateMemberlist(memberids, selectedGroup, description, place, date, starttime, endtime);

            MessageBox.Show("Närvarolista tillagd");
               
        }

        private void btnATcancel_Click(object sender, EventArgs e)
        {
            HidePanels();
            panStart.Show();
        }
        //
        // Traininggroup
        //
        private void btnTGSearch_Click(object sender, EventArgs e)
        {
            string search = txtTGSearch.Text;

            ShowTGlist(search);
        }

        private void ShowTGLeaderList(int groupid)
        {
            Traininggroup tg = new Traininggroup();

            dt = new DataTable();
            bs = new BindingSource();

            dt = tg.GetTGLeaderList(groupid);
            bs.DataSource = dt;
            dgvAddLeader.DataSource = bs;
        }

        private void ShowTGMemberList(int groupid)
        {
            Traininggroup tg = new Traininggroup();

            dt = new DataTable();
            bs = new BindingSource();

            dt = tg.GetTGMemberList(groupid);
            bs.DataSource = dt;
            dgrListTGMembers.DataSource = bs;
        }

        private void dgrViewTGGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HidePanels();
            btnTGCreate.Hide();
            panTGGroup.Show();
            btnTGSave.Show();
            lblTraningTitle.Text = "Redigera träningsgrupp";
            dgrListTGMembers.Show();
            lblTGMembers.Show();
            btnRemoveTG.Show();
            cmbAddMember.Show();
            rbnTGAddMember.Show();
            rbnTGRemoveMember.Show();
            btnTGLevel.Visible = false;
            btnTGDiciplin.Visible = false;
            lblTGMembers.Show();
            dgrListTGMembers.Show();
            txtGroupID.Show();

            dgvAddLeader.Show();
            lblGroupID.Show();
            lblLeader.Show();
            rbnTGAddLeader.Show();
            rbnRemoveLeader.Show();
            cmbAddLeader.Show();
            btnAddLeader.Show();
            btnAddMember.Show();

            Traininggroup tg = new Traininggroup();
            dt = new DataTable();
            bs = new BindingSource();
            dt = tg.GetTGLevelList();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbLevel.Items.Add(dt.Rows[i]["name"]);
            }

            dt = tg.GetTGDiciplinList();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbDisciplin.Items.Add(dt.Rows[i]["name"]);
            }



            string selectedTG;
            DataGridViewRow selectedRow = dgrViewTGGroupList.Rows[e.RowIndex];
            selectedTG = selectedRow.Cells[0].Value.ToString();

            dt = new DataTable();
            dt = tg.GetTGDetail(selectedTG);

            foreach (DataRow row in dt.Rows)
            {
                txtNotes.Text = row["Noteringar"].ToString();
                txtGroupID.Text = row["GruppID"].ToString();
                txtTGName.Text = row["Gruppnamn"].ToString();
                cmbDisciplin.SelectedItem = row["Disciplin"].ToString();
                cmbLevel.SelectedItem = row["Nivå"].ToString();
                txtTGDescription.Text = row["Beskrivning"].ToString();
            }

            Member nm = new Member();
            dt = nm.GetTGMembers();
            cmbAddMember.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbAddMember.Items.Add(dt.Rows[i]["memberid"] + " - " + dt.Rows[i]["firstname"] + " " + dt.Rows[i]["lastname"] + " " + dt.Rows[i]["securitynr"]);
            }

            dt = nm.GetTGLeader();
            cmbAddLeader.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbAddLeader.Items.Add(dt.Rows[i]["memberid"] + " - " + dt.Rows[i]["firstname"] + " " + dt.Rows[i]["lastname"] + " " + dt.Rows[i]["securitynr"]);
            }

            bs = new BindingSource();
            bs.DataSource = dt;

            dgrCTsearchmedlem.DataSource = bs;
            int groupid = Convert.ToInt32(txtGroupID.Text);
            ShowTGLeaderList(groupid);
            ShowTGMemberList(groupid);
        }

        private void btnTGSave_Click(object sender, EventArgs e)
        {
            Traininggroup nntg = new Traininggroup()
            {
                LevelName = cmbLevel.SelectedItem.ToString(),
                DiciplinName = cmbDisciplin.SelectedItem.ToString()
            };

            int diciplinId;
            int levelId;

            diciplinId = nntg.GetTGDiciplin();
            levelId = nntg.GetTGLevel();

            Traininggroup tg = new Traininggroup()
            {
                GroupId = Convert.ToInt32(txtGroupID.Text),
                Description = txtTGDescription.Text,
                Name = txtTGName.Text,
                DiciplinId = diciplinId,
                DiciplinName = cmbDisciplin.SelectedItem.ToString(),
                LevelName = cmbLevel.SelectedItem.ToString(),
                LevelId = levelId
            };

            tg.UpdateTG();
            MessageBox.Show("Träningsgrupp " + txtGroupID.Text + " är nu uppdaterad");
        }

        private void btnAddLeader_Click(object sender, EventArgs e)
        {
            Traininggroup ntg = new Traininggroup();

            int groupid = Convert.ToInt32(txtGroupID.Text);
            bool leader = true;

            if (rbnTGAddLeader.Checked)
            {
                string member = cmbAddLeader.SelectedItem.ToString();
                string[] list = member.Split(' ');
                int memberid = Convert.ToInt32(list[0]);
                ntg.AddTGMember(memberid, groupid, leader);
                cmbAddLeader.Items.Remove(member);
                member = null;
            }

            else if (rbnRemoveLeader.Checked)
            {
                string delete = dgvAddLeader.CurrentCell.FormattedValue.ToString();
                ntg.deleteTGLeader(delete);
                delete = null;
            }
            else
            {
                MessageBox.Show("Du måste välja att lägga till eller ta bort en ledare.");
            }

            ShowTGLeaderList(groupid);
            ShowTGMemberList(groupid);
        }
        
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            Traininggroup ntg = new Traininggroup();

            int groupid = Convert.ToInt32(txtGroupID.Text);
            bool leader = false;


            if (rbnTGAddMember.Checked)
            {
                string member = cmbAddMember.SelectedItem.ToString();
                string[] list = member.Split(' ');
                int memberid = Convert.ToInt32(list[0]);
                ntg.AddTGMember(memberid, groupid, leader);
                cmbAddMember.Items.Remove(member);
            }
                
            else if (rbnTGRemoveMember.Checked)
            {
                string delete = dgrListTGMembers.CurrentCell.FormattedValue.ToString();
                ntg.deleteTGMember(delete);
                delete = null;
            }
            else
            {
                MessageBox.Show("Du måste välja att lägga till eller ta bort en medlem.");
            }

            ShowTGMemberList(groupid);
        }

        private void btnRemoveTG_Click(object sender, EventArgs e)
        {
            int delete = Convert.ToInt32(txtGroupID.Text);
            Traininggroup ntg = new Traininggroup();
            ntg.deleteTG(delete);
            MessageBox.Show("Träningsgruppen är borttagen");
            EmptyTxtBoxes(panTGGroup);
            dgvAddLeader.DataSource = null;
            dgrListTGMembers.DataSource = null;
        }

        private void btnTGDiciplin_Click(object sender, EventArgs e)
        {
            FormDisciplin disciplin = new FormDisciplin();
            disciplin.Show();
        }

        private void btnTGLevel_Click(object sender, EventArgs e)
        {
            frmLevel level = new frmLevel();
            level.Show();
        }

        private void ShowAttendancelist()
        {
            HidePanels();
            panViewAttendance.Show();

            Attendance at = new Attendance();
            dt = new DataTable();
            bs = new BindingSource();

            dt = at.countParticipant();
            bs.DataSource = dt;
            dgvAttendancelist.DataSource = bs;
        }

        private void närvaroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAttendancelist();

            dtVATfrom.CustomFormat = " ";
            dtVATfrom.Format = DateTimePickerFormat.Custom;

            dtVATto.CustomFormat = " ";
            dtVATto.Format = DateTimePickerFormat.Custom;
        }

        private void dgvAttendancelist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //visibility på members
            HidePanels();       
            panPrint.Show();
            txtTGroupName.Enabled = false;
            txtTGroupID.Enabled = false;
            txtSumTG.Enabled = false;
            txtATSum.Enabled = false;

            // Get memberid
            DataGridViewRow selectedRow = dgvAttendancelist.Rows[e.RowIndex];
            int selectedID = Convert.ToInt32(selectedRow.Cells[2].Value);
            string selectedName = selectedRow.Cells[3].Value.ToString();
            txtTGroupID.Text = selectedID.ToString();
            txtTGroupName.Text = selectedName;

            Attendance at = new Attendance();
            dt = new DataTable();
            bs = new BindingSource();
            
            dt = at.showAttendance(selectedID);
            bs.DataSource = dt;
            dgvAttendance.DataSource = bs;

            string selectedGroup = txtTGroupID.Text;

            Attendance at1 = new Attendance();
            DataTable dt1 = new DataTable();
            BindingSource bs1 = new BindingSource();

            dt1 = at1.GetLeadersAtt(selectedGroup);
            bs1.DataSource = dt1;
            listAttLeader.DataSource = bs1;
            listAttLeader.DisplayMember = "firstname";
            
            int tgSum = at1.findTGSum(selectedID);
            txtSumTG.Text = tgSum.ToString();

            int atSum = at1.findATSum(selectedID);
            txtATSum.Text = atSum.ToString();

            
        }
        

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Attendance at = new Attendance();
            DataGridViewRow selectedRow = dgvAttendance.Rows[e.RowIndex];
            string selectedID = selectedRow.Cells[0].Value.ToString();

            dt = new DataTable();
            bs = new BindingSource();

            dt = at.showAttenders(selectedID);
            bs.DataSource = dt;
            dgvAttendees.DataSource = bs;
        }

        private void dtVATfrom_CloseUp(object sender, EventArgs e)
        {
            dtVATfrom.CustomFormat = "yyyy-MM-dd";
            dtVATfrom.Format = DateTimePickerFormat.Custom;

            string mydate = dtVATfrom.Value.ToString();

            Attendance at = new Attendance();
            at.DateFrom(mydate);

            ShowAttendancelist();
        }

        private void dtVATto_CloseUp(object sender, EventArgs e)
        {
            dtVATto.CustomFormat = "yyyy-MM-dd";
            dtVATto.Format = DateTimePickerFormat.Custom;
        }

        private void ledareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels();
            panLeader.Show();

            Member mb = new Member();

            dt = new DataTable();
            bs = new BindingSource();

            dt = mb.GetLeaderList();
            bs.DataSource = dt;

            dgvLeader.DataSource = bs;
        }

        private void dgvLeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Member mb = new Member();
            dt = new DataTable();
            bs = new BindingSource();

            // Get memberid
            int selectedLeader;
            DataGridViewRow selectedRow = dgvLeader.Rows[e.RowIndex];
            selectedLeader = Convert.ToInt32(selectedRow.Cells[0].Value);

            dt = mb.GetGroupLeader(selectedLeader);
            bs.DataSource = dt;

            dgvGroupLeader.DataSource = bs;
        }
    }
}
