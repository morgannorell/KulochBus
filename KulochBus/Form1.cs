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
            foreach (Control c in Controls)
            {
                if (c is Panel) c.Visible = false;
            }
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

        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBoxMembership_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panNewMember_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
