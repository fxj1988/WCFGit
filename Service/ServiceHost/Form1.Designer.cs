namespace ServiceHost
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenHost = new System.Windows.Forms.Button();
            this.btnTestWriteIn = new System.Windows.Forms.Button();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenHost
            // 
            this.btnOpenHost.Location = new System.Drawing.Point(21, 35);
            this.btnOpenHost.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenHost.Name = "btnOpenHost";
            this.btnOpenHost.Size = new System.Drawing.Size(141, 83);
            this.btnOpenHost.TabIndex = 0;
            this.btnOpenHost.Text = "启动服务";
            this.btnOpenHost.UseVisualStyleBackColor = true;
            this.btnOpenHost.Click += new System.EventHandler(this.btnOpenHost_Click);
            // 
            // btnTestWriteIn
            // 
            this.btnTestWriteIn.Location = new System.Drawing.Point(177, 35);
            this.btnTestWriteIn.Name = "btnTestWriteIn";
            this.btnTestWriteIn.Size = new System.Drawing.Size(118, 23);
            this.btnTestWriteIn.TabIndex = 1;
            this.btnTestWriteIn.Text = "窗体间测试";
            this.btnTestWriteIn.UseVisualStyleBackColor = true;
            this.btnTestWriteIn.Click += new System.EventHandler(this.btnTestWriteIn_Click);
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(177, 77);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(118, 21);
            this.txtOrder.TabIndex = 2;
            this.txtOrder.Text = "写入测试";
            this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 259);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.btnTestWriteIn);
            this.Controls.Add(this.btnOpenHost);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenHost;
        private System.Windows.Forms.Button btnTestWriteIn;
        private System.Windows.Forms.TextBox txtOrder;
    }
}

