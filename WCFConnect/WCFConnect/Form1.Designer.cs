namespace WCFConnect
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
            this.btnConWcf = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUserInfo = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnEditUserInfo = new System.Windows.Forms.Button();
            this.btnCirclyGetUserInfo = new System.Windows.Forms.Button();
            this.labResult = new System.Windows.Forms.Label();
            this.labHostState = new System.Windows.Forms.Label();
            this.labOper = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConWcf
            // 
            this.btnConWcf.Location = new System.Drawing.Point(12, 12);
            this.btnConWcf.Name = "btnConWcf";
            this.btnConWcf.Size = new System.Drawing.Size(75, 23);
            this.btnConWcf.TabIndex = 0;
            this.btnConWcf.Text = "所有用户";
            this.btnConWcf.UseVisualStyleBackColor = true;
            this.btnConWcf.Click += new System.EventHandler(this.btnConWcf_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(437, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(392, 597);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Location = new System.Drawing.Point(93, 13);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Size = new System.Drawing.Size(75, 23);
            this.btnUserInfo.TabIndex = 3;
            this.btnUserInfo.Text = "根据ID获得用户信息";
            this.btnUserInfo.UseVisualStyleBackColor = true;
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(169, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 21);
            this.txtID.TabIndex = 4;
            this.txtID.Text = "1";
            // 
            // btnEditUserInfo
            // 
            this.btnEditUserInfo.Location = new System.Drawing.Point(275, 12);
            this.btnEditUserInfo.Name = "btnEditUserInfo";
            this.btnEditUserInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEditUserInfo.TabIndex = 5;
            this.btnEditUserInfo.Text = "修改";
            this.btnEditUserInfo.UseVisualStyleBackColor = true;
            this.btnEditUserInfo.Click += new System.EventHandler(this.btnEditUserInfo_Click);
            // 
            // btnCirclyGetUserInfo
            // 
            this.btnCirclyGetUserInfo.Location = new System.Drawing.Point(356, 11);
            this.btnCirclyGetUserInfo.Name = "btnCirclyGetUserInfo";
            this.btnCirclyGetUserInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCirclyGetUserInfo.TabIndex = 6;
            this.btnCirclyGetUserInfo.Text = "自动随机获取";
            this.btnCirclyGetUserInfo.UseVisualStyleBackColor = true;
            this.btnCirclyGetUserInfo.Click += new System.EventHandler(this.btnCirclyGetUserInfo_Click);
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(13, 72);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(0, 12);
            this.labResult.TabIndex = 9;
            // 
            // labHostState
            // 
            this.labHostState.AutoSize = true;
            this.labHostState.Font = new System.Drawing.Font("华文琥珀", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHostState.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labHostState.Location = new System.Drawing.Point(10, 42);
            this.labHostState.Name = "labHostState";
            this.labHostState.Size = new System.Drawing.Size(158, 30);
            this.labHostState.TabIndex = 11;
            this.labHostState.Text = "服务端状态";
            this.labHostState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labOper
            // 
            this.labOper.AutoSize = true;
            this.labOper.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOper.ForeColor = System.Drawing.Color.Red;
            this.labOper.Location = new System.Drawing.Point(214, 39);
            this.labOper.Name = "labOper";
            this.labOper.Size = new System.Drawing.Size(182, 31);
            this.labOper.TabIndex = 12;
            this.labOper.Text = "本机未执行操作";
          
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 636);
            this.Controls.Add(this.labOper);
            this.Controls.Add(this.labHostState);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.btnCirclyGetUserInfo);
            this.Controls.Add(this.btnEditUserInfo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnUserInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnConWcf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConWcf;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUserInfo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnEditUserInfo;
        private System.Windows.Forms.Button btnCirclyGetUserInfo;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Label labHostState;
        private System.Windows.Forms.Label labOper;
    }
}

