namespace KulochBus
{
    partial class frmDisciplin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDisciplinClose = new System.Windows.Forms.Button();
            this.rbnDisciplinRemove = new System.Windows.Forms.RadioButton();
            this.rbnDisciplinAdd = new System.Windows.Forms.RadioButton();
            this.btnDisciplinSave = new System.Windows.Forms.Button();
            this.txtDisciplin = new System.Windows.Forms.TextBox();
            this.lblDisciplin = new System.Windows.Forms.Label();
            this.dgrViewDisciplin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewDisciplin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisciplinClose
            // 
            this.btnDisciplinClose.Location = new System.Drawing.Point(147, 272);
            this.btnDisciplinClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisciplinClose.Name = "btnDisciplinClose";
            this.btnDisciplinClose.Size = new System.Drawing.Size(112, 35);
            this.btnDisciplinClose.TabIndex = 27;
            this.btnDisciplinClose.Text = "Stäng";
            this.btnDisciplinClose.UseVisualStyleBackColor = true;
            // 
            // rbnDisciplinRemove
            // 
            this.rbnDisciplinRemove.AutoSize = true;
            this.rbnDisciplinRemove.Location = new System.Drawing.Point(26, 160);
            this.rbnDisciplinRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnDisciplinRemove.Name = "rbnDisciplinRemove";
            this.rbnDisciplinRemove.Size = new System.Drawing.Size(84, 24);
            this.rbnDisciplinRemove.TabIndex = 26;
            this.rbnDisciplinRemove.TabStop = true;
            this.rbnDisciplinRemove.Text = "Ta bort";
            this.rbnDisciplinRemove.UseVisualStyleBackColor = true;
            // 
            // rbnDisciplinAdd
            // 
            this.rbnDisciplinAdd.AutoSize = true;
            this.rbnDisciplinAdd.Location = new System.Drawing.Point(26, 128);
            this.rbnDisciplinAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnDisciplinAdd.Name = "rbnDisciplinAdd";
            this.rbnDisciplinAdd.Size = new System.Drawing.Size(92, 24);
            this.rbnDisciplinAdd.TabIndex = 25;
            this.rbnDisciplinAdd.TabStop = true;
            this.rbnDisciplinAdd.Text = "Lägg Till";
            this.rbnDisciplinAdd.UseVisualStyleBackColor = true;
            // 
            // btnDisciplinSave
            // 
            this.btnDisciplinSave.Location = new System.Drawing.Point(26, 272);
            this.btnDisciplinSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisciplinSave.Name = "btnDisciplinSave";
            this.btnDisciplinSave.Size = new System.Drawing.Size(112, 35);
            this.btnDisciplinSave.TabIndex = 24;
            this.btnDisciplinSave.Text = "Spara";
            this.btnDisciplinSave.UseVisualStyleBackColor = true;
            this.btnDisciplinSave.Click += new System.EventHandler(this.btnDisciplinSave_Click);
            // 
            // txtDisciplin
            // 
            this.txtDisciplin.Location = new System.Drawing.Point(26, 88);
            this.txtDisciplin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisciplin.Name = "txtDisciplin";
            this.txtDisciplin.Size = new System.Drawing.Size(272, 26);
            this.txtDisciplin.TabIndex = 23;
            // 
            // lblDisciplin
            // 
            this.lblDisciplin.AutoSize = true;
            this.lblDisciplin.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisciplin.Location = new System.Drawing.Point(16, 11);
            this.lblDisciplin.Name = "lblDisciplin";
            this.lblDisciplin.Size = new System.Drawing.Size(171, 47);
            this.lblDisciplin.TabIndex = 22;
            this.lblDisciplin.Text = "Disciplin";
            // 
            // dgrViewDisciplin
            // 
            this.dgrViewDisciplin.AllowUserToAddRows = false;
            this.dgrViewDisciplin.AllowUserToDeleteRows = false;
            this.dgrViewDisciplin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrViewDisciplin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrViewDisciplin.Location = new System.Drawing.Point(336, 88);
            this.dgrViewDisciplin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrViewDisciplin.Name = "dgrViewDisciplin";
            this.dgrViewDisciplin.Size = new System.Drawing.Size(252, 220);
            this.dgrViewDisciplin.TabIndex = 21;
            // 
            // frmLevel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 328);
            this.Controls.Add(this.btnDisciplinClose);
            this.Controls.Add(this.rbnDisciplinRemove);
            this.Controls.Add(this.rbnDisciplinAdd);
            this.Controls.Add(this.btnDisciplinSave);
            this.Controls.Add(this.txtDisciplin);
            this.Controls.Add(this.lblDisciplin);
            this.Controls.Add(this.dgrViewDisciplin);
            this.Name = "frmLevel2";
            this.Text = "frmLevel2";
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewDisciplin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisciplinClose;
        private System.Windows.Forms.RadioButton rbnDisciplinRemove;
        private System.Windows.Forms.RadioButton rbnDisciplinAdd;
        private System.Windows.Forms.Button btnDisciplinSave;
        private System.Windows.Forms.TextBox txtDisciplin;
        private System.Windows.Forms.Label lblDisciplin;
        private System.Windows.Forms.DataGridView dgrViewDisciplin;

    }
}