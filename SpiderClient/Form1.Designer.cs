namespace SpiderClient
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
            this.lbUrl = new System.Windows.Forms.Label();
            this.txtBeginUrl = new System.Windows.Forms.TextBox();
            this.lbpath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(39, 36);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(53, 12);
            this.lbUrl.TabIndex = 0;
            this.lbUrl.Text = "开始地址";
            // 
            // txtBeginUrl
            // 
            this.txtBeginUrl.Location = new System.Drawing.Point(96, 33);
            this.txtBeginUrl.Name = "txtBeginUrl";
            this.txtBeginUrl.Size = new System.Drawing.Size(350, 21);
            this.txtBeginUrl.TabIndex = 1;
            // 
            // lbpath
            // 
            this.lbpath.AutoSize = true;
            this.lbpath.Location = new System.Drawing.Point(39, 73);
            this.lbpath.Name = "lbpath";
            this.lbpath.Size = new System.Drawing.Size(53, 12);
            this.lbpath.TabIndex = 2;
            this.lbpath.Text = "存储路径";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(96, 69);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(350, 21);
            this.txtPath.TabIndex = 3;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(452, 67);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(46, 23);
            this.btnSel.TabIndex = 4;
            this.btnSel.Text = "浏览";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(13, 136);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(498, 294);
            this.txtContent.TabIndex = 5;
            this.txtContent.Text = "";
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(234, 96);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 34);
            this.btnBegin.TabIndex = 6;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 442);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lbpath);
            this.Controls.Add(this.txtBeginUrl);
            this.Controls.Add(this.lbUrl);
            this.Name = "Form1";
            this.Text = "爬虫客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.TextBox txtBeginUrl;
        private System.Windows.Forms.Label lbpath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Button btnBegin;
    }
}

