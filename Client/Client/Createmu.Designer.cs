namespace Client
{
    partial class Createmu
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
            this.tb_muname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_musign = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "群名:";
            // 
            // tb_muname
            // 
            this.tb_muname.Location = new System.Drawing.Point(72, 33);
            this.tb_muname.Name = "tb_muname";
            this.tb_muname.Size = new System.Drawing.Size(138, 21);
            this.tb_muname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "群简介:";
            // 
            // tb_musign
            // 
            this.tb_musign.Location = new System.Drawing.Point(61, 98);
            this.tb_musign.Multiline = true;
            this.tb_musign.Name = "tb_musign";
            this.tb_musign.Size = new System.Drawing.Size(149, 69);
            this.tb_musign.TabIndex = 3;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(45, 200);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 4;
            this.bt_send.Text = "提交";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(155, 200);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 5;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(189, 181);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(0, 12);
            this.lb_state.TabIndex = 6;
            // 
            // Createmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_musign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_muname);
            this.Controls.Add(this.label1);
            this.Name = "Createmu";
            this.Text = "Createmu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_muname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_musign;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label lb_state;
    }
}