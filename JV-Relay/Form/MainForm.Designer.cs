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
            this.autoPost4Label = new System.Windows.Forms.Label();
            this.autoPost3Label = new System.Windows.Forms.Label();
            this.autoPostIntervalTextBox = new System.Windows.Forms.TextBox();
            this.autoPostToTextBox = new System.Windows.Forms.TextBox();
            this.autoPost1Label = new System.Windows.Forms.Label();
            this.autoPost2Label = new System.Windows.Forms.Label();
            this.isAutoPostCheckBox = new System.Windows.Forms.CheckBox();
            this.isSetupCheckBox = new System.Windows.Forms.CheckBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.umaStorageButton = new System.Windows.Forms.Button();
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
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost4Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost3Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPostIntervalTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPostToTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost1Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.autoPost2Label);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.isAutoPostCheckBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.isSetupCheckBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.fromTextBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.umaStorageButton);
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
            // autoPost4Label
            // 
            this.autoPost4Label.AutoSize = true;
            this.autoPost4Label.Location = new System.Drawing.Point(379, 64);
            this.autoPost4Label.Name = "autoPost4Label";
            this.autoPost4Label.Size = new System.Drawing.Size(13, 12);
            this.autoPost4Label.TabIndex = 30;
            this.autoPost4Label.Text = "　";
            // 
            // autoPost3Label
            // 
            this.autoPost3Label.AutoSize = true;
            this.autoPost3Label.Location = new System.Drawing.Point(271, 64);
            this.autoPost3Label.Name = "autoPost3Label";
            this.autoPost3Label.Size = new System.Drawing.Size(107, 12);
            this.autoPost3Label.TabIndex = 29;
            this.autoPost3Label.Text = "次回WEB登録予定：";
            // 
            // autoPostIntervalTextBox
            // 
            this.autoPostIntervalTextBox.Location = new System.Drawing.Point(409, 42);
            this.autoPostIntervalTextBox.Name = "autoPostIntervalTextBox";
            this.autoPostIntervalTextBox.Size = new System.Drawing.Size(28, 19);
            this.autoPostIntervalTextBox.TabIndex = 7;
            this.autoPostIntervalTextBox.Leave += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // autoPostToTextBox
            // 
            this.autoPostToTextBox.Location = new System.Drawing.Point(273, 42);
            this.autoPostToTextBox.Name = "autoPostToTextBox";
            this.autoPostToTextBox.Size = new System.Drawing.Size(100, 19);
            this.autoPostToTextBox.TabIndex = 6;
            this.autoPostToTextBox.Leave += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // autoPost1Label
            // 
            this.autoPost1Label.AutoSize = true;
            this.autoPost1Label.Location = new System.Drawing.Point(379, 45);
            this.autoPost1Label.Name = "autoPost1Label";
            this.autoPost1Label.Size = new System.Drawing.Size(24, 12);
            this.autoPost1Label.TabIndex = 26;
            this.autoPost1Label.Text = "まで";
            // 
            // autoPost2Label
            // 
            this.autoPost2Label.AutoSize = true;
            this.autoPost2Label.Location = new System.Drawing.Point(443, 45);
            this.autoPost2Label.Name = "autoPost2Label";
            this.autoPost2Label.Size = new System.Drawing.Size(41, 12);
            this.autoPost2Label.TabIndex = 24;
            this.autoPost2Label.Text = "分間隔";
            // 
            // isAutoPostCheckBox
            // 
            this.isAutoPostCheckBox.AutoSize = true;
            this.isAutoPostCheckBox.Location = new System.Drawing.Point(252, 20);
            this.isAutoPostCheckBox.Name = "isAutoPostCheckBox";
            this.isAutoPostCheckBox.Size = new System.Drawing.Size(197, 16);
            this.isAutoPostCheckBox.TabIndex = 5;
            this.isAutoPostCheckBox.Text = "自動的にレース結果をWEB登録する";
            this.isAutoPostCheckBox.UseVisualStyleBackColor = true;
            this.isAutoPostCheckBox.CheckedChanged += new System.EventHandler(this.autoPostSetting_Changed);
            // 
            // isSetupCheckBox
            // 
            this.isSetupCheckBox.AutoSize = true;
            this.isSetupCheckBox.Location = new System.Drawing.Point(252, 188);
            this.isSetupCheckBox.Name = "isSetupCheckBox";
            this.isSetupCheckBox.Size = new System.Drawing.Size(307, 16);
            this.isSetupCheckBox.TabIndex = 15;
            this.isSetupCheckBox.Text = "初期化して一からデータを作成する（数十分以上かかります）";
            this.isSetupCheckBox.UseVisualStyleBackColor = true;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(15, 175);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(113, 19);
            this.fromTextBox.TabIndex = 8;
            // 
            // umaStorageButton
            // 
            this.umaStorageButton.Location = new System.Drawing.Point(134, 165);
            this.umaStorageButton.Name = "umaStorageButton";
            this.umaStorageButton.Size = new System.Drawing.Size(114, 39);
            this.umaStorageButton.TabIndex = 14;
            this.umaStorageButton.Text = "馬情報\r\n（ファイル保存のみ）";
            this.umaStorageButton.UseVisualStyleBackColor = true;
            this.umaStorageButton.Click += new System.EventHandler(this.umaStorageButton_Click);
            // 
            // storagePostButton
            // 
            this.storagePostButton.Location = new System.Drawing.Point(12, 3);
            this.storagePostButton.Name = "storagePostButton";
            this.storagePostButton.Size = new System.Drawing.Size(114, 48);
            this.storagePostButton.TabIndex = 3;
            this.storagePostButton.Text = "出走馬情報\r\n（WEB登録）";
            this.storagePostButton.UseVisualStyleBackColor = true;
            this.storagePostButton.Click += new System.EventHandler(this.storagePostButton_Click);
            // 
            // realTimePostButton
            // 
            this.realTimePostButton.Location = new System.Drawing.Point(132, 3);
            this.realTimePostButton.Name = "realTimePostButton";
            this.realTimePostButton.Size = new System.Drawing.Size(114, 48);
            this.realTimePostButton.TabIndex = 4;
            this.realTimePostButton.Text = "レース結果\r\n（WEB登録）";
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
            this.realTimeButton.Location = new System.Drawing.Point(564, 57);
            this.realTimeButton.Name = "realTimeButton";
            this.realTimeButton.Size = new System.Drawing.Size(114, 48);
            this.realTimeButton.TabIndex = 2;
            this.realTimeButton.Text = "レース結果\r\n（ファイル保存のみ）";
            this.realTimeButton.UseVisualStyleBackColor = true;
            this.realTimeButton.Click += new System.EventHandler(this.realTimeButton_Click);
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(564, 3);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(114, 48);
            this.storageButton.TabIndex = 1;
            this.storageButton.Text = "出走馬情報\r\n(ファイル保存のみ)";
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
        private System.Windows.Forms.Button umaStorageButton;
        private System.ComponentModel.BackgroundWorker mainBackgroundWorker;
        private System.Windows.Forms.CheckBox isSetupCheckBox;
        private System.Windows.Forms.TextBox autoPostIntervalTextBox;
        private System.Windows.Forms.TextBox autoPostToTextBox;
        private System.Windows.Forms.Label autoPost1Label;
        private System.Windows.Forms.Label autoPost2Label;
        private System.Windows.Forms.CheckBox isAutoPostCheckBox;
        private System.Windows.Forms.Label autoPost4Label;
        private System.Windows.Forms.Label autoPost3Label;
    }
}

