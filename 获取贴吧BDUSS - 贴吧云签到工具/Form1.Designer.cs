namespace bdusstool
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.bduss = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_bduss = new System.Windows.Forms.GroupBox();
            this.panel_info = new System.Windows.Forms.GroupBox();
            this.getcode = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pw = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.Label();
            this.codeimg = new System.Windows.Forms.PictureBox();
            this.webcore = new System.Windows.Forms.WebBrowser();
            this.statusStrip1.SuspendLayout();
            this.panel_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeimg)).BeginInit();
            this.SuspendLayout();
            // 
            // bduss
            // 
            resources.ApplyResources(this.bduss, "bduss");
            this.bduss.Name = "bduss";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.LinkColor = System.Drawing.Color.SteelBlue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.IsLink = true;
            this.toolStripStatusLabel4.LinkColor = System.Drawing.Color.SteelBlue;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            resources.ApplyResources(this.toolStripStatusLabel4, "toolStripStatusLabel4");
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            resources.ApplyResources(this.toolStripStatusLabel5, "toolStripStatusLabel5");
            // 
            // panel_bduss
            // 
            resources.ApplyResources(this.panel_bduss, "panel_bduss");
            this.panel_bduss.Name = "panel_bduss";
            this.panel_bduss.TabStop = false;
            // 
            // panel_info
            // 
            this.panel_info.Controls.Add(this.getcode);
            this.panel_info.Controls.Add(this.submit);
            this.panel_info.Controls.Add(this.code);
            this.panel_info.Controls.Add(this.label3);
            this.panel_info.Controls.Add(this.label2);
            this.panel_info.Controls.Add(this.pw);
            this.panel_info.Controls.Add(this.user);
            this.panel_info.Controls.Add(this.label1);
            this.panel_info.Controls.Add(this.tip);
            this.panel_info.Controls.Add(this.codeimg);
            resources.ApplyResources(this.panel_info, "panel_info");
            this.panel_info.Name = "panel_info";
            this.panel_info.TabStop = false;
            // 
            // getcode
            // 
            resources.ApplyResources(this.getcode, "getcode");
            this.getcode.Name = "getcode";
            this.getcode.UseVisualStyleBackColor = true;
            this.getcode.Click += new System.EventHandler(this.button1_Click);
            // 
            // submit
            // 
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // code
            // 
            resources.ApplyResources(this.code, "code");
            this.code.Name = "code";
            this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pw
            // 
            resources.ApplyResources(this.pw, "pw");
            this.pw.Name = "pw";
            // 
            // user
            // 
            resources.ApplyResources(this.user, "user");
            this.user.Name = "user";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tip
            // 
            resources.ApplyResources(this.tip, "tip");
            this.tip.Name = "tip";
            // 
            // codeimg
            // 
            resources.ApplyResources(this.codeimg, "codeimg");
            this.codeimg.Name = "codeimg";
            this.codeimg.TabStop = false;
            // 
            // webcore
            // 
            resources.ApplyResources(this.webcore, "webcore");
            this.webcore.Name = "webcore";
            this.webcore.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webcore_DocumentCompleted);
            // 
            // main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webcore);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bduss);
            this.Controls.Add(this.panel_bduss);
            this.Controls.Add(this.panel_info);
            this.Name = "main";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox bduss;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox panel_bduss;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.GroupBox panel_info;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pw;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox codeimg;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button getcode;
        private System.Windows.Forms.Label tip;
        public System.Windows.Forms.WebBrowser webcore;

    }
}

