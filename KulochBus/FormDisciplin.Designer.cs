namespace KulochBus
{
    partial class FormDisciplin
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
            this.btnLDisciplinClose = new System.Windows.Forms.Button();
            this.rbnDisciplinRemove = new System.Windows.Forms.RadioButton();
            this.rbnDisciplinAdd = new System.Windows.Forms.RadioButton();
            this.btnDisciplinSave = new System.Windows.Forms.Button();
            this.txtDisciplin = new System.Windows.Forms.TextBox();
            this.lblDisciplin = new System.Windows.Forms.Label();
            this.dgrViewDisciplin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewDisciplin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLDisciplinClose
            // 
            this.btnLDisciplinClose.Location = new System.Drawing.Point(98, 179);
            this.btnLDisciplinClose.Name = "btnLDisciplinClose";
            this.btnLDisciplinClose.Size = new System.Drawing.Size(75, 23);
            this.btnLDisciplinClose.TabIndex = 27;
            this.btnLDisciplinClose.Text = "Stäng";
            this.btnLDisciplinClose.UseVisualStyleBackColor = true;
            this.btnLDisciplinClose.Click += new System.EventHandler(this.btnLDisciplinClose_Click);
            // 
            // rbnDisciplinRemove
            // 
            this.rbnDisciplinRemove.AutoSize = true;
            this.rbnDisciplinRemove.Location = new System.Drawing.Point(17, 107);
            this.rbnDisciplinRemove.Name = "rbnDisciplinRemove";
            this.rbnDisciplinRemove.Size = new System.Drawing.Size(59, 17);
            this.rbnDisciplinRemove.TabIndex = 26;
            this.rbnDisciplinRemove.TabStop = true;
            this.rbnDisciplinRemove.Text = "Ta bort";
            this.rbnDisciplinRemove.UseVisualStyleBackColor = true;
            // 
            // rbnDisciplinAdd
            // 
            this.rbnDisciplinAdd.AutoSize = true;
            this.rbnDisciplinAdd.Location = new System.Drawing.Point(17, 86);
            this.rbnDisciplinAdd.Name = "rbnDisciplinAdd";
            this.rbnDisciplinAdd.Size = new System.Drawing.Size(65, 17);
            this.rbnDisciplinAdd.TabIndex = 25;
            this.rbnDisciplinAdd.TabStop = true;
            this.rbnDisciplinAdd.Text = "Lägg Till";
            this.rbnDisciplinAdd.UseVisualStyleBackColor = true;
            // 
            // btnDisciplinSave
            // 
            this.btnDisciplinSave.Location = new System.Drawing.Point(17, 179);
            this.btnDisciplinSave.Name = "btnDisciplinSave";
            this.btnDisciplinSave.Size = new System.Drawing.Size(75, 23);
            this.btnDisciplinSave.TabIndex = 24;
            this.btnDisciplinSave.Text = "Spara";
            this.btnDisciplinSave.UseVisualStyleBackColor = true;
            this.btnDisciplinSave.Click += new System.EventHandler(this.btnDisciplinSave_Click_1);
            // 
            // txtDisciplin
            // 
            this.txtDisciplin.Location = new System.Drawing.Point(17, 60);
            this.txtDisciplin.Name = "txtDisciplin";
            this.txtDisciplin.Size = new System.Drawing.Size(183, 20);
            this.txtDisciplin.TabIndex = 23;
            // 
            // lblDisciplin
            // 
            this.lblDisciplin.AutoSize = true;
            this.lblDisciplin.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisciplin.Location = new System.Drawing.Point(11, 10);
            this.lblDisciplin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisciplin.Name = "lblDisciplin";
            this.lblDisciplin.Size = new System.Drawing.Size(117, 32);
            this.lblDisciplin.TabIndex = 22;
            this.lblDisciplin.Text = "Disciplin";
            // 
            // dgrViewDisciplin
            // 
            this.dgrViewDisciplin.AllowUserToAddRows = false;
            this.dgrViewDisciplin.AllowUserToDeleteRows = false;
            this.dgrViewDisciplin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrViewDisciplin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrViewDisciplin.Location = new System.Drawing.Point(224, 60);
            this.dgrViewDisciplin.Name = "dgrViewDisciplin";
            this.dgrViewDisciplin.Size = new System.Drawing.Size(168, 143);
            this.dgrViewDisciplin.TabIndex = 21;
            // 
            // FormDisciplin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(402, 211);
            this.Controls.Add(this.btnLDisciplinClose);
            this.Controls.Add(this.rbnDisciplinRemove);
            this.Controls.Add(this.rbnDisciplinAdd);
            this.Controls.Add(this.btnDisciplinSave);
            this.Controls.Add(this.txtDisciplin);
            this.Controls.Add(this.lblDisciplin);
            this.Controls.Add(this.dgrViewDisciplin);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDisciplin";
            this.Text = "FormDisciplin";
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewDisciplin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLDisciplinClose;
        private System.Windows.Forms.RadioButton rbnDisciplinRemove;
        private System.Windows.Forms.RadioButton rbnDisciplinAdd;
        private System.Windows.Forms.Button btnDisciplinSave;
        private System.Windows.Forms.TextBox txtDisciplin;
        private System.Windows.Forms.Label lblDisciplin;
        private System.Windows.Forms.DataGridView dgrViewDisciplin;
    }
}