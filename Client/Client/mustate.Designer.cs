namespace Client
{
    partial class mustate
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
            this.tb_grpname = new System.Windows.Forms.TextBox();
            this.lb_GID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_grpsign = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "GID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "群名称:";
            // 
            // tb_grpname
            // 
            this.tb_grpname.Location = new System.Drawing.Point(91, 61);
            this.tb_grpname.Name = "tb_grpname";
            this.tb_grpname.Size = new System.Drawing.Size(132, 21);
            this.tb_grpname.TabIndex = 4;
            // 
            // lb_GID
            // 
            this.lb_GID.AutoSize = true;
            this.lb_GID.Location = new System.Drawing.Point(89, 34);
            this.lb_GID.Name = "lb_GID";
            this.lb_GID.Size = new System.Drawing.Size(0, 12);
            this.lb_GID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "群简介:";
            // 
            // tb_grpsign
            // 
            this.tb_grpsign.Location = new System.Drawing.Point(51, 121);
            this.tb_grpsign.Multiline = true;
            this.tb_grpsign.Name = "tb_grpsign";
            this.tb_grpsign.Size = new System.Drawing.Size(172, 77);
            this.tb_grpsign.TabIndex = 8;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(148, 211);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 9;
            this.bt_send.Text = "修改";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // mustate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 255);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_grpsign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_GID);
            this.Controls.Add(this.tb_grpname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "mustate";
            this.Text = "mustate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mustate_FormClosed);
            this.Load += new System.EventHandler(this.mustate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_grpname;
        private System.Windows.Forms.Label lb_GID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_grpsign;
        private System.Windows.Forms.Button bt_send;
    }
}