﻿using System;
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

            var membership = (Membership)comboBoxMembership.SelectedItem;

            Person newPerson = new Person(txtFirstName.Text, txtLastName.Text, txtSecurityNr.Text, txtAddress.Text, txtZipcode.Text, txtCity.Text, txtEmail.Text, comboBoxGender.SelectedItem.ToString());
            var newPersonId = newPerson.createPerson();

            Member newMember = new Member(newPersonId, txtResponsibility.Text, membership.Name, checkBoxPicture.Checked, checkBoxLeader.Checked, membership.Price);
            var newMemberId = newMember.createMember();

            Phone newPhone = new Phone(newPersonId, txtPhoneAreaCode.Text, txtPhone.Text, txtCellphoneAreaCode.Text, txtCellphone.Text);
            newPhone.createPhone();
            newPhone.createCellphone();
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

            Sql getMemberList = new Sql();
            getMemberList.Connect();

            string sql = "SELECT personid, firstname, lastname, securitynr, gender, membership, ispayed " +
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
            //lägg till medlemmar i datagrid
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

            DataTable tb = new DataTable();
            BindingSource bs = new BindingSource();

            tb = getMemberList.Select(sql);
            bs.DataSource = tb;
            dgrViewMember.DataSource = bs;

            getMemberList.Close();
        }

        private void dgrViewMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //HidePanels();
            //panNewContact.Show();

            // Get memberid
            string selectedMember;
            DataGridViewRow selectedRow = this.dgrViewMember.Rows[e.RowIndex];
            selectedMember = selectedRow.Cells[0].Value.ToString();

            txtTest.Text = selectedMember;

            Sql getMemberDetails = new Sql();
            getMemberDetails.Connect();

            string querry =
                "SELECT firstname, lastname, securitynr, address, " +
                "zipcode, city, email, gender " +
                "WHERE personid = " + selectedMember;

            DataTable dt = new DataTable();

            
        }
    }
}
