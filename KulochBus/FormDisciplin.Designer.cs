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
            this.btnLDisciplinClose.Location = new System.Drawing.Point(147, 275);
            this.btnLDisciplinClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLDisciplinClose.Name = "btnLDisciplinClose";
            this.btnLDisciplinClose.Size = new System.Drawing.Size(112, 35);
            this.btnLDisciplinClose.TabIndex = 27;
            this.btnLDisciplinClose.Text = "Stäng";
            this.btnLDisciplinClose.UseVisualStyleBackColor = true;
            this.btnLDisciplinClose.Click += new System.EventHandler(this.btnLDisciplinClose_Click);
            // 
            // rbnDisciplinRemove
            // 
            this.rbnDisciplinRemove.AutoSize = true;
            this.rbnDisciplinRemove.Location = new System.Drawing.Point(26, 165);
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
            this.rbnDisciplinAdd.Location = new System.Drawing.Point(26, 132);
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
            this.btnDisciplinSave.Location = new System.Drawing.Point(26, 275);
            this.btnDisciplinSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisciplinSave.Name = "btnDisciplinSave";
            this.btnDisciplinSave.Size = new System.Drawing.Size(112, 35);
            this.btnDisciplinSave.TabIndex = 24;
            this.btnDisciplinSave.Text = "Spara";
            this.btnDisciplinSave.UseVisualStyleBackColor = true;
            this.btnDisciplinSave.Click += new System.EventHandler(this.btnDisciplinSave_Click_1);
            // 
            // txtDisciplin
            // 
            this.txtDisciplin.Location = new System.Drawing.Point(26, 92);
            this.txtDisciplin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisciplin.Name = "txtDisciplin";
            this.txtDisciplin.Size = new System.Drawing.Size(272, 26);
            this.txtDisciplin.TabIndex = 23;
            // 
            // lblDisciplin
            // 
            this.lblDisciplin.AutoSize = true;
            this.lblDisciplin.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisciplin.Location = new System.Drawing.Point(16, 15);
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
            this.dgrViewDisciplin.Location = new System.Drawing.Point(336, 92);
            this.dgrViewDisciplin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrViewDisciplin.Name = "dgrViewDisciplin";
            this.dgrViewDisciplin.Size = new System.Drawing.Size(252, 220);
            this.dgrViewDisciplin.TabIndex = 21;
            // 
            // FormDisciplin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 325);
            this.Controls.Add(this.btnLDisciplinClose);
            this.Controls.Add(this.rbnDisciplinRemove);
            this.Controls.Add(this.rbnDisciplinAdd);
            this.Controls.Add(this.btnDisciplinSave);
            this.Controls.Add(this.txtDisciplin);
            this.Controls.Add(this.lblDisciplin);
            this.Controls.Add(this.dgrViewDisciplin);
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