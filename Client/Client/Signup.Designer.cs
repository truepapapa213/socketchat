namespace Client
{
    partial class Signup
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_signup = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.tb_account = new System.Windows.Forms.TextBox();
            this.tb_passwd = new System.Windows.Forms.TextBox();
            this.tb_passwdrpt = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "重复密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "昵称：";
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(50, 191);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(75, 23);
            this.btn_signup.TabIndex = 4;
            this.btn_signup.Text = "注册";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(169, 191);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "返回";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // tb_account
            // 
            this.tb_account.Location = new System.Drawing.Point(103, 57);
            this.tb_account.Name = "tb_account";
            this.tb_account.Size = new System.Drawing.Size(150, 21);
            this.tb_account.TabIndex = 6;
            // 
            // tb_passwd
            // 
            this.tb_passwd.Location = new System.Drawing.Point(103, 84);
            this.tb_passwd.Name = "tb_passwd";
            this.tb_passwd.Size = new System.Drawing.Size(150, 21);
            this.tb_passwd.TabIndex = 7;
            // 
            // tb_passwdrpt
            // 
            this.tb_passwdrpt.Location = new System.Drawing.Point(103, 112);
            this.tb_passwdrpt.Name = "tb_passwdrpt";
            this.tb_passwdrpt.Size = new System.Drawing.Size(150, 21);
            this.tb_passwdrpt.TabIndex = 8;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(103, 140);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(150, 21);
            this.tb_username.TabIndex = 9;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(169, 173);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(0, 12);
            this.lb_status.TabIndex = 10;
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 286);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.tb_passwdrpt);
            this.Controls.Add(this.tb_passwd);
            this.Controls.Add(this.tb_account);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Signup";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_signup;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox tb_account;
        private System.Windows.Forms.TextBox tb_passwd;
        private System.Windows.Forms.TextBox tb_passwdrpt;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label lb_status;
    }
}