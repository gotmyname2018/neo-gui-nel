namespace plugin_profile
{
    partial class ProfileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxContractHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxProfile = new System.Windows.Forms.TextBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVerificationStatus = new System.Windows.Forms.Label();
            this.linkLabelVerifyLink = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contract script hash:";
            // 
            // textBoxContractHash
            // 
            this.textBoxContractHash.Location = new System.Drawing.Point(229, 16);
            this.textBoxContractHash.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxContractHash.Name = "textBoxContractHash";
            this.textBoxContractHash.Size = new System.Drawing.Size(424, 25);
            this.textBoxContractHash.TabIndex = 1;
            this.textBoxContractHash.Text = "0x2e88caf10afe621e90142357236834e010b16df2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "My accounts:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(431, 403);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 29);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // comboBoxAccounts
            // 
            this.comboBoxAccounts.FormattingEnabled = true;
            this.comboBoxAccounts.Location = new System.Drawing.Point(229, 62);
            this.comboBoxAccounts.Name = "comboBoxAccounts";
            this.comboBoxAccounts.Size = new System.Drawing.Size(424, 23);
            this.comboBoxAccounts.TabIndex = 6;
            this.comboBoxAccounts.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccounts_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelVerifyLink);
            this.groupBox1.Controls.Add(this.labelVerificationStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxProfile);
            this.groupBox1.Location = new System.Drawing.Point(44, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 260);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile";
            // 
            // textBoxProfile
            // 
            this.textBoxProfile.Location = new System.Drawing.Point(20, 25);
            this.textBoxProfile.Multiline = true;
            this.textBoxProfile.Name = "textBoxProfile";
            this.textBoxProfile.ReadOnly = true;
            this.textBoxProfile.Size = new System.Drawing.Size(567, 182);
            this.textBoxProfile.TabIndex = 0;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Enabled = false;
            this.buttonQuery.Location = new System.Drawing.Point(554, 403);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(100, 29);
            this.buttonQuery.TabIndex = 8;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(306, 403);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 29);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Visible = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email verified:";
            // 
            // labelVerificationStatus
            // 
            this.labelVerificationStatus.AutoSize = true;
            this.labelVerificationStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelVerificationStatus.Location = new System.Drawing.Point(142, 229);
            this.labelVerificationStatus.Name = "labelVerificationStatus";
            this.labelVerificationStatus.Size = new System.Drawing.Size(23, 15);
            this.labelVerificationStatus.TabIndex = 2;
            this.labelVerificationStatus.Text = "No";
            // 
            // linkLabelVerifyLink
            // 
            this.linkLabelVerifyLink.AutoSize = true;
            this.linkLabelVerifyLink.Location = new System.Drawing.Point(220, 229);
            this.linkLabelVerifyLink.Name = "linkLabelVerifyLink";
            this.linkLabelVerifyLink.Size = new System.Drawing.Size(367, 15);
            this.linkLabelVerifyLink.TabIndex = 3;
            this.linkLabelVerifyLink.TabStop = true;
            this.linkLabelVerifyLink.Text = "Click here to start email address verificaion";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 461);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxAccounts);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContractHash);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProfileForm";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxContractHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxAccounts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxProfile;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.LinkLabel linkLabelVerifyLink;
        private System.Windows.Forms.Label labelVerificationStatus;
        private System.Windows.Forms.Label label3;
    }
}