namespace plugin_profile
{
    partial class ProfileSettingsForm
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
            this.textBoxContractHash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxContractHash
            // 
            this.textBoxContractHash.Location = new System.Drawing.Point(200, 21);
            this.textBoxContractHash.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxContractHash.Name = "textBoxContractHash";
            this.textBoxContractHash.Size = new System.Drawing.Size(365, 25);
            this.textBoxContractHash.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contract script hash:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(489, 97);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(398, 97);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // ProfileSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 149);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxContractHash);
            this.Controls.Add(this.label1);
            this.Name = "ProfileSettingsForm";
            this.Text = "Profile settings";
            this.Load += new System.EventHandler(this.ProfileSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContractHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonReset;
    }
}