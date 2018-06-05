namespace 异步socket_wcf
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
            this.btnStartWcf = new System.Windows.Forms.Button();
            this.btnStopWcf = new System.Windows.Forms.Button();
            this.btnStartSocket = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartWcf
            // 
            this.btnStartWcf.Location = new System.Drawing.Point(178, 29);
            this.btnStartWcf.Name = "btnStartWcf";
            this.btnStartWcf.Size = new System.Drawing.Size(75, 23);
            this.btnStartWcf.TabIndex = 0;
            this.btnStartWcf.Text = "开启wcf";
            this.btnStartWcf.UseVisualStyleBackColor = true;
            this.btnStartWcf.Click += new System.EventHandler(this.btnStartWcf_Click);
            // 
            // btnStopWcf
            // 
            this.btnStopWcf.Location = new System.Drawing.Point(317, 29);
            this.btnStopWcf.Name = "btnStopWcf";
            this.btnStopWcf.Size = new System.Drawing.Size(75, 23);
            this.btnStopWcf.TabIndex = 1;
            this.btnStopWcf.Text = "关闭wcf";
            this.btnStopWcf.UseVisualStyleBackColor = true;
            this.btnStopWcf.Click += new System.EventHandler(this.btnStopWcf_Click);
            // 
            // btnStartSocket
            // 
            this.btnStartSocket.Location = new System.Drawing.Point(178, 89);
            this.btnStartSocket.Name = "btnStartSocket";
            this.btnStartSocket.Size = new System.Drawing.Size(75, 23);
            this.btnStartSocket.TabIndex = 2;
            this.btnStartSocket.Text = "开启socket";
            this.btnStartSocket.UseVisualStyleBackColor = true;
            this.btnStartSocket.Click += new System.EventHandler(this.btnStartSocket_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(473, 29);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(300, 263);
            this.txtMsg.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnStartSocket);
            this.Controls.Add(this.btnStopWcf);
            this.Controls.Add(this.btnStartWcf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartWcf;
        private System.Windows.Forms.Button btnStopWcf;
        private System.Windows.Forms.Button btnStartSocket;
        private System.Windows.Forms.TextBox txtMsg;
    }
}

