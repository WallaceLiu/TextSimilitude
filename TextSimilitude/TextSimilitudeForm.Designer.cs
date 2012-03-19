namespace TextSimilitude
{
    partial class TextSimilitudeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTermName = new System.Windows.Forms.TextBox();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.labelSimilitude = new System.Windows.Forms.Label();
            this.labelBaiduTextNum = new System.Windows.Forms.Label();
            this.labelHudongTextNum = new System.Windows.Forms.Label();
            this.labelBaiduWordNum = new System.Windows.Forms.Label();
            this.labelHudongWordNum = new System.Windows.Forms.Label();
            this.labelSameWordNum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTeam = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBaiduText = new System.Windows.Forms.TabPage();
            this.richTextBoxBaiduText = new System.Windows.Forms.RichTextBox();
            this.tabPageHudongText = new System.Windows.Forms.TabPage();
            this.richTextBoxHudongText = new System.Windows.Forms.RichTextBox();
            this.tabPageTermFreq = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxBaidu = new System.Windows.Forms.GroupBox();
            this.richTextBoxBaiduTermFreq = new System.Windows.Forms.RichTextBox();
            this.groupBoxHudong = new System.Windows.Forms.GroupBox();
            this.richTextBoxHudongTermFreq = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageBaiduWeb = new System.Windows.Forms.TabPage();
            this.webBrowserBaidu = new System.Windows.Forms.WebBrowser();
            this.tabPageHudongWeb = new System.Windows.Forms.TabPage();
            this.webBrowserHudong = new System.Windows.Forms.WebBrowser();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.textBoxBaidu = new System.Windows.Forms.TextBox();
            this.textBoxHudong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxResult.SuspendLayout();
            this.groupBoxTeam.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageBaiduText.SuspendLayout();
            this.tabPageHudongText.SuspendLayout();
            this.tabPageTermFreq.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBoxBaidu.SuspendLayout();
            this.groupBoxHudong.SuspendLayout();
            this.tabPageBaiduWeb.SuspendLayout();
            this.tabPageHudongWeb.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "词条名称";
            // 
            // textBoxTermName
            // 
            this.textBoxTermName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTermName.Location = new System.Drawing.Point(65, 20);
            this.textBoxTermName.MaxLength = 30;
            this.textBoxTermName.Name = "textBoxTermName";
            this.textBoxTermName.Size = new System.Drawing.Size(384, 21);
            this.textBoxTermName.TabIndex = 0;
            this.textBoxTermName.Text = "中科院研究生院";
            // 
            // buttonCompare
            // 
            this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCompare.Location = new System.Drawing.Point(470, 19);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 1;
            this.buttonCompare.Text = "对比";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.Controls.Add(this.labelSimilitude);
            this.groupBoxResult.Controls.Add(this.labelBaiduTextNum);
            this.groupBoxResult.Controls.Add(this.labelHudongTextNum);
            this.groupBoxResult.Controls.Add(this.labelBaiduWordNum);
            this.groupBoxResult.Controls.Add(this.labelHudongWordNum);
            this.groupBoxResult.Controls.Add(this.labelSameWordNum);
            this.groupBoxResult.Controls.Add(this.label13);
            this.groupBoxResult.Controls.Add(this.label12);
            this.groupBoxResult.Controls.Add(this.label11);
            this.groupBoxResult.Controls.Add(this.label10);
            this.groupBoxResult.Controls.Add(this.label9);
            this.groupBoxResult.Controls.Add(this.label5);
            this.groupBoxResult.Location = new System.Drawing.Point(588, 12);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(184, 296);
            this.groupBoxResult.TabIndex = 2;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "结果";
            // 
            // labelSimilitude
            // 
            this.labelSimilitude.AutoSize = true;
            this.labelSimilitude.Location = new System.Drawing.Point(106, 30);
            this.labelSimilitude.Name = "labelSimilitude";
            this.labelSimilitude.Size = new System.Drawing.Size(35, 12);
            this.labelSimilitude.TabIndex = 0;
            this.labelSimilitude.Text = "0.789";
            // 
            // labelBaiduTextNum
            // 
            this.labelBaiduTextNum.AutoSize = true;
            this.labelBaiduTextNum.Location = new System.Drawing.Point(106, 63);
            this.labelBaiduTextNum.Name = "labelBaiduTextNum";
            this.labelBaiduTextNum.Size = new System.Drawing.Size(29, 12);
            this.labelBaiduTextNum.TabIndex = 1;
            this.labelBaiduTextNum.Text = "1300";
            // 
            // labelHudongTextNum
            // 
            this.labelHudongTextNum.AutoSize = true;
            this.labelHudongTextNum.Location = new System.Drawing.Point(106, 91);
            this.labelHudongTextNum.Name = "labelHudongTextNum";
            this.labelHudongTextNum.Size = new System.Drawing.Size(29, 12);
            this.labelHudongTextNum.TabIndex = 2;
            this.labelHudongTextNum.Text = "1200";
            // 
            // labelBaiduWordNum
            // 
            this.labelBaiduWordNum.AutoSize = true;
            this.labelBaiduWordNum.Location = new System.Drawing.Point(106, 130);
            this.labelBaiduWordNum.Name = "labelBaiduWordNum";
            this.labelBaiduWordNum.Size = new System.Drawing.Size(23, 12);
            this.labelBaiduWordNum.TabIndex = 3;
            this.labelBaiduWordNum.Text = "256";
            // 
            // labelHudongWordNum
            // 
            this.labelHudongWordNum.AutoSize = true;
            this.labelHudongWordNum.Location = new System.Drawing.Point(106, 158);
            this.labelHudongWordNum.Name = "labelHudongWordNum";
            this.labelHudongWordNum.Size = new System.Drawing.Size(23, 12);
            this.labelHudongWordNum.TabIndex = 4;
            this.labelHudongWordNum.Text = "222";
            // 
            // labelSameWordNum
            // 
            this.labelSameWordNum.AutoSize = true;
            this.labelSameWordNum.Location = new System.Drawing.Point(106, 197);
            this.labelSameWordNum.Name = "labelSameWordNum";
            this.labelSameWordNum.Size = new System.Drawing.Size(23, 12);
            this.labelSameWordNum.TabIndex = 5;
            this.labelSameWordNum.Text = "166";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "相同词项个数：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "互动词项个数：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "百度词项个数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "互动正文字数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "百度正文字数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "余弦相似度：";
            // 
            // groupBoxTeam
            // 
            this.groupBoxTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTeam.Controls.Add(this.label8);
            this.groupBoxTeam.Controls.Add(this.label7);
            this.groupBoxTeam.Controls.Add(this.label6);
            this.groupBoxTeam.Location = new System.Drawing.Point(588, 450);
            this.groupBoxTeam.Name = "groupBoxTeam";
            this.groupBoxTeam.Size = new System.Drawing.Size(184, 100);
            this.groupBoxTeam.TabIndex = 4;
            this.groupBoxTeam.TabStop = false;
            this.groupBoxTeam.Text = "小组成员";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "白朔天 2010280086290";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "李一琳 201028008629024";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "张  帆 2010E8008669029";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageBaiduText);
            this.tabControl.Controls.Add(this.tabPageHudongText);
            this.tabControl.Controls.Add(this.tabPageTermFreq);
            this.tabControl.Controls.Add(this.tabPageBaiduWeb);
            this.tabControl.Controls.Add(this.tabPageHudongWeb);
            this.tabControl.Location = new System.Drawing.Point(12, 142);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(570, 408);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageBaiduText
            // 
            this.tabPageBaiduText.Controls.Add(this.richTextBoxBaiduText);
            this.tabPageBaiduText.Location = new System.Drawing.Point(4, 22);
            this.tabPageBaiduText.Name = "tabPageBaiduText";
            this.tabPageBaiduText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBaiduText.Size = new System.Drawing.Size(562, 382);
            this.tabPageBaiduText.TabIndex = 0;
            this.tabPageBaiduText.Text = "【百度】正文";
            this.tabPageBaiduText.UseVisualStyleBackColor = true;
            // 
            // richTextBoxBaiduText
            // 
            this.richTextBoxBaiduText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxBaiduText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.richTextBoxBaiduText.Location = new System.Drawing.Point(-4, -3);
            this.richTextBoxBaiduText.Name = "richTextBoxBaiduText";
            this.richTextBoxBaiduText.Size = new System.Drawing.Size(570, 389);
            this.richTextBoxBaiduText.TabIndex = 0;
            this.richTextBoxBaiduText.Text = "";
            // 
            // tabPageHudongText
            // 
            this.tabPageHudongText.Controls.Add(this.richTextBoxHudongText);
            this.tabPageHudongText.Location = new System.Drawing.Point(4, 22);
            this.tabPageHudongText.Name = "tabPageHudongText";
            this.tabPageHudongText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHudongText.Size = new System.Drawing.Size(562, 382);
            this.tabPageHudongText.TabIndex = 1;
            this.tabPageHudongText.Text = "【互动】正文";
            this.tabPageHudongText.UseVisualStyleBackColor = true;
            // 
            // richTextBoxHudongText
            // 
            this.richTextBoxHudongText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxHudongText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.richTextBoxHudongText.Location = new System.Drawing.Point(-4, -4);
            this.richTextBoxHudongText.Name = "richTextBoxHudongText";
            this.richTextBoxHudongText.Size = new System.Drawing.Size(566, 390);
            this.richTextBoxHudongText.TabIndex = 0;
            this.richTextBoxHudongText.Text = "";
            // 
            // tabPageTermFreq
            // 
            this.tabPageTermFreq.Controls.Add(this.splitContainer);
            this.tabPageTermFreq.Controls.Add(this.label4);
            this.tabPageTermFreq.Location = new System.Drawing.Point(4, 22);
            this.tabPageTermFreq.Name = "tabPageTermFreq";
            this.tabPageTermFreq.Size = new System.Drawing.Size(562, 382);
            this.tabPageTermFreq.TabIndex = 4;
            this.tabPageTermFreq.Text = "【百度VS互动】词频";
            this.tabPageTermFreq.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxBaidu);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxHudong);
            this.splitContainer.Size = new System.Drawing.Size(559, 355);
            this.splitContainer.SplitterDistance = 276;
            this.splitContainer.TabIndex = 0;
            // 
            // groupBoxBaidu
            // 
            this.groupBoxBaidu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBaidu.Controls.Add(this.richTextBoxBaiduTermFreq);
            this.groupBoxBaidu.Location = new System.Drawing.Point(5, 3);
            this.groupBoxBaidu.Name = "groupBoxBaidu";
            this.groupBoxBaidu.Size = new System.Drawing.Size(268, 349);
            this.groupBoxBaidu.TabIndex = 0;
            this.groupBoxBaidu.TabStop = false;
            this.groupBoxBaidu.Text = "百度";
            // 
            // richTextBoxBaiduTermFreq
            // 
            this.richTextBoxBaiduTermFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxBaiduTermFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.richTextBoxBaiduTermFreq.Location = new System.Drawing.Point(6, 20);
            this.richTextBoxBaiduTermFreq.Name = "richTextBoxBaiduTermFreq";
            this.richTextBoxBaiduTermFreq.Size = new System.Drawing.Size(256, 323);
            this.richTextBoxBaiduTermFreq.TabIndex = 0;
            this.richTextBoxBaiduTermFreq.Text = "";
            // 
            // groupBoxHudong
            // 
            this.groupBoxHudong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHudong.Controls.Add(this.richTextBoxHudongTermFreq);
            this.groupBoxHudong.Location = new System.Drawing.Point(3, 3);
            this.groupBoxHudong.Name = "groupBoxHudong";
            this.groupBoxHudong.Size = new System.Drawing.Size(273, 349);
            this.groupBoxHudong.TabIndex = 0;
            this.groupBoxHudong.TabStop = false;
            this.groupBoxHudong.Text = "互动";
            // 
            // richTextBoxHudongTermFreq
            // 
            this.richTextBoxHudongTermFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxHudongTermFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(207)))));
            this.richTextBoxHudongTermFreq.Location = new System.Drawing.Point(6, 20);
            this.richTextBoxHudongTermFreq.Name = "richTextBoxHudongTermFreq";
            this.richTextBoxHudongTermFreq.Size = new System.Drawing.Size(261, 323);
            this.richTextBoxHudongTermFreq.TabIndex = 0;
            this.richTextBoxHudongTermFreq.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "提示：只保留了长度和词频都大于1的词项";
            // 
            // tabPageBaiduWeb
            // 
            this.tabPageBaiduWeb.Controls.Add(this.webBrowserBaidu);
            this.tabPageBaiduWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageBaiduWeb.Name = "tabPageBaiduWeb";
            this.tabPageBaiduWeb.Size = new System.Drawing.Size(562, 382);
            this.tabPageBaiduWeb.TabIndex = 2;
            this.tabPageBaiduWeb.Text = "【百度】网页预览";
            this.tabPageBaiduWeb.UseVisualStyleBackColor = true;
            // 
            // webBrowserBaidu
            // 
            this.webBrowserBaidu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBaidu.Location = new System.Drawing.Point(0, 0);
            this.webBrowserBaidu.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBaidu.Name = "webBrowserBaidu";
            this.webBrowserBaidu.ScriptErrorsSuppressed = true;
            this.webBrowserBaidu.Size = new System.Drawing.Size(562, 382);
            this.webBrowserBaidu.TabIndex = 0;
            // 
            // tabPageHudongWeb
            // 
            this.tabPageHudongWeb.Controls.Add(this.webBrowserHudong);
            this.tabPageHudongWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageHudongWeb.Name = "tabPageHudongWeb";
            this.tabPageHudongWeb.Size = new System.Drawing.Size(562, 382);
            this.tabPageHudongWeb.TabIndex = 3;
            this.tabPageHudongWeb.Text = "【互动】网页预览";
            this.tabPageHudongWeb.UseVisualStyleBackColor = true;
            // 
            // webBrowserHudong
            // 
            this.webBrowserHudong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserHudong.Location = new System.Drawing.Point(0, 0);
            this.webBrowserHudong.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHudong.Name = "webBrowserHudong";
            this.webBrowserHudong.ScriptErrorsSuppressed = true;
            this.webBrowserHudong.Size = new System.Drawing.Size(562, 382);
            this.webBrowserHudong.TabIndex = 0;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMain.Controls.Add(this.textBoxTermName);
            this.groupBoxMain.Controls.Add(this.textBoxBaidu);
            this.groupBoxMain.Controls.Add(this.textBoxHudong);
            this.groupBoxMain.Controls.Add(this.buttonCompare);
            this.groupBoxMain.Controls.Add(this.label3);
            this.groupBoxMain.Controls.Add(this.label2);
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(566, 124);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            // 
            // textBoxBaidu
            // 
            this.textBoxBaidu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBaidu.Location = new System.Drawing.Point(65, 58);
            this.textBoxBaidu.Name = "textBoxBaidu";
            this.textBoxBaidu.Size = new System.Drawing.Size(480, 21);
            this.textBoxBaidu.TabIndex = 2;
            // 
            // textBoxHudong
            // 
            this.textBoxHudong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHudong.Location = new System.Drawing.Point(65, 86);
            this.textBoxHudong.Name = "textBoxHudong";
            this.textBoxHudong.Size = new System.Drawing.Size(480, 21);
            this.textBoxHudong.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "互动百科";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "百度百科";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(588, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(11, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(167, 104);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "  1.程序采用了基于向量空间的余弦相似度来衡量网页间的相似度\n\n  2.只保留了长度和词频都大于1的词项";
            // 
            // TextSimilitudeForm
            // 
            this.AcceptButton = this.buttonCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBoxTeam);
            this.Controls.Add(this.groupBoxResult);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TextSimilitudeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百度VS互动  百科词条相似度";
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.groupBoxTeam.ResumeLayout(false);
            this.groupBoxTeam.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageBaiduText.ResumeLayout(false);
            this.tabPageHudongText.ResumeLayout(false);
            this.tabPageTermFreq.ResumeLayout(false);
            this.tabPageTermFreq.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.groupBoxBaidu.ResumeLayout(false);
            this.groupBoxHudong.ResumeLayout(false);
            this.tabPageBaiduWeb.ResumeLayout(false);
            this.tabPageHudongWeb.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTermName;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.GroupBox groupBoxTeam;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBaiduText;
        private System.Windows.Forms.TabPage tabPageHudongText;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.TextBox textBoxHudong;
        private System.Windows.Forms.TextBox textBoxBaidu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxBaiduText;
        private System.Windows.Forms.TabPage tabPageBaiduWeb;
        private System.Windows.Forms.TabPage tabPageHudongWeb;
        private System.Windows.Forms.TabPage tabPageTermFreq;
        private System.Windows.Forms.WebBrowser webBrowserBaidu;
        private System.Windows.Forms.WebBrowser webBrowserHudong;
        private System.Windows.Forms.RichTextBox richTextBoxHudongText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxHudong;
        private System.Windows.Forms.GroupBox groupBoxBaidu;
        private System.Windows.Forms.RichTextBox richTextBoxHudongTermFreq;
        private System.Windows.Forms.RichTextBox richTextBoxBaiduTermFreq;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label labelSimilitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSameWordNum;
        private System.Windows.Forms.Label labelHudongWordNum;
        private System.Windows.Forms.Label labelBaiduWordNum;
        private System.Windows.Forms.Label labelHudongTextNum;
        private System.Windows.Forms.Label labelBaiduTextNum;
    }
}

