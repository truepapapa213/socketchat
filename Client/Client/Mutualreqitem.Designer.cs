namespace Client
{
    partial class Mutualreqitem
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
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_mutualname = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_mutualname = new System.Windows.Forms.TextBox();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_refuse = new System.Windows.Forms.Button();
            this.bt_user = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Location = new System.Drawing.Point(33, 55);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(53, 12);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "用户ID：";
            // 
            // lb_mutualname
            // 
            this.lb_mutualname.AutoSize = true;
            this.lb_mutualname.Location = new System.Drawing.Point(33, 130);
            this.lb_mutualname.Name = "lb_mutualname";
            this.lb_mutualname.Size = new System.Drawing.Size(65, 12);
            this.lb_mutualname.TabIndex = 1;
            this.lb_mutualname.Text = "群组名称：";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(106, 52);
            this.tb_username.Name = "tb_username";
            this.tb_username.ReadOnly = true;
            this.tb_username.Size = new System.Drawing.Size(100, 21);
            this.tb_username.TabIndex = 2;
            // 
            // tb_mutualname
            // 
            this.tb_mutualname.Location = new System.Drawing.Point(106, 127);
            this.tb_mutualname.Name = "tb_mutualname";
            this.tb_mutualname.ReadOnly = true;
            this.tb_mutualname.Size = new System.Drawing.Size(100, 21);
            this.tb_mutualname.TabIndex = 3;
            // 
            // bt_accept
            // 
            this.bt_accept.Location = new System.Drawing.Point(53, 182);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(75, 23);
            this.bt_accept.TabIndex = 4;
            this.bt_accept.Text = "同意";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // bt_refuse
            // 
            this.bt_refuse.Location = new System.Drawing.Point(162, 182);
            this.bt_refuse.Name = "bt_refuse";
            this.bt_refuse.Size = new System.Drawing.Size(75, 23);
            this.bt_refuse.TabIndex = 5;
            this.bt_refuse.Text = "拒绝";
            this.bt_refuse.UseVisualStyleBackColor = true;
            this.bt_refuse.Click += new System.EventHandler(this.bt_refuse_Click);
            // 
            // bt_user
            // 
            this.bt_user.Location = new System.Drawing.Point(197, 88);
            this.bt_user.Name = "bt_user";
            this.bt_user.Size = new System.Drawing.Size(75, 23);
            this.bt_user.TabIndex = 6;
            this.bt_user.Text = "查看信息";
            this.bt_user.UseVisualStyleBackColor = true;
            // 
            // Mutualreqitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bt_user);
            this.Controls.Add(this.bt_refuse);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.tb_mutualname);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.lb_mutualname);
            this.Controls.Add(this.lb_username);
            this.Name = "Mutualreqitem";
            this.Text = "Mutualreqitem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mutualreqitem_FormClosed);
            this.Load += new System.EventHandler(this.Mutualreqitem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_mutualname;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_mutualname;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Button bt_refuse;
        private System.Windows.Forms.Button bt_user;
    }
}