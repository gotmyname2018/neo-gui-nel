namespace plugin_nns
{
    partial class nnsResolverAddr
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
            this.butQuery = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtTXID = new System.Windows.Forms.TextBox();
            this.butAlter = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butQuery
            // 
            this.butQuery.Location = new System.Drawing.Point(38, 59);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(75, 23);
            this.butQuery.TabIndex = 0;
            this.butQuery.Text = "查询";
            this.butQuery.UseVisualStyleBackColor = true;
            this.butQuery.Click += new System.EventHandler(this.butQuery_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(525, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(38, 89);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(525, 21);
            this.txtAddr.TabIndex = 2;
            // 
            // txtTXID
            // 
            this.txtTXID.Location = new System.Drawing.Point(38, 329);
            this.txtTXID.Name = "txtTXID";
            this.txtTXID.Size = new System.Drawing.Size(525, 21);
            this.txtTXID.TabIndex = 3;
            // 
            // butAlter
            // 
            this.butAlter.Location = new System.Drawing.Point(119, 59);
            this.butAlter.Name = "butAlter";
            this.butAlter.Size = new System.Drawing.Size(75, 23);
            this.butAlter.TabIndex = 4;
            this.butAlter.Text = "修改";
            this.butAlter.UseVisualStyleBackColor = true;
            this.butAlter.Click += new System.EventHandler(this.butAlter_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(201, 58);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 5;
            this.butDelete.Text = "删除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // nnsResolverAddr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 367);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butAlter);
            this.Controls.Add(this.txtTXID);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.butQuery);
            this.Name = "nnsResolverAddr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nns域名解析器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butQuery;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtTXID;
        private System.Windows.Forms.Button butAlter;
        private System.Windows.Forms.Button butDelete;
    }
}