namespace plugin_profile
{
    partial class ManualVerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualVerifyForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxChallengeGenerated = new System.Windows.Forms.TextBox();
            this.buttonGenChallenge = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxChallengeSend = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxResponseReceived = new System.Windows.Forms.TextBox();
            this.buttonVerifyResponse = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxResponseGenerated = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxChallengeReceived = new System.Windows.Forms.TextBox();
            this.buttonGenResponse = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPeerEmail = new System.Windows.Forms.TextBox();
            this.labelPeerEmail = new System.Windows.Forms.Label();
            this.buttonSendResponse = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 127);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 349);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonGenChallenge);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate challenge";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(14, 230);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(499, 71);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Send a challenge email to the email address to be verified, \r\nuse the above chall" +
    "enge text as the content of the email,\r\nuse \"### Email Address Verification Chal" +
    "lenge ###\" as title.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxChallengeGenerated);
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Challenge to send";
            // 
            // textBoxChallengeGenerated
            // 
            this.textBoxChallengeGenerated.Location = new System.Drawing.Point(7, 25);
            this.textBoxChallengeGenerated.Multiline = true;
            this.textBoxChallengeGenerated.Name = "textBoxChallengeGenerated";
            this.textBoxChallengeGenerated.ReadOnly = true;
            this.textBoxChallengeGenerated.Size = new System.Drawing.Size(636, 178);
            this.textBoxChallengeGenerated.TabIndex = 0;
            // 
            // buttonGenChallenge
            // 
            this.buttonGenChallenge.Location = new System.Drawing.Point(519, 230);
            this.buttonGenChallenge.Name = "buttonGenChallenge";
            this.buttonGenChallenge.Size = new System.Drawing.Size(144, 71);
            this.buttonGenChallenge.TabIndex = 2;
            this.buttonGenChallenge.Text = "Generate challenge";
            this.buttonGenChallenge.UseVisualStyleBackColor = true;
            this.buttonGenChallenge.Click += new System.EventHandler(this.buttonGenChallenge_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.buttonVerifyResponse);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Verify response";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxChallengeSend);
            this.groupBox6.Location = new System.Drawing.Point(14, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(314, 206);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Challenge send";
            // 
            // textBoxChallengeSend
            // 
            this.textBoxChallengeSend.Location = new System.Drawing.Point(6, 20);
            this.textBoxChallengeSend.Multiline = true;
            this.textBoxChallengeSend.Name = "textBoxChallengeSend";
            this.textBoxChallengeSend.Size = new System.Drawing.Size(302, 176);
            this.textBoxChallengeSend.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(14, 230);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(509, 71);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Copy the content of the received response email to above,\r\nclick the \"Verify resp" +
    "onse\" button to verify it.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxResponseReceived);
            this.groupBox2.Location = new System.Drawing.Point(343, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 206);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Response received";
            // 
            // textBoxResponseReceived
            // 
            this.textBoxResponseReceived.Location = new System.Drawing.Point(6, 24);
            this.textBoxResponseReceived.Multiline = true;
            this.textBoxResponseReceived.Name = "textBoxResponseReceived";
            this.textBoxResponseReceived.Size = new System.Drawing.Size(308, 176);
            this.textBoxResponseReceived.TabIndex = 1;
            // 
            // buttonVerifyResponse
            // 
            this.buttonVerifyResponse.Location = new System.Drawing.Point(529, 229);
            this.buttonVerifyResponse.Name = "buttonVerifyResponse";
            this.buttonVerifyResponse.Size = new System.Drawing.Size(134, 72);
            this.buttonVerifyResponse.TabIndex = 5;
            this.buttonVerifyResponse.Text = "Verify response";
            this.buttonVerifyResponse.UseVisualStyleBackColor = true;
            this.buttonVerifyResponse.Click += new System.EventHandler(this.buttonVerifyResponse_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSendResponse);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.buttonGenResponse);
            this.tabPage3.Controls.Add(this.textBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(680, 320);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generate response";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxResponseGenerated);
            this.groupBox5.Location = new System.Drawing.Point(348, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(314, 206);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Response to send";
            // 
            // textBoxResponseGenerated
            // 
            this.textBoxResponseGenerated.Location = new System.Drawing.Point(6, 20);
            this.textBoxResponseGenerated.Multiline = true;
            this.textBoxResponseGenerated.Name = "textBoxResponseGenerated";
            this.textBoxResponseGenerated.Size = new System.Drawing.Size(302, 176);
            this.textBoxResponseGenerated.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxChallengeReceived);
            this.groupBox3.Location = new System.Drawing.Point(15, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 206);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Challenge received";
            // 
            // textBoxChallengeReceived
            // 
            this.textBoxChallengeReceived.Location = new System.Drawing.Point(6, 20);
            this.textBoxChallengeReceived.Multiline = true;
            this.textBoxChallengeReceived.Name = "textBoxChallengeReceived";
            this.textBoxChallengeReceived.Size = new System.Drawing.Size(302, 176);
            this.textBoxChallengeReceived.TabIndex = 1;
            // 
            // buttonGenResponse
            // 
            this.buttonGenResponse.Location = new System.Drawing.Point(524, 229);
            this.buttonGenResponse.Name = "buttonGenResponse";
            this.buttonGenResponse.Size = new System.Drawing.Size(140, 40);
            this.buttonGenResponse.TabIndex = 10;
            this.buttonGenResponse.Text = "Generate response";
            this.buttonGenResponse.UseVisualStyleBackColor = true;
            this.buttonGenResponse.Click += new System.EventHandler(this.buttonGenResponse_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(15, 229);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(503, 74);
            this.textBox7.TabIndex = 12;
            this.textBox7.Text = resources.GetString("textBox7.Text");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxAccounts);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxPeerEmail);
            this.groupBox4.Controls.Add(this.labelPeerEmail);
            this.groupBox4.Location = new System.Drawing.Point(15, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 105);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // comboBoxAccounts
            // 
            this.comboBoxAccounts.FormattingEnabled = true;
            this.comboBoxAccounts.Location = new System.Drawing.Point(126, 23);
            this.comboBoxAccounts.Name = "comboBoxAccounts";
            this.comboBoxAccounts.Size = new System.Drawing.Size(532, 23);
            this.comboBoxAccounts.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "My accounts:";
            // 
            // textBoxPeerEmail
            // 
            this.textBoxPeerEmail.Location = new System.Drawing.Point(264, 59);
            this.textBoxPeerEmail.Name = "textBoxPeerEmail";
            this.textBoxPeerEmail.Size = new System.Drawing.Size(394, 25);
            this.textBoxPeerEmail.TabIndex = 3;
            // 
            // labelPeerEmail
            // 
            this.labelPeerEmail.AutoSize = true;
            this.labelPeerEmail.Location = new System.Drawing.Point(16, 63);
            this.labelPeerEmail.Name = "labelPeerEmail";
            this.labelPeerEmail.Size = new System.Drawing.Size(239, 15);
            this.labelPeerEmail.TabIndex = 2;
            this.labelPeerEmail.Text = "Email address to be verified:";
            // 
            // buttonSendResponse
            // 
            this.buttonSendResponse.Enabled = false;
            this.buttonSendResponse.Location = new System.Drawing.Point(524, 275);
            this.buttonSendResponse.Name = "buttonSendResponse";
            this.buttonSendResponse.Size = new System.Drawing.Size(140, 28);
            this.buttonSendResponse.TabIndex = 13;
            this.buttonSendResponse.Text = "Send";
            this.buttonSendResponse.UseVisualStyleBackColor = true;
            this.buttonSendResponse.Click += new System.EventHandler(this.buttonSendResponse_Click);
            // 
            // ManualVerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 482);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManualVerifyForm";
            this.Text = "Manual email address verification";
            this.Load += new System.EventHandler(this.ManualVerifyForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxChallengeGenerated;
        private System.Windows.Forms.Button buttonGenChallenge;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxResponseReceived;
        private System.Windows.Forms.Button buttonVerifyResponse;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxChallengeReceived;
        private System.Windows.Forms.Button buttonGenResponse;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxPeerEmail;
        private System.Windows.Forms.Label labelPeerEmail;
        private System.Windows.Forms.ComboBox comboBoxAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxResponseGenerated;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxChallengeSend;
        private System.Windows.Forms.Button buttonSendResponse;
    }
}