namespace Client
{
    partial class mugroupcg
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
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "修改分组至:";
            // 
            // cb_group
            // 
            this.cb_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Location = new System.Drawing.Point(89, 30);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(106, 20);
            this.cb_group.TabIndex = 1;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(37, 62);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 2;
            this.bt_send.Text = "提交";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(132, 62);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 3;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(120, 12);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(0, 12);
            this.lb_state.TabIndex = 4;
            // 
            // mugroupcg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 97);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.cb_group);
            this.Controls.Add(this.label1);
            this.Name = "mugroupcg";
            this.Text = "mugroupcg";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mugroupcg_FormClosed);
            this.Load += new System.EventHandler(this.mugroupcg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label lb_state;
    }
}