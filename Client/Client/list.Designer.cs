namespace Client
{
    partial class list
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
            this.components = new System.ComponentModel.Container();
            this.lv_friends = new System.Windows.Forms.ListView();
            this.frdreq_btn = new System.Windows.Forms.Button();
            this.addfrd_btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_group = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb_UID = new System.Windows.Forms.Label();
            this.lb_Username = new System.Windows.Forms.Label();
            this.cm_frd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.frddelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frdgrpcgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frdstateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_grp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.crtmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cgmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mustateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cm_frd.SuspendLayout();
            this.cm_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_friends
            // 
            this.lv_friends.Location = new System.Drawing.Point(0, 0);
            this.lv_friends.Name = "lv_friends";
            this.lv_friends.Size = new System.Drawing.Size(214, 520);
            this.lv_friends.TabIndex = 0;
            this.lv_friends.UseCompatibleStateImageBehavior = false;
            this.lv_friends.View = System.Windows.Forms.View.Details;
            this.lv_friends.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_friends_MouseClick);
            this.lv_friends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_friends_MouseDoubleClick);
            // 
            // frdreq_btn
            // 
            this.frdreq_btn.Location = new System.Drawing.Point(155, 606);
            this.frdreq_btn.Name = "frdreq_btn";
            this.frdreq_btn.Size = new System.Drawing.Size(75, 23);
            this.frdreq_btn.TabIndex = 1;
            this.frdreq_btn.Text = "好友请求";
            this.frdreq_btn.UseVisualStyleBackColor = true;
            this.frdreq_btn.Click += new System.EventHandler(this.frdreq_btn_Click);
            // 
            // addfrd_btn
            // 
            this.addfrd_btn.Location = new System.Drawing.Point(155, 635);
            this.addfrd_btn.Name = "addfrd_btn";
            this.addfrd_btn.Size = new System.Drawing.Size(75, 23);
            this.addfrd_btn.TabIndex = 2;
            this.addfrd_btn.Text = "添加好友";
            this.addfrd_btn.UseVisualStyleBackColor = true;
            this.addfrd_btn.Click += new System.EventHandler(this.addfrd_btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(222, 549);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_friends);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(214, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "好友";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_group);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(214, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_group
            // 
            this.lv_group.Location = new System.Drawing.Point(0, 0);
            this.lv_group.Name = "lv_group";
            this.lv_group.Size = new System.Drawing.Size(214, 520);
            this.lv_group.TabIndex = 0;
            this.lv_group.UseCompatibleStateImageBehavior = false;
            this.lv_group.View = System.Windows.Forms.View.Details;
            this.lv_group.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_group_MouseClick);
            this.lv_group.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_group_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "个人资料";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(16, 13);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(35, 12);
            this.lb1.TabIndex = 5;
            this.lb1.Text = "UID：";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(16, 33);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(41, 12);
            this.lb2.TabIndex = 6;
            this.lb2.Text = "昵称：";
            // 
            // lb_UID
            // 
            this.lb_UID.AutoSize = true;
            this.lb_UID.Location = new System.Drawing.Point(64, 13);
            this.lb_UID.Name = "lb_UID";
            this.lb_UID.Size = new System.Drawing.Size(41, 12);
            this.lb_UID.TabIndex = 7;
            this.lb_UID.Text = "label1";
            // 
            // lb_Username
            // 
            this.lb_Username.AutoSize = true;
            this.lb_Username.Location = new System.Drawing.Point(64, 33);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(41, 12);
            this.lb_Username.TabIndex = 8;
            this.lb_Username.Text = "label2";
            // 
            // cm_frd
            // 
            this.cm_frd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frddelToolStripMenuItem,
            this.frdgrpcgToolStripMenuItem,
            this.frdstateToolStripMenuItem});
            this.cm_frd.Name = "cm_frd";
            this.cm_frd.Size = new System.Drawing.Size(125, 70);
            // 
            // frddelToolStripMenuItem
            // 
            this.frddelToolStripMenuItem.Name = "frddelToolStripMenuItem";
            this.frddelToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.frddelToolStripMenuItem.Text = "删除好友";
            this.frddelToolStripMenuItem.Click += new System.EventHandler(this.frddelToolStripMenuItem_Click);
            // 
            // frdgrpcgToolStripMenuItem
            // 
            this.frdgrpcgToolStripMenuItem.Name = "frdgrpcgToolStripMenuItem";
            this.frdgrpcgToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.frdgrpcgToolStripMenuItem.Text = "修改分组";
            this.frdgrpcgToolStripMenuItem.Click += new System.EventHandler(this.frdgrpcgToolStripMenuItem_Click);
            // 
            // frdstateToolStripMenuItem
            // 
            this.frdstateToolStripMenuItem.Name = "frdstateToolStripMenuItem";
            this.frdstateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.frdstateToolStripMenuItem.Text = "查看资料";
            this.frdstateToolStripMenuItem.Click += new System.EventHandler(this.frdstateToolStripMenuItem_Click);
            // 
            // cm_grp
            // 
            this.cm_grp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crtmuToolStripMenuItem,
            this.cgmuToolStripMenuItem,
            this.exitmuToolStripMenuItem,
            this.delmuToolStripMenuItem,
            this.mustateToolStripMenuItem});
            this.cm_grp.Name = "cm_grp";
            this.cm_grp.Size = new System.Drawing.Size(153, 136);
            // 
            // crtmuToolStripMenuItem
            // 
            this.crtmuToolStripMenuItem.Name = "crtmuToolStripMenuItem";
            this.crtmuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.crtmuToolStripMenuItem.Text = "创建群组";
            this.crtmuToolStripMenuItem.Click += new System.EventHandler(this.crtmuToolStripMenuItem_Click);
            // 
            // cgmuToolStripMenuItem
            // 
            this.cgmuToolStripMenuItem.Name = "cgmuToolStripMenuItem";
            this.cgmuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cgmuToolStripMenuItem.Text = "修改分组";
            this.cgmuToolStripMenuItem.Click += new System.EventHandler(this.cgmuToolStripMenuItem_Click);
            // 
            // exitmuToolStripMenuItem
            // 
            this.exitmuToolStripMenuItem.Name = "exitmuToolStripMenuItem";
            this.exitmuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitmuToolStripMenuItem.Text = "退出群聊";
            this.exitmuToolStripMenuItem.Click += new System.EventHandler(this.exitmuToolStripMenuItem_Click);
            // 
            // delmuToolStripMenuItem
            // 
            this.delmuToolStripMenuItem.Name = "delmuToolStripMenuItem";
            this.delmuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.delmuToolStripMenuItem.Text = "解散群聊";
            this.delmuToolStripMenuItem.Click += new System.EventHandler(this.delmuToolStripMenuItem_Click);
            // 
            // mustateToolStripMenuItem
            // 
            this.mustateToolStripMenuItem.Name = "mustateToolStripMenuItem";
            this.mustateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mustateToolStripMenuItem.Text = "查看资料";
            this.mustateToolStripMenuItem.Click += new System.EventHandler(this.mustateToolStripMenuItem_Click);
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 670);
            this.Controls.Add(this.lb_Username);
            this.Controls.Add(this.lb_UID);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.addfrd_btn);
            this.Controls.Add(this.frdreq_btn);
            this.Name = "list";
            this.Text = "list";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.list_FormClosed);
            this.Load += new System.EventHandler(this.list_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.cm_frd.ResumeLayout(false);
            this.cm_grp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_friends;
        private System.Windows.Forms.Button frdreq_btn;
        private System.Windows.Forms.Button addfrd_btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_group;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb_UID;
        private System.Windows.Forms.Label lb_Username;
        private System.Windows.Forms.ContextMenuStrip cm_frd;
        private System.Windows.Forms.ToolStripMenuItem frddelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frdgrpcgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frdstateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cm_grp;
        private System.Windows.Forms.ToolStripMenuItem crtmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cgmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mustateToolStripMenuItem;
    }
}