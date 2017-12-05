namespace plugin_nns
{
    partial class nnsTransfer
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
            this.txtNNSin = new System.Windows.Forms.TextBox();
            this.labAddrIn = new System.Windows.Forms.Label();
            this.comAsset = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.comAddrOut = new System.Windows.Forms.ComboBox();
            this.butTransfer = new System.Windows.Forms.Button();
            this.labBalance = new System.Windows.Forms.Label();
            this.linkTXID = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtNNSin
            // 
            this.txtNNSin.Location = new System.Drawing.Point(31, 25);
            this.txtNNSin.Name = "txtNNSin";
            this.txtNNSin.Size = new System.Drawing.Size(417, 21);
            this.txtNNSin.TabIndex = 0;
            this.txtNNSin.TextChanged += new System.EventHandler(this.txtNNSin_TextChanged);
            // 
            // labAddrIn
            // 
            this.labAddrIn.AutoSize = true;
            this.labAddrIn.Location = new System.Drawing.Point(29, 58);
            this.labAddrIn.Name = "labAddrIn";
            this.labAddrIn.Size = new System.Drawing.Size(29, 12);
            this.labAddrIn.TabIndex = 1;
            this.labAddrIn.Text = "addr";
            // 
            // comAsset
            // 
            this.comAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comAsset.Enabled = false;
            this.comAsset.FormattingEnabled = true;
            this.comAsset.Items.AddRange(new object[] {
            "NEO",
            "GAS"});
            this.comAsset.Location = new System.Drawing.Point(131, 107);
            this.comAsset.Name = "comAsset";
            this.comAsset.Size = new System.Drawing.Size(83, 20);
            this.comAsset.TabIndex = 2;
            this.comAsset.SelectedIndexChanged += new System.EventHandler(this.comAsset_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(31, 150);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(213, 21);
            this.txtAmount.TabIndex = 3;
            // 
            // comAddrOut
            // 
            this.comAddrOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comAddrOut.FormattingEnabled = true;
            this.comAddrOut.Location = new System.Drawing.Point(31, 84);
            this.comAddrOut.Name = "comAddrOut";
            this.comAddrOut.Size = new System.Drawing.Size(417, 20);
            this.comAddrOut.TabIndex = 4;
            // 
            // butTransfer
            // 
            this.butTransfer.Location = new System.Drawing.Point(31, 190);
            this.butTransfer.Name = "butTransfer";
            this.butTransfer.Size = new System.Drawing.Size(75, 23);
            this.butTransfer.TabIndex = 5;
            this.butTransfer.Text = "执行转账";
            this.butTransfer.UseVisualStyleBackColor = true;
            this.butTransfer.Click += new System.EventHandler(this.butTransfer_Click);
            // 
            // labBalance
            // 
            this.labBalance.AutoSize = true;
            this.labBalance.Location = new System.Drawing.Point(31, 110);
            this.labBalance.Name = "labBalance";
            this.labBalance.Size = new System.Drawing.Size(47, 12);
            this.labBalance.TabIndex = 6;
            this.labBalance.Text = "balance";
            // 
            // linkTXID
            // 
            this.linkTXID.AutoSize = true;
            this.linkTXID.Location = new System.Drawing.Point(31, 239);
            this.linkTXID.Name = "linkTXID";
            this.linkTXID.Size = new System.Drawing.Size(47, 12);
            this.linkTXID.TabIndex = 7;
            this.linkTXID.TabStop = true;
            this.linkTXID.Text = "TXID:0x\r\n";
            this.linkTXID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTXID_LinkClicked);
            // 
            // nnsTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 413);
            this.Controls.Add(this.linkTXID);
            this.Controls.Add(this.labBalance);
            this.Controls.Add(this.butTransfer);
            this.Controls.Add(this.comAddrOut);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.comAsset);
            this.Controls.Add(this.labAddrIn);
            this.Controls.Add(this.txtNNSin);
            this.Name = "nnsTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nns域名转账";
            this.Load += new System.EventHandler(this.nnsTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNNSin;
        private System.Windows.Forms.Label labAddrIn;
        private System.Windows.Forms.ComboBox comAsset;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox comAddrOut;
        private System.Windows.Forms.Button butTransfer;
        private System.Windows.Forms.Label labBalance;
        private System.Windows.Forms.LinkLabel linkTXID;
    }
}