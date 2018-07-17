namespace Client
{
    partial class Userstate
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
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_UID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sign = new System.Windows.Forms.TextBox();
            this.bt_change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(82, 58);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(139, 21);
            this.tb_username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "UID:";
            // 
            // lb_UID
            // 
            this.lb_UID.AutoSize = true;
            this.lb_UID.Location = new System.Drawing.Point(80, 32);
            this.lb_UID.Name = "lb_UID";
            this.lb_UID.Size = new System.Drawing.Size(41, 12);
            this.lb_UID.TabIndex = 2;
            this.lb_UID.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "个人简介:";
            // 
            // tb_sign
            // 
            this.tb_sign.Location = new System.Drawing.Point(52, 114);
            this.tb_sign.Multiline = true;
            this.tb_sign.Name = "tb_sign";
            this.tb_sign.Size = new System.Drawing.Size(169, 88);
            this.tb_sign.TabIndex = 5;
            // 
            // bt_change
            // 
            this.bt_change.Location = new System.Drawing.Point(146, 218);
            this.bt_change.Name = "bt_change";
            this.bt_change.Size = new System.Drawing.Size(75, 23);
            this.bt_change.TabIndex = 6;
            this.bt_change.Text = "修改";
            this.bt_change.UseVisualStyleBackColor = true;
            this.bt_change.Click += new System.EventHandler(this.bt_change_Click);
            // 
            // Userstate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 271);
            this.Controls.Add(this.bt_change);
            this.Controls.Add(this.tb_sign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_UID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_username);
            this.Name = "Userstate";
            this.Text = "Userstate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Userstate_FormClosed);
            this.Load += new System.EventHandler(this.Userstate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_UID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_sign;
        private System.Windows.Forms.Button bt_change;
    }
}