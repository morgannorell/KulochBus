namespace KulochBus
{
    partial class frmLevel
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
            this.dgrViewLevels = new System.Windows.Forms.DataGridView();
            this.lblLevelTitle = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.btnLevelSave = new System.Windows.Forms.Button();
            this.rbnLevelRemove = new System.Windows.Forms.RadioButton();
            this.rbnLevelAdd = new System.Windows.Forms.RadioButton();
            this.btnLevelClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrViewLevels
            // 
            this.dgrViewLevels.AllowUserToAddRows = false;
            this.dgrViewLevels.AllowUserToDeleteRows = false;
            this.dgrViewLevels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrViewLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrViewLevels.Location = new System.Drawing.Point(336, 91);
            this.dgrViewLevels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrViewLevels.Name = "dgrViewLevels";
            this.dgrViewLevels.Size = new System.Drawing.Size(252, 220);
            this.dgrViewLevels.TabIndex = 0;
            this.dgrViewLevels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrViewLevels_CellContentClick);
            // 
            // lblLevelTitle
            // 
            this.lblLevelTitle.AutoSize = true;
            this.lblLevelTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelTitle.Location = new System.Drawing.Point(16, 14);
            this.lblLevelTitle.Name = "lblLevelTitle";
            this.lblLevelTitle.Size = new System.Drawing.Size(100, 47);
            this.lblLevelTitle.TabIndex = 1;
            this.lblLevelTitle.Text = "Nivå";
            this.lblLevelTitle.Click += new System.EventHandler(this.lblLevelTitle_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(26, 91);
            this.txtLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(272, 26);
            this.txtLevel.TabIndex = 2;
            this.txtLevel.TextChanged += new System.EventHandler(this.txtLevel_TextChanged);
            // 
            // btnLevelSave
            // 
            this.btnLevelSave.Location = new System.Drawing.Point(26, 275);
            this.btnLevelSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLevelSave.Name = "btnLevelSave";
            this.btnLevelSave.Size = new System.Drawing.Size(112, 35);
            this.btnLevelSave.TabIndex = 3;
            this.btnLevelSave.Text = "Spara";
            this.btnLevelSave.UseVisualStyleBackColor = true;
            this.btnLevelSave.Click += new System.EventHandler(this.btnLevelSave_Click);
            // 
            // rbnLevelRemove
            // 
            this.rbnLevelRemove.AutoSize = true;
            this.rbnLevelRemove.Location = new System.Drawing.Point(26, 163);
            this.rbnLevelRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnLevelRemove.Name = "rbnLevelRemove";
            this.rbnLevelRemove.Size = new System.Drawing.Size(84, 24);
            this.rbnLevelRemove.TabIndex = 19;
            this.rbnLevelRemove.TabStop = true;
            this.rbnLevelRemove.Text = "Ta bort";
            this.rbnLevelRemove.UseVisualStyleBackColor = true;
            this.rbnLevelRemove.CheckedChanged += new System.EventHandler(this.rbnLevelRemove_CheckedChanged);
            // 
            // rbnLevelAdd
            // 
            this.rbnLevelAdd.AutoSize = true;
            this.rbnLevelAdd.Location = new System.Drawing.Point(26, 131);
            this.rbnLevelAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnLevelAdd.Name = "rbnLevelAdd";
            this.rbnLevelAdd.Size = new System.Drawing.Size(92, 24);
            this.rbnLevelAdd.TabIndex = 18;
            this.rbnLevelAdd.TabStop = true;
            this.rbnLevelAdd.Text = "Lägg Till";
            this.rbnLevelAdd.UseVisualStyleBackColor = true;
            this.rbnLevelAdd.CheckedChanged += new System.EventHandler(this.rbnLevelAdd_CheckedChanged);
            // 
            // btnLevelClose
            // 
            this.btnLevelClose.Location = new System.Drawing.Point(147, 275);
            this.btnLevelClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLevelClose.Name = "btnLevelClose";
            this.btnLevelClose.Size = new System.Drawing.Size(112, 35);
            this.btnLevelClose.TabIndex = 20;
            this.btnLevelClose.Text = "Stäng";
            this.btnLevelClose.UseVisualStyleBackColor = true;
            this.btnLevelClose.Click += new System.EventHandler(this.btnLevelClose_Click);
            // 
            // frmLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 326);
            this.Controls.Add(this.btnLevelClose);
            this.Controls.Add(this.rbnLevelRemove);
            this.Controls.Add(this.rbnLevelAdd);
            this.Controls.Add(this.btnLevelSave);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblLevelTitle);
            this.Controls.Add(this.dgrViewLevels);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLevel";
            this.Text = "Träningsnivåer";
            ((System.ComponentModel.ISupportInitialize)(this.dgrViewLevels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrViewLevels;
        private System.Windows.Forms.Label lblLevelTitle;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Button btnLevelSave;
        private System.Windows.Forms.RadioButton rbnLevelRemove;
        private System.Windows.Forms.RadioButton rbnLevelAdd;
        private System.Windows.Forms.Button btnLevelClose;
    }
}