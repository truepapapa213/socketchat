namespace Client
{
    partial class Friendreq
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
            this.lv_frdreq = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_frdputreq = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lv_mureq = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lv_putmureq = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_frdreq
            // 
            this.lv_frdreq.Location = new System.Drawing.Point(4, 3);
            this.lv_frdreq.Name = "lv_frdreq";
            this.lv_frdreq.Size = new System.Drawing.Size(229, 322);
            this.lv_frdreq.TabIndex = 0;
            this.lv_frdreq.UseCompatibleStateImageBehavior = false;
            this.lv_frdreq.View = System.Windows.Forms.View.Details;
            this.lv_frdreq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_frdreq_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(246, 375);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_frdreq);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(238, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收到的好友请求";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_frdputreq);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(238, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发出的好友请求";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_frdputreq
            // 
            this.lv_frdputreq.Location = new System.Drawing.Point(0, 0);
            this.lv_frdputreq.Name = "lv_frdputreq";
            this.lv_frdputreq.Size = new System.Drawing.Size(235, 328);
            this.lv_frdputreq.TabIndex = 0;
            this.lv_frdputreq.UseCompatibleStateImageBehavior = false;
            this.lv_frdputreq.View = System.Windows.Forms.View.Details;
            this.lv_frdputreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_frdputreq_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lv_mureq);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(238, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "入群申请";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lv_mureq
            // 
            this.lv_mureq.Location = new System.Drawing.Point(4, 4);
            this.lv_mureq.Name = "lv_mureq";
            this.lv_mureq.Size = new System.Drawing.Size(231, 324);
            this.lv_mureq.TabIndex = 0;
            this.lv_mureq.UseCompatibleStateImageBehavior = false;
            this.lv_mureq.View = System.Windows.Forms.View.Details;
            this.lv_mureq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_mureq_MouseDoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lv_putmureq);
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(238, 331);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "发出的入群申请";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lv_putmureq
            // 
            this.lv_putmureq.Location = new System.Drawing.Point(4, 4);
            this.lv_putmureq.Name = "lv_putmureq";
            this.lv_putmureq.Size = new System.Drawing.Size(231, 324);
            this.lv_putmureq.TabIndex = 0;
            this.lv_putmureq.UseCompatibleStateImageBehavior = false;
            this.lv_putmureq.View = System.Windows.Forms.View.Details;
            this.lv_putmureq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_putmureq_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            this.CancelToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.CancelToolStripMenuItem.Text = "取消请求";
            this.CancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelmuToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            // 
            // CancelmuToolStripMenuItem
            // 
            this.CancelmuToolStripMenuItem.Name = "CancelmuToolStripMenuItem";
            this.CancelmuToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.CancelmuToolStripMenuItem.Text = "取消请求";
            this.CancelmuToolStripMenuItem.Click += new System.EventHandler(this.CancelmuToolStripMenuItem_Click);
            // 
            // Friendreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 408);
            this.Controls.Add(this.tabControl1);
            this.Name = "Friendreq";
            this.Text = "Friendreq";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Friendreq_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Friendreq_FormClosed);
            this.Load += new System.EventHandler(this.Friendreq_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_frdreq;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView lv_frdputreq;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CancelToolStripMenuItem;
        private System.Windows.Forms.ListView lv_mureq;
        private System.Windows.Forms.ListView lv_putmureq;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem CancelmuToolStripMenuItem;
    }
}