namespace Client
{
    partial class mutualTalk
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
            this.rtb_ShowMsg = new System.Windows.Forms.RichTextBox();
            this.tb_SendMsg = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lv_members = new System.Windows.Forms.ListView();
            this.cm_member = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_rm = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_auth = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_cg = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_rmauth = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_member.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_ShowMsg
            // 
            this.rtb_ShowMsg.Location = new System.Drawing.Point(12, 12);
            this.rtb_ShowMsg.Name = "rtb_ShowMsg";
            this.rtb_ShowMsg.ReadOnly = true;
            this.rtb_ShowMsg.Size = new System.Drawing.Size(466, 416);
            this.rtb_ShowMsg.TabIndex = 0;
            this.rtb_ShowMsg.Text = "";
            // 
            // tb_SendMsg
            // 
            this.tb_SendMsg.Location = new System.Drawing.Point(13, 458);
            this.tb_SendMsg.Multiline = true;
            this.tb_SendMsg.Name = "tb_SendMsg";
            this.tb_SendMsg.Size = new System.Drawing.Size(465, 95);
            this.tb_SendMsg.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(277, 569);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(391, 569);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // lv_members
            // 
            this.lv_members.Location = new System.Drawing.Point(498, 12);
            this.lv_members.Name = "lv_members";
            this.lv_members.Size = new System.Drawing.Size(134, 541);
            this.lv_members.TabIndex = 4;
            this.lv_members.UseCompatibleStateImageBehavior = false;
            this.lv_members.View = System.Windows.Forms.View.Details;
            this.lv_members.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_members_MouseClick);
            // 
            // cm_member
            // 
            this.cm_member.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_rm,
            this.ts_auth,
            this.ts_cg,
            this.ts_rmauth});
            this.cm_member.Name = "cm_member";
            this.cm_member.Size = new System.Drawing.Size(153, 114);
            // 
            // ts_rm
            // 
            this.ts_rm.Name = "ts_rm";
            this.ts_rm.Size = new System.Drawing.Size(152, 22);
            this.ts_rm.Text = "移出群聊";
            this.ts_rm.Click += new System.EventHandler(this.ts_rm_Click);
            // 
            // ts_auth
            // 
            this.ts_auth.Name = "ts_auth";
            this.ts_auth.Size = new System.Drawing.Size(152, 22);
            this.ts_auth.Text = "设置为管理员";
            this.ts_auth.Click += new System.EventHandler(this.ts_auth_Click);
            // 
            // ts_cg
            // 
            this.ts_cg.Name = "ts_cg";
            this.ts_cg.Size = new System.Drawing.Size(152, 22);
            this.ts_cg.Text = "转让群主";
            this.ts_cg.Click += new System.EventHandler(this.ts_cg_Click);
            // 
            // ts_rmauth
            // 
            this.ts_rmauth.Name = "ts_rmauth";
            this.ts_rmauth.Size = new System.Drawing.Size(152, 22);
            this.ts_rmauth.Text = "取消管理员";
            this.ts_rmauth.Click += new System.EventHandler(this.ts_rmauth_Click);
            // 
            // mutualTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 604);
            this.Controls.Add(this.lv_members);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.tb_SendMsg);
            this.Controls.Add(this.rtb_ShowMsg);
            this.Name = "mutualTalk";
            this.Text = "mutualTalk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mutualTalk_FormClosed);
            this.Load += new System.EventHandler(this.mutualTalk_Load);
            this.cm_member.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_ShowMsg;
        private System.Windows.Forms.TextBox tb_SendMsg;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ListView lv_members;
        private System.Windows.Forms.ContextMenuStrip cm_member;
        private System.Windows.Forms.ToolStripMenuItem ts_rm;
        private System.Windows.Forms.ToolStripMenuItem ts_auth;
        private System.Windows.Forms.ToolStripMenuItem ts_cg;
        private System.Windows.Forms.ToolStripMenuItem ts_rmauth;
    }
}