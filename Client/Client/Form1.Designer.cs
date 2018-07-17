namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Send = new System.Windows.Forms.Button();
            this.tb_SendMsg = new System.Windows.Forms.TextBox();
            this.rtb_ShowMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(197, 219);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 0;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // tb_SendMsg
            // 
            this.tb_SendMsg.Location = new System.Drawing.Point(91, 219);
            this.tb_SendMsg.Name = "tb_SendMsg";
            this.tb_SendMsg.Size = new System.Drawing.Size(100, 21);
            this.tb_SendMsg.TabIndex = 1;
            // 
            // rtb_ShowMsg
            // 
            this.rtb_ShowMsg.Location = new System.Drawing.Point(91, 12);
            this.rtb_ShowMsg.Name = "rtb_ShowMsg";
            this.rtb_ShowMsg.Size = new System.Drawing.Size(181, 201);
            this.rtb_ShowMsg.TabIndex = 2;
            this.rtb_ShowMsg.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rtb_ShowMsg);
            this.Controls.Add(this.tb_SendMsg);
            this.Controls.Add(this.btn_Send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox tb_SendMsg;
        private System.Windows.Forms.RichTextBox rtb_ShowMsg;
    }
}

