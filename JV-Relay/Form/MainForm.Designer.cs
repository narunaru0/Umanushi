namespace JVRelay
{
    /// <summary>
    /// メイン画面
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.autoPost4Label = new System.Windows.Forms.Label();
            this.autoPost3Label = new System.Windows.Forms.Label();
            this.autoPostIntervalTextBox = new System.Windows.Forms.TextBox();
            this.autoPostToTextBox = new System.Windows.Forms.TextBox();
            this.autoPost1Label = new System.Windows.Forms.Label();
            this.autoPost2Label = new System.Windows.Forms.Label();
            this.isAutoPostCheckBox = new System.Windows.Forms.CheckBox();
            this.isSetupCheckBox = new System.Windows.Forms.CheckBox();
            this.hoyuRadioButton = new System.Windows.Forms.RadioButton();
            this.from2Label = new System.Windows.Forms.Label();
            this.from1Label = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.boldRadioButton = new System.Windows.Forms.RadioButton();
            this.diffRadioButton = new System.Windows.Forms.RadioButton();
            this.raceRadioButton = new System.Windows.Forms.RadioButton();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.customStorageButton = new System.Windows.Forms.Button();
            this.storagePostButton = new System.Windows.Forms.Button();
            this.realTimePostButton = new System.Windows.Forms.Button();
            this.axJVLink = new AxJVDTLabLib.AxJVLink();
            this.realTimeButton = new System.Windows.Forms.Button();
            this.storageButton = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.aboutBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.ContentPanel.SuspendLayout();
            this.mainToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axJVLink)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStripContainer
            // 
            // 
            // mainToolStripContainer.BottomToolStripPanel
            // 
            this.mainToolStripContainer.BottomToolStripPanel.Controls.Add(this.mainStatusStrip);
            // 
            // mainToolStripContainer.ContentPanel
            // 
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.label1);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost4Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost3Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPostIntervalTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPostToTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost1Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost2Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.isAutoPostCheckBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.isSetupCheckBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.hoyuRadioButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.from2Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.from1Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.toTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.boldRadioButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.diffRadioButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.raceRadioButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.fromTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.customStorageButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.storagePostButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.realTimePostButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.axJVLink);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.realTimeButton);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.storageButton);
            this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(690, 370);
            this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.Size = new System.Drawing.Size(690, 419);
            this.mainToolStripContainer.TabIndex = 5;
            this.mainToolStripContainer.Text = "toolStripContainer1";
            // 
            // mainToolStripContainer.TopToolStripPanel
            // 
            this.mainToolStripContainer.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripProgressBar,
            this.mainToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(690, 23);
            this.mainStatusStrip.TabIndex = 3;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainToolStripProgressBar
            // 
            this.mainToolStripProgressBar.Name = "mainToolStripProgressBar";
            this.mainToolStripProgressBar.Size = new System.Drawing.Size(100, 17);
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(20, 18);
            this.mainToolStripStatusLabel.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "以下、未整備　※差分をローカル(SQLite？)で蓄積し、全現役馬を抽出するようにする？不要なものは削除？";
            // 
            // autoPost4Label
            // 
            this.autoPost4Label.AutoSize = true;
            this.autoPost4Label.Location = new System.Drawing.Point(384, 113);
            this.autoPost4Label.Name = "autoPost4Label";
            this.autoPost4Label.Size = new System.Drawing.Size(13, 12);
            this.autoPost4Label.TabIndex = 30;
            this.autoPost4Label.Text = "　";
            // 
            // autoPost3Label
            // 
            this.autoPost3Label.AutoSize = true;
            this.autoPost3Label.Location = new System.Drawing.Point(271, 113);
            this.autoPost3Label.Name = "autoPost3Label";
            this.autoPost3Label.Size = new System.Drawing.Size(107, 12);
            this.autoPost3Label.TabIndex = 29;
            this.autoPost3Label.Text = "次回WEB登録予定：";
            // 
            // autoPostIntervalTextBox
            // 
            this.autoPostIntervalTextBox.Location = new System.Drawing.Point(405, 91);
            this.autoPostIntervalTextBox.Name = "autoPostIntervalTextBox";
            this.autoPostIntervalTextBox.Size = new System.Drawing.Size(28, 19);
            this.autoPostIntervalTextBox.TabIndex = 7;
            this.autoPostIntervalTextBox.Leave += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // autoPostToTextBox
            // 
            this.autoPostToTextBox.Location = new System.Drawing.Point(269, 91);
            this.autoPostToTextBox.Name = "autoPostToTextBox";
            this.autoPostToTextBox.Size = new System.Drawing.Size(100, 19);
            this.autoPostToTextBox.TabIndex = 6;
            this.autoPostToTextBox.Leave += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // autoPost1Label
            // 
            this.autoPost1Label.AutoSize = true;
            this.autoPost1Label.Location = new System.Drawing.Point(375, 94);
            this.autoPost1Label.Name = "autoPost1Label";
            this.autoPost1Label.Size = new System.Drawing.Size(24, 12);
            this.autoPost1Label.TabIndex = 26;
            this.autoPost1Label.Text = "まで";
            // 
            // autoPost2Label
            // 
            this.autoPost2Label.AutoSize = true;
            this.autoPost2Label.Location = new System.Drawing.Point(439, 94);
            this.autoPost2Label.Name = "autoPost2Label";
            this.autoPost2Label.Size = new System.Drawing.Size(41, 12);
            this.autoPost2Label.TabIndex = 24;
            this.autoPost2Label.Text = "分間隔";
            // 
            // isAutoPostCheckBox
            // 
            this.isAutoPostCheckBox.AutoSize = true;
            this.isAutoPostCheckBox.Location = new System.Drawing.Point(252, 71);
            this.isAutoPostCheckBox.Name = "isAutoPostCheckBox";
            this.isAutoPostCheckBox.Size = new System.Drawing.Size(136, 16);
            this.isAutoPostCheckBox.TabIndex = 5;
            this.isAutoPostCheckBox.Text = "自動的にWEB登録する";
            this.isAutoPostCheckBox.UseVisualStyleBackColor = true;
            this.isAutoPostCheckBox.CheckedChanged += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // isSetupCheckBox
            // 
            this.isSetupCheckBox.AutoSize = true;
            this.isSetupCheckBox.Location = new System.Drawing.Point(133, 234);
            this.isSetupCheckBox.Name = "isSetupCheckBox";
            this.isSetupCheckBox.Size = new System.Drawing.Size(102, 16);
            this.isSetupCheckBox.TabIndex = 15;
            this.isSetupCheckBox.Text = "セットアップデータ";
            this.isSetupCheckBox.UseVisualStyleBackColor = true;
            // 
            // hoyuRadioButton
            // 
            this.hoyuRadioButton.AutoSize = true;
            this.hoyuRadioButton.Location = new System.Drawing.Point(370, 200);
            this.hoyuRadioButton.Name = "hoyuRadioButton";
            this.hoyuRadioButton.Size = new System.Drawing.Size(168, 16);
            this.hoyuRadioButton.TabIndex = 13;
            this.hoyuRadioButton.TabStop = true;
            this.hoyuRadioButton.Text = "馬名の意味由来情報(HOYU)";
            this.hoyuRadioButton.UseVisualStyleBackColor = true;
            // 
            // from2Label
            // 
            this.from2Label.AutoSize = true;
            this.from2Label.Location = new System.Drawing.Point(271, 178);
            this.from2Label.Name = "from2Label";
            this.from2Label.Size = new System.Drawing.Size(89, 12);
            this.from2Label.TabIndex = 20;
            this.from2Label.Text = ")　例：yyyyMMdd";
            // 
            // from1Label
            // 
            this.from1Label.AutoSize = true;
            this.from1Label.Location = new System.Drawing.Point(130, 178);
            this.from1Label.Name = "from1Label";
            this.from1Label.Size = new System.Drawing.Size(14, 12);
            this.from1Label.TabIndex = 19;
            this.from1Label.Text = "~(";
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(152, 175);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(113, 19);
            this.toTextBox.TabIndex = 9;
            // 
            // boldRadioButton
            // 
            this.boldRadioButton.AutoSize = true;
            this.boldRadioButton.Location = new System.Drawing.Point(255, 200);
            this.boldRadioButton.Name = "boldRadioButton";
            this.boldRadioButton.Size = new System.Drawing.Size(109, 16);
            this.boldRadioButton.TabIndex = 12;
            this.boldRadioButton.TabStop = true;
            this.boldRadioButton.Text = "血統情報(BOLD)";
            this.boldRadioButton.UseVisualStyleBackColor = true;
            // 
            // diffRadioButton
            // 
            this.diffRadioButton.AutoSize = true;
            this.diffRadioButton.Location = new System.Drawing.Point(133, 200);
            this.diffRadioButton.Name = "diffRadioButton";
            this.diffRadioButton.Size = new System.Drawing.Size(116, 16);
            this.diffRadioButton.TabIndex = 11;
            this.diffRadioButton.TabStop = true;
            this.diffRadioButton.Text = "蓄積系情報(DIFF)";
            this.diffRadioButton.UseVisualStyleBackColor = true;
            // 
            // raceRadioButton
            // 
            this.raceRadioButton.AutoSize = true;
            this.raceRadioButton.Location = new System.Drawing.Point(13, 200);
            this.raceRadioButton.Name = "raceRadioButton";
            this.raceRadioButton.Size = new System.Drawing.Size(114, 16);
            this.raceRadioButton.TabIndex = 10;
            this.raceRadioButton.TabStop = true;
            this.raceRadioButton.Text = "レース情報(RACE)";
            this.raceRadioButton.UseVisualStyleBackColor = true;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(13, 175);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(113, 19);
            this.fromTextBox.TabIndex = 8;
            // 
            // customStorageButton
            // 
            this.customStorageButton.Location = new System.Drawing.Point(14, 222);
            this.customStorageButton.Name = "customStorageButton";
            this.customStorageButton.Size = new System.Drawing.Size(114, 39);
            this.customStorageButton.TabIndex = 14;
            this.customStorageButton.Text = "蓄積系データ取得\r\n+ファイル保存";
            this.customStorageButton.UseVisualStyleBackColor = true;
            this.customStorageButton.Click += new System.EventHandler(this.customStorageButton_Click);
            // 
            // storagePostButton
            // 
            this.storagePostButton.Location = new System.Drawing.Point(12, 71);
            this.storagePostButton.Name = "storagePostButton";
            this.storagePostButton.Size = new System.Drawing.Size(114, 48);
            this.storagePostButton.TabIndex = 3;
            this.storagePostButton.Text = "今週開催データ取得\r\n（出走馬情報）\r\n+WEB登録";
            this.storagePostButton.UseVisualStyleBackColor = true;
            this.storagePostButton.Click += new System.EventHandler(this.storagePostButton_Click);
            // 
            // realTimePostButton
            // 
            this.realTimePostButton.Location = new System.Drawing.Point(132, 71);
            this.realTimePostButton.Name = "realTimePostButton";
            this.realTimePostButton.Size = new System.Drawing.Size(114, 48);
            this.realTimePostButton.TabIndex = 4;
            this.realTimePostButton.Text = "速報系データ取得\r\n（レース結果）\r\n+WEB登録";
            this.realTimePostButton.UseVisualStyleBackColor = true;
            this.realTimePostButton.Click += new System.EventHandler(this.realTimePostButton_Click);
            // 
            // axJVLink
            // 
            this.axJVLink.Enabled = true;
            this.axJVLink.Location = new System.Drawing.Point(590, 301);
            this.axJVLink.Name = "axJVLink";
            this.axJVLink.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axJVLink.OcxState")));
            this.axJVLink.Size = new System.Drawing.Size(192, 192);
            this.axJVLink.TabIndex = 0;
            // 
            // realTimeButton
            // 
            this.realTimeButton.Location = new System.Drawing.Point(132, 17);
            this.realTimeButton.Name = "realTimeButton";
            this.realTimeButton.Size = new System.Drawing.Size(114, 48);
            this.realTimeButton.TabIndex = 2;
            this.realTimeButton.Text = "速報系データ取得\r\n（レース結果）\r\n+ファイル保存";
            this.realTimeButton.UseVisualStyleBackColor = true;
            this.realTimeButton.Click += new System.EventHandler(this.realTimeButton_Click);
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(12, 17);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(114, 48);
            this.storageButton.TabIndex = 1;
            this.storageButton.Text = "今週開催データ取得\r\n（出走馬情報）\r\n+ファイル保存";
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.storageButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(690, 26);
            this.mainMenuStrip.TabIndex = 9;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "終了";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.toolToolStripMenuItem.Text = "ツール";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.optionToolStripMenuItem.Text = "オプション";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readMeToolStripMenuItem,
            this.helpToolStripSeparator,
            this.aboutBoxToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.helpToolStripMenuItem.Text = "ヘルプ";
            // 
            // readMeToolStripMenuItem
            // 
            this.readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
            this.readMeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.readMeToolStripMenuItem.Text = "内容";
            this.readMeToolStripMenuItem.Click += new System.EventHandler(this.readMeToolStripMenuItem_Click);
            // 
            // helpToolStripSeparator
            // 
            this.helpToolStripSeparator.Name = "helpToolStripSeparator";
            this.helpToolStripSeparator.Size = new System.Drawing.Size(169, 6);
            // 
            // aboutBoxToolStripMenuItem
            // 
            this.aboutBoxToolStripMenuItem.Name = "aboutBoxToolStripMenuItem";
            this.aboutBoxToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.aboutBoxToolStripMenuItem.Text = "バージョン情報...";
            this.aboutBoxToolStripMenuItem.Click += new System.EventHandler(this.aboutBoxToolStripMenuItem_Click);
            // 
            // mainBackgroundWorker
            // 
            this.mainBackgroundWorker.WorkerReportsProgress = true;
            this.mainBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mainBackgroundWorker_DoWork);
            this.mainBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.mainBackgroundWorker_ProgressChanged);
            this.mainBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.mainBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 419);
            this.Controls.Add(this.mainToolStripContainer);
            this.Name = "MainForm";
            this.Text = "JV-Relay";
            this.mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.mainToolStripContainer.ContentPanel.PerformLayout();
            this.mainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.TopToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ResumeLayout(false);
            this.mainToolStripContainer.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axJVLink)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
        private AxJVDTLabLib.AxJVLink axJVLink;
        private System.Windows.Forms.Button realTimeButton;
        private System.Windows.Forms.Button storageButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar mainToolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator helpToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem aboutBoxToolStripMenuItem;
        private System.Windows.Forms.Button realTimePostButton;
        private System.Windows.Forms.Button storagePostButton;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Button customStorageButton;
        private System.Windows.Forms.RadioButton boldRadioButton;
        private System.Windows.Forms.RadioButton diffRadioButton;
        private System.Windows.Forms.RadioButton raceRadioButton;
        private System.Windows.Forms.Label from2Label;
        private System.Windows.Forms.Label from1Label;
        private System.Windows.Forms.TextBox toTextBox;
        private System.ComponentModel.BackgroundWorker mainBackgroundWorker;
        private System.Windows.Forms.RadioButton hoyuRadioButton;
        private System.Windows.Forms.CheckBox isSetupCheckBox;
        private System.Windows.Forms.TextBox autoPostIntervalTextBox;
        private System.Windows.Forms.TextBox autoPostToTextBox;
        private System.Windows.Forms.Label autoPost1Label;
        private System.Windows.Forms.Label autoPost2Label;
        private System.Windows.Forms.CheckBox isAutoPostCheckBox;
        private System.Windows.Forms.Label autoPost4Label;
        private System.Windows.Forms.Label autoPost3Label;
        private System.Windows.Forms.Label label1;
    }
}

