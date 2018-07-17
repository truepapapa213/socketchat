namespace Client
{
    partial class Friendreqitem
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
            this.cb_groups = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.bt_refuse = new System.Windows.Forms.Button();
            this.bt_accept = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_groups
            // 
            this.cb_groups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_groups.FormattingEnabled = true;
            this.cb_groups.Location = new System.Drawing.Point(119, 90);
            this.cb_groups.Name = "cb_groups";
            this.cb_groups.Size = new System.Drawing.Size(121, 20);
            this.cb_groups.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择分组";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户ID";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(119, 46);
            this.tb_username.Name = "tb_username";
            this.tb_username.ReadOnly = true;
            this.tb_username.Size = new System.Drawing.Size(121, 21);
            this.tb_username.TabIndex = 3;
            // 
            // bt_refuse
            // 
            this.bt_refuse.Location = new System.Drawing.Point(165, 159);
            this.bt_refuse.Name = "bt_refuse";
            this.bt_refuse.Size = new System.Drawing.Size(75, 23);
            this.bt_refuse.TabIndex = 4;
            this.bt_refuse.Text = "拒绝";
            this.bt_refuse.UseVisualStyleBackColor = true;
            this.bt_refuse.Click += new System.EventHandler(this.bt_refuse_Click);
            // 
            // bt_accept
            // 
            this.bt_accept.Location = new System.Drawing.Point(43, 159);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(75, 23);
            this.bt_accept.TabIndex = 5;
            this.bt_accept.Text = "同意";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(163, 127);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(0, 12);
            this.lb_state.TabIndex = 6;
            // 
            // Friendreqitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 210);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.bt_refuse);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_groups);
            this.Name = "Friendreqitem";
            this.Text = "Friendreqitem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Friendreqitem_FormClosed);
            this.Load += new System.EventHandler(this.Friendreqitem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_groups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Button bt_refuse;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Label lb_state;
    }
}