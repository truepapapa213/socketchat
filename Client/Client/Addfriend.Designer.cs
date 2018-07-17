namespace Client
{
    partial class Addfriend
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
            this.tb_toUID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_mustate = new System.Windows.Forms.Label();
            this.tb_GID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_mugroup = new System.Windows.Forms.ComboBox();
            this.bt_musend = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_toUID
            // 
            this.tb_toUID.Location = new System.Drawing.Point(98, 38);
            this.tb_toUID.Name = "tb_toUID";
            this.tb_toUID.Size = new System.Drawing.Size(132, 21);
            this.tb_toUID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入想添加的好友UID:";
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(137, 23);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(0, 12);
            this.lb_state.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "想加入的分组：";
            // 
            // cb_group
            // 
            this.cb_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Location = new System.Drawing.Point(98, 92);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(132, 20);
            this.cb_group.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(155, 141);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "提交";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 218);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lb_state);
            this.tabPage1.Controls.Add(this.btn_send);
            this.tabPage1.Controls.Add(this.tb_toUID);
            this.tabPage1.Controls.Add(this.cb_group);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(278, 192);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "添加好友";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bt_musend);
            this.tabPage2.Controls.Add(this.cb_mugroup);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tb_GID);
            this.tabPage2.Controls.Add(this.lb_mustate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(278, 192);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "添加群组";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "输入想加入的群组ID:";
            // 
            // lb_mustate
            // 
            this.lb_mustate.AutoSize = true;
            this.lb_mustate.Location = new System.Drawing.Point(126, 22);
            this.lb_mustate.Name = "lb_mustate";
            this.lb_mustate.Size = new System.Drawing.Size(0, 12);
            this.lb_mustate.TabIndex = 1;
            // 
            // tb_GID
            // 
            this.tb_GID.Location = new System.Drawing.Point(98, 37);
            this.tb_GID.Name = "tb_GID";
            this.tb_GID.Size = new System.Drawing.Size(133, 21);
            this.tb_GID.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "想加入的分组:";
            // 
            // cb_mugroup
            // 
            this.cb_mugroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mugroup.FormattingEnabled = true;
            this.cb_mugroup.Location = new System.Drawing.Point(98, 95);
            this.cb_mugroup.Name = "cb_mugroup";
            this.cb_mugroup.Size = new System.Drawing.Size(133, 20);
            this.cb_mugroup.TabIndex = 4;
            // 
            // bt_musend
            // 
            this.bt_musend.Location = new System.Drawing.Point(156, 139);
            this.bt_musend.Name = "bt_musend";
            this.bt_musend.Size = new System.Drawing.Size(75, 23);
            this.bt_musend.TabIndex = 5;
            this.bt_musend.Text = "提交";
            this.bt_musend.UseVisualStyleBackColor = true;
            this.bt_musend.Click += new System.EventHandler(this.bt_musend_Click);
            // 
            // Addfriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 247);
            this.Controls.Add(this.tabControl1);
            this.Name = "Addfriend";
            this.Text = "Addfriend";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Addfriend_FormClosed);
            this.Load += new System.EventHandler(this.Addfriend_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_toUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bt_musend;
        private System.Windows.Forms.ComboBox cb_mugroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_GID;
        private System.Windows.Forms.Label lb_mustate;
        private System.Windows.Forms.Label label3;
    }
}