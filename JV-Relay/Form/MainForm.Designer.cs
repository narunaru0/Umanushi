﻿namespace JVRelay
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
            this.debugGroupBox = new System.Windows.Forms.GroupBox();
            this.isNextYearCheckBox = new System.Windows.Forms.CheckBox();
            this.raceWeekLabel = new System.Windows.Forms.Label();
            this.raceWeekComboBox = new System.Windows.Forms.ComboBox();
            this.quickDaysLabel = new System.Windows.Forms.Label();
            this.quickDaysTextBox = new System.Windows.Forms.TextBox();
            this.umaFileSaveButton = new System.Windows.Forms.Button();
            this.fromLabel = new System.Windows.Forms.Label();
            this.raceFileSaveButton = new System.Windows.Forms.Button();
            this.umaFromTextBox = new System.Windows.Forms.TextBox();
            this.quickFileSaveButton = new System.Windows.Forms.Button();
            this.isSetupCheckBox = new System.Windows.Forms.CheckBox();
            this.umaGroupBox = new System.Windows.Forms.GroupBox();
            this.umaPostPreset2Button = new System.Windows.Forms.Button();
            this.umaPostPreset1Button = new System.Windows.Forms.Button();
            this.umaAutoPost3Label = new System.Windows.Forms.Label();
            this.umaAutoPost2Label = new System.Windows.Forms.Label();
            this.umaAutoPost1Label = new System.Windows.Forms.Label();
            this.umaPostButton = new System.Windows.Forms.Button();
            this.umaAutoPostFromTextBox = new System.Windows.Forms.TextBox();
            this.isUmaAutoPostCheckBox = new System.Windows.Forms.CheckBox();
            this.quickGroupBox = new System.Windows.Forms.GroupBox();
            this.quickPostButton = new System.Windows.Forms.Button();
            this.isQuickAutoPostCheckBox = new System.Windows.Forms.CheckBox();
            this.quickAutoPost2Label = new System.Windows.Forms.Label();
            this.quickAutoPost1Label = new System.Windows.Forms.Label();
            this.quickAutoPostToTextBox = new System.Windows.Forms.TextBox();
            this.quickAutoPost4Label = new System.Windows.Forms.Label();
            this.quickAutoPostIntervalTextBox = new System.Windows.Forms.TextBox();
            this.quickAutoPost3Label = new System.Windows.Forms.Label();
            this.raceGroupBox = new System.Windows.Forms.GroupBox();
            this.raceAutoPost3Label = new System.Windows.Forms.Label();
            this.racePostPreset3Button = new System.Windows.Forms.Button();
            this.racePostPreset2Button = new System.Windows.Forms.Button();
            this.racePostPreset1Button = new System.Windows.Forms.Button();
            this.raceAutoPost2Label = new System.Windows.Forms.Label();
            this.raceAutoPost1Label = new System.Windows.Forms.Label();
            this.raceAutoPostFromTextBox = new System.Windows.Forms.TextBox();
            this.isRaceAutoPostCheckBox = new System.Windows.Forms.CheckBox();
            this.racePostButton = new System.Windows.Forms.Button();
            this.axJVLink = new AxJVDTLabLib.AxJVLink();
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
            this.debugGroupBox.SuspendLayout();
            this.umaGroupBox.SuspendLayout();
            this.quickGroupBox.SuspendLayout();
            this.raceGroupBox.SuspendLayout();
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
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.debugGroupBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.umaGroupBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.quickGroupBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.raceGroupBox);
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.axJVLink);
            this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(484, 259);
            this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.Size = new System.Drawing.Size(484, 308);
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
            this.mainStatusStrip.Size = new System.Drawing.Size(484, 23);
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
            // debugGroupBox
            // 
            this.debugGroupBox.Controls.Add(this.isNextYearCheckBox);
            this.debugGroupBox.Controls.Add(this.raceWeekLabel);
            this.debugGroupBox.Controls.Add(this.raceWeekComboBox);
            this.debugGroupBox.Controls.Add(this.quickDaysLabel);
            this.debugGroupBox.Controls.Add(this.quickDaysTextBox);
            this.debugGroupBox.Controls.Add(this.umaFileSaveButton);
            this.debugGroupBox.Controls.Add(this.fromLabel);
            this.debugGroupBox.Controls.Add(this.raceFileSaveButton);
            this.debugGroupBox.Controls.Add(this.umaFromTextBox);
            this.debugGroupBox.Controls.Add(this.quickFileSaveButton);
            this.debugGroupBox.Controls.Add(this.isSetupCheckBox);
            this.debugGroupBox.Location = new System.Drawing.Point(12, 261);
            this.debugGroupBox.Name = "debugGroupBox";
            this.debugGroupBox.Size = new System.Drawing.Size(469, 186);
            this.debugGroupBox.TabIndex = 4;
            this.debugGroupBox.TabStop = false;
            this.debugGroupBox.Text = "デバッグ用";
            // 
            // isNextYearCheckBox
            // 
            this.isNextYearCheckBox.AutoSize = true;
            this.isNextYearCheckBox.Location = new System.Drawing.Point(351, 128);
            this.isNextYearCheckBox.Name = "isNextYearCheckBox";
            this.isNextYearCheckBox.Size = new System.Drawing.Size(90, 16);
            this.isNextYearCheckBox.TabIndex = 35;
            this.isNextYearCheckBox.Text = "年替わり処理";
            this.isNextYearCheckBox.UseVisualStyleBackColor = true;
            // 
            // raceWeekLabel
            // 
            this.raceWeekLabel.AutoSize = true;
            this.raceWeekLabel.Location = new System.Drawing.Point(170, 36);
            this.raceWeekLabel.Name = "raceWeekLabel";
            this.raceWeekLabel.Size = new System.Drawing.Size(23, 12);
            this.raceWeekLabel.TabIndex = 34;
            this.raceWeekLabel.Text = "から";
            // 
            // raceWeekComboBox
            // 
            this.raceWeekComboBox.FormattingEnabled = true;
            this.raceWeekComboBox.Location = new System.Drawing.Point(128, 33);
            this.raceWeekComboBox.Name = "raceWeekComboBox";
            this.raceWeekComboBox.Size = new System.Drawing.Size(36, 20);
            this.raceWeekComboBox.TabIndex = 33;
            // 
            // quickDaysLabel
            // 
            this.quickDaysLabel.AutoSize = true;
            this.quickDaysLabel.Location = new System.Drawing.Point(162, 90);
            this.quickDaysLabel.Name = "quickDaysLabel";
            this.quickDaysLabel.Size = new System.Drawing.Size(29, 12);
            this.quickDaysLabel.TabIndex = 31;
            this.quickDaysLabel.Text = "日分";
            // 
            // quickDaysTextBox
            // 
            this.quickDaysTextBox.Location = new System.Drawing.Point(128, 87);
            this.quickDaysTextBox.MaxLength = 2;
            this.quickDaysTextBox.Name = "quickDaysTextBox";
            this.quickDaysTextBox.Size = new System.Drawing.Size(28, 19);
            this.quickDaysTextBox.TabIndex = 32;
            // 
            // umaFileSaveButton
            // 
            this.umaFileSaveButton.Location = new System.Drawing.Point(6, 126);
            this.umaFileSaveButton.Name = "umaFileSaveButton";
            this.umaFileSaveButton.Size = new System.Drawing.Size(114, 48);
            this.umaFileSaveButton.TabIndex = 3;
            this.umaFileSaveButton.Text = "馬情報\r\n（ファイル保存のみ）";
            this.umaFileSaveButton.UseVisualStyleBackColor = true;
            this.umaFileSaveButton.Click += new System.EventHandler(this.umaFileSaveButton_Click);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(124, 129);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(99, 12);
            this.fromLabel.TabIndex = 31;
            this.fromLabel.Text = "登録済データ日時：";
            // 
            // raceFileSaveButton
            // 
            this.raceFileSaveButton.Location = new System.Drawing.Point(6, 18);
            this.raceFileSaveButton.Name = "raceFileSaveButton";
            this.raceFileSaveButton.Size = new System.Drawing.Size(114, 48);
            this.raceFileSaveButton.TabIndex = 1;
            this.raceFileSaveButton.Text = "出走馬情報\r\n(ファイル保存のみ)";
            this.raceFileSaveButton.UseVisualStyleBackColor = true;
            this.raceFileSaveButton.Click += new System.EventHandler(this.raceFileSaveButton_Click);
            // 
            // umaFromTextBox
            // 
            this.umaFromTextBox.Location = new System.Drawing.Point(229, 126);
            this.umaFromTextBox.MaxLength = 14;
            this.umaFromTextBox.Name = "umaFromTextBox";
            this.umaFromTextBox.Size = new System.Drawing.Size(94, 19);
            this.umaFromTextBox.TabIndex = 1;
            // 
            // quickFileSaveButton
            // 
            this.quickFileSaveButton.Location = new System.Drawing.Point(6, 72);
            this.quickFileSaveButton.Name = "quickFileSaveButton";
            this.quickFileSaveButton.Size = new System.Drawing.Size(114, 48);
            this.quickFileSaveButton.TabIndex = 2;
            this.quickFileSaveButton.Text = "レース結果情報\r\n（ファイル保存のみ）";
            this.quickFileSaveButton.UseVisualStyleBackColor = true;
            this.quickFileSaveButton.Click += new System.EventHandler(this.quickFileSaveButton_Click);
            // 
            // isSetupCheckBox
            // 
            this.isSetupCheckBox.AutoSize = true;
            this.isSetupCheckBox.Location = new System.Drawing.Point(126, 151);
            this.isSetupCheckBox.Name = "isSetupCheckBox";
            this.isSetupCheckBox.Size = new System.Drawing.Size(188, 28);
            this.isSetupCheckBox.TabIndex = 3;
            this.isSetupCheckBox.Text = "初期化して一からデータを作成する\r\n（２時間近くかかる場合があります）";
            this.isSetupCheckBox.UseVisualStyleBackColor = true;
            // 
            // umaGroupBox
            // 
            this.umaGroupBox.Controls.Add(this.umaPostPreset2Button);
            this.umaGroupBox.Controls.Add(this.umaPostPreset1Button);
            this.umaGroupBox.Controls.Add(this.umaAutoPost3Label);
            this.umaGroupBox.Controls.Add(this.umaAutoPost2Label);
            this.umaGroupBox.Controls.Add(this.umaAutoPost1Label);
            this.umaGroupBox.Controls.Add(this.umaPostButton);
            this.umaGroupBox.Controls.Add(this.umaAutoPostFromTextBox);
            this.umaGroupBox.Controls.Add(this.isUmaAutoPostCheckBox);
            this.umaGroupBox.Location = new System.Drawing.Point(12, 175);
            this.umaGroupBox.Name = "umaGroupBox";
            this.umaGroupBox.Size = new System.Drawing.Size(469, 80);
            this.umaGroupBox.TabIndex = 3;
            this.umaGroupBox.TabStop = false;
            this.umaGroupBox.Text = "馬情報";
            // 
            // umaPostPreset2Button
            // 
            this.umaPostPreset2Button.Location = new System.Drawing.Point(407, 31);
            this.umaPostPreset2Button.Name = "umaPostPreset2Button";
            this.umaPostPreset2Button.Size = new System.Drawing.Size(56, 22);
            this.umaPostPreset2Button.TabIndex = 38;
            this.umaPostPreset2Button.Text = "月 15:00";
            this.umaPostPreset2Button.UseVisualStyleBackColor = true;
            this.umaPostPreset2Button.Click += new System.EventHandler(this.umaPostPreset2Button_Click);
            // 
            // umaPostPreset1Button
            // 
            this.umaPostPreset1Button.Location = new System.Drawing.Point(407, 10);
            this.umaPostPreset1Button.Name = "umaPostPreset1Button";
            this.umaPostPreset1Button.Size = new System.Drawing.Size(56, 22);
            this.umaPostPreset1Button.TabIndex = 37;
            this.umaPostPreset1Button.Text = "木 21:00";
            this.umaPostPreset1Button.UseVisualStyleBackColor = true;
            this.umaPostPreset1Button.Click += new System.EventHandler(this.umaPostPreset1Button_Click);
            // 
            // umaAutoPost3Label
            // 
            this.umaAutoPost3Label.AutoSize = true;
            this.umaAutoPost3Label.Location = new System.Drawing.Point(349, 15);
            this.umaAutoPost3Label.Name = "umaAutoPost3Label";
            this.umaAutoPost3Label.Size = new System.Drawing.Size(52, 12);
            this.umaAutoPost3Label.TabIndex = 36;
            this.umaAutoPost3Label.Text = "プリセット：";
            // 
            // umaAutoPost2Label
            // 
            this.umaAutoPost2Label.AutoSize = true;
            this.umaAutoPost2Label.Location = new System.Drawing.Point(239, 62);
            this.umaAutoPost2Label.Name = "umaAutoPost2Label";
            this.umaAutoPost2Label.Size = new System.Drawing.Size(13, 12);
            this.umaAutoPost2Label.TabIndex = 35;
            this.umaAutoPost2Label.Text = "　";
            // 
            // umaAutoPost1Label
            // 
            this.umaAutoPost1Label.AutoSize = true;
            this.umaAutoPost1Label.Location = new System.Drawing.Point(126, 62);
            this.umaAutoPost1Label.Name = "umaAutoPost1Label";
            this.umaAutoPost1Label.Size = new System.Drawing.Size(107, 12);
            this.umaAutoPost1Label.TabIndex = 34;
            this.umaAutoPost1Label.Text = "次回WEB登録予定：";
            // 
            // umaPostButton
            // 
            this.umaPostButton.Location = new System.Drawing.Point(6, 18);
            this.umaPostButton.Name = "umaPostButton";
            this.umaPostButton.Size = new System.Drawing.Size(114, 48);
            this.umaPostButton.TabIndex = 2;
            this.umaPostButton.Text = "馬情報\r\n（WEB登録）";
            this.umaPostButton.UseVisualStyleBackColor = true;
            this.umaPostButton.Click += new System.EventHandler(this.umaPostButton_Click);
            // 
            // umaAutoPostFromTextBox
            // 
            this.umaAutoPostFromTextBox.Location = new System.Drawing.Point(126, 40);
            this.umaAutoPostFromTextBox.MaxLength = 16;
            this.umaAutoPostFromTextBox.Name = "umaAutoPostFromTextBox";
            this.umaAutoPostFromTextBox.Size = new System.Drawing.Size(100, 19);
            this.umaAutoPostFromTextBox.TabIndex = 32;
            // 
            // isUmaAutoPostCheckBox
            // 
            this.isUmaAutoPostCheckBox.AutoSize = true;
            this.isUmaAutoPostCheckBox.Location = new System.Drawing.Point(126, 18);
            this.isUmaAutoPostCheckBox.Name = "isUmaAutoPostCheckBox";
            this.isUmaAutoPostCheckBox.Size = new System.Drawing.Size(181, 16);
            this.isUmaAutoPostCheckBox.TabIndex = 33;
            this.isUmaAutoPostCheckBox.Text = "自動的に馬情報をWEB登録する";
            this.isUmaAutoPostCheckBox.UseVisualStyleBackColor = true;
            this.isUmaAutoPostCheckBox.CheckedChanged += new System.EventHandler(this.isUmaAutoPostCheckBox_CheckedChanged);
            // 
            // quickGroupBox
            // 
            this.quickGroupBox.Controls.Add(this.quickPostButton);
            this.quickGroupBox.Controls.Add(this.isQuickAutoPostCheckBox);
            this.quickGroupBox.Controls.Add(this.quickAutoPost2Label);
            this.quickGroupBox.Controls.Add(this.quickAutoPost1Label);
            this.quickGroupBox.Controls.Add(this.quickAutoPostToTextBox);
            this.quickGroupBox.Controls.Add(this.quickAutoPost4Label);
            this.quickGroupBox.Controls.Add(this.quickAutoPostIntervalTextBox);
            this.quickGroupBox.Controls.Add(this.quickAutoPost3Label);
            this.quickGroupBox.Location = new System.Drawing.Point(12, 89);
            this.quickGroupBox.Name = "quickGroupBox";
            this.quickGroupBox.Size = new System.Drawing.Size(469, 80);
            this.quickGroupBox.TabIndex = 2;
            this.quickGroupBox.TabStop = false;
            this.quickGroupBox.Text = "レース結果情報";
            // 
            // quickPostButton
            // 
            this.quickPostButton.Location = new System.Drawing.Point(6, 18);
            this.quickPostButton.Name = "quickPostButton";
            this.quickPostButton.Size = new System.Drawing.Size(114, 48);
            this.quickPostButton.TabIndex = 1;
            this.quickPostButton.Text = "レース結果情報\r\n（WEB登録）";
            this.quickPostButton.UseVisualStyleBackColor = true;
            this.quickPostButton.Click += new System.EventHandler(this.quickPostButton_Click);
            // 
            // isQuickAutoPostCheckBox
            // 
            this.isQuickAutoPostCheckBox.AutoSize = true;
            this.isQuickAutoPostCheckBox.Location = new System.Drawing.Point(126, 18);
            this.isQuickAutoPostCheckBox.Name = "isQuickAutoPostCheckBox";
            this.isQuickAutoPostCheckBox.Size = new System.Drawing.Size(279, 16);
            this.isQuickAutoPostCheckBox.TabIndex = 2;
            this.isQuickAutoPostCheckBox.Text = "指定間隔で自動的にレース結果情報をWEB登録する";
            this.isQuickAutoPostCheckBox.UseVisualStyleBackColor = true;
            this.isQuickAutoPostCheckBox.CheckedChanged += new System.EventHandler(this.isQuickAutoPostCheckBox_CheckedChanged);
            // 
            // quickAutoPost2Label
            // 
            this.quickAutoPost2Label.AutoSize = true;
            this.quickAutoPost2Label.Location = new System.Drawing.Point(296, 43);
            this.quickAutoPost2Label.Name = "quickAutoPost2Label";
            this.quickAutoPost2Label.Size = new System.Drawing.Size(41, 12);
            this.quickAutoPost2Label.TabIndex = 24;
            this.quickAutoPost2Label.Text = "分間隔";
            // 
            // quickAutoPost1Label
            // 
            this.quickAutoPost1Label.AutoSize = true;
            this.quickAutoPost1Label.Location = new System.Drawing.Point(232, 43);
            this.quickAutoPost1Label.Name = "quickAutoPost1Label";
            this.quickAutoPost1Label.Size = new System.Drawing.Size(24, 12);
            this.quickAutoPost1Label.TabIndex = 26;
            this.quickAutoPost1Label.Text = "まで";
            // 
            // quickAutoPostToTextBox
            // 
            this.quickAutoPostToTextBox.Location = new System.Drawing.Point(126, 40);
            this.quickAutoPostToTextBox.MaxLength = 16;
            this.quickAutoPostToTextBox.Name = "quickAutoPostToTextBox";
            this.quickAutoPostToTextBox.Size = new System.Drawing.Size(100, 19);
            this.quickAutoPostToTextBox.TabIndex = 3;
            // 
            // quickAutoPost4Label
            // 
            this.quickAutoPost4Label.AutoSize = true;
            this.quickAutoPost4Label.Location = new System.Drawing.Point(234, 62);
            this.quickAutoPost4Label.Name = "quickAutoPost4Label";
            this.quickAutoPost4Label.Size = new System.Drawing.Size(13, 12);
            this.quickAutoPost4Label.TabIndex = 30;
            this.quickAutoPost4Label.Text = "　";
            // 
            // quickAutoPostIntervalTextBox
            // 
            this.quickAutoPostIntervalTextBox.Location = new System.Drawing.Point(262, 40);
            this.quickAutoPostIntervalTextBox.MaxLength = 2;
            this.quickAutoPostIntervalTextBox.Name = "quickAutoPostIntervalTextBox";
            this.quickAutoPostIntervalTextBox.Size = new System.Drawing.Size(28, 19);
            this.quickAutoPostIntervalTextBox.TabIndex = 4;
            // 
            // quickAutoPost3Label
            // 
            this.quickAutoPost3Label.AutoSize = true;
            this.quickAutoPost3Label.Location = new System.Drawing.Point(126, 62);
            this.quickAutoPost3Label.Name = "quickAutoPost3Label";
            this.quickAutoPost3Label.Size = new System.Drawing.Size(107, 12);
            this.quickAutoPost3Label.TabIndex = 29;
            this.quickAutoPost3Label.Text = "次回WEB登録予定：";
            // 
            // raceGroupBox
            // 
            this.raceGroupBox.Controls.Add(this.raceAutoPost3Label);
            this.raceGroupBox.Controls.Add(this.racePostPreset3Button);
            this.raceGroupBox.Controls.Add(this.racePostPreset2Button);
            this.raceGroupBox.Controls.Add(this.racePostPreset1Button);
            this.raceGroupBox.Controls.Add(this.raceAutoPost2Label);
            this.raceGroupBox.Controls.Add(this.raceAutoPost1Label);
            this.raceGroupBox.Controls.Add(this.raceAutoPostFromTextBox);
            this.raceGroupBox.Controls.Add(this.isRaceAutoPostCheckBox);
            this.raceGroupBox.Controls.Add(this.racePostButton);
            this.raceGroupBox.Location = new System.Drawing.Point(12, 3);
            this.raceGroupBox.Name = "raceGroupBox";
            this.raceGroupBox.Size = new System.Drawing.Size(469, 80);
            this.raceGroupBox.TabIndex = 1;
            this.raceGroupBox.TabStop = false;
            this.raceGroupBox.Text = "出走馬情報";
            // 
            // raceAutoPost3Label
            // 
            this.raceAutoPost3Label.AutoSize = true;
            this.raceAutoPost3Label.Location = new System.Drawing.Point(349, 15);
            this.raceAutoPost3Label.Name = "raceAutoPost3Label";
            this.raceAutoPost3Label.Size = new System.Drawing.Size(52, 12);
            this.raceAutoPost3Label.TabIndex = 35;
            this.raceAutoPost3Label.Text = "プリセット：";
            // 
            // racePostPreset3Button
            // 
            this.racePostPreset3Button.Location = new System.Drawing.Point(407, 52);
            this.racePostPreset3Button.Name = "racePostPreset3Button";
            this.racePostPreset3Button.Size = new System.Drawing.Size(56, 22);
            this.racePostPreset3Button.TabIndex = 34;
            this.racePostPreset3Button.Text = "土 13:00";
            this.racePostPreset3Button.UseVisualStyleBackColor = true;
            this.racePostPreset3Button.Click += new System.EventHandler(this.racePostPreset3Button_Click);
            // 
            // racePostPreset2Button
            // 
            this.racePostPreset2Button.Location = new System.Drawing.Point(407, 31);
            this.racePostPreset2Button.Name = "racePostPreset2Button";
            this.racePostPreset2Button.Size = new System.Drawing.Size(56, 22);
            this.racePostPreset2Button.TabIndex = 33;
            this.racePostPreset2Button.Text = "金 13:00";
            this.racePostPreset2Button.UseVisualStyleBackColor = true;
            this.racePostPreset2Button.Click += new System.EventHandler(this.racePostPreset2Button_Click);
            // 
            // racePostPreset1Button
            // 
            this.racePostPreset1Button.Location = new System.Drawing.Point(407, 10);
            this.racePostPreset1Button.Name = "racePostPreset1Button";
            this.racePostPreset1Button.Size = new System.Drawing.Size(56, 22);
            this.racePostPreset1Button.TabIndex = 32;
            this.racePostPreset1Button.Text = "木 18:00";
            this.racePostPreset1Button.UseVisualStyleBackColor = true;
            this.racePostPreset1Button.Click += new System.EventHandler(this.racePostPreset1Button_Click);
            // 
            // raceAutoPost2Label
            // 
            this.raceAutoPost2Label.AutoSize = true;
            this.raceAutoPost2Label.Location = new System.Drawing.Point(239, 62);
            this.raceAutoPost2Label.Name = "raceAutoPost2Label";
            this.raceAutoPost2Label.Size = new System.Drawing.Size(13, 12);
            this.raceAutoPost2Label.TabIndex = 31;
            this.raceAutoPost2Label.Text = "　";
            // 
            // raceAutoPost1Label
            // 
            this.raceAutoPost1Label.AutoSize = true;
            this.raceAutoPost1Label.Location = new System.Drawing.Point(126, 62);
            this.raceAutoPost1Label.Name = "raceAutoPost1Label";
            this.raceAutoPost1Label.Size = new System.Drawing.Size(107, 12);
            this.raceAutoPost1Label.TabIndex = 31;
            this.raceAutoPost1Label.Text = "次回WEB登録予定：";
            // 
            // raceAutoPostFromTextBox
            // 
            this.raceAutoPostFromTextBox.Location = new System.Drawing.Point(126, 40);
            this.raceAutoPostFromTextBox.MaxLength = 16;
            this.raceAutoPostFromTextBox.Name = "raceAutoPostFromTextBox";
            this.raceAutoPostFromTextBox.Size = new System.Drawing.Size(100, 19);
            this.raceAutoPostFromTextBox.TabIndex = 5;
            // 
            // isRaceAutoPostCheckBox
            // 
            this.isRaceAutoPostCheckBox.AutoSize = true;
            this.isRaceAutoPostCheckBox.Location = new System.Drawing.Point(126, 18);
            this.isRaceAutoPostCheckBox.Name = "isRaceAutoPostCheckBox";
            this.isRaceAutoPostCheckBox.Size = new System.Drawing.Size(205, 16);
            this.isRaceAutoPostCheckBox.TabIndex = 31;
            this.isRaceAutoPostCheckBox.Text = "自動的に出走馬情報をWEB登録する";
            this.isRaceAutoPostCheckBox.UseVisualStyleBackColor = true;
            this.isRaceAutoPostCheckBox.CheckedChanged += new System.EventHandler(this.isRaceAutoPostCheckBox_CheckedChanged);
            // 
            // racePostButton
            // 
            this.racePostButton.Location = new System.Drawing.Point(6, 18);
            this.racePostButton.Name = "racePostButton";
            this.racePostButton.Size = new System.Drawing.Size(114, 48);
            this.racePostButton.TabIndex = 1;
            this.racePostButton.Text = "出走馬情報\r\n（WEB登録）";
            this.racePostButton.UseVisualStyleBackColor = true;
            this.racePostButton.Click += new System.EventHandler(this.racePostButton_Click);
            // 
            // axJVLink
            // 
            this.axJVLink.Enabled = true;
            this.axJVLink.Location = new System.Drawing.Point(457, -14);
            this.axJVLink.Name = "axJVLink";
            this.axJVLink.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axJVLink.OcxState")));
            this.axJVLink.Size = new System.Drawing.Size(192, 192);
            this.axJVLink.TabIndex = 0;
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
            this.mainMenuStrip.Size = new System.Drawing.Size(484, 26);
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
            this.readMeToolStripMenuItem.Text = "リリース内容";
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
            this.ClientSize = new System.Drawing.Size(484, 308);
            this.Controls.Add(this.mainToolStripContainer);
            this.Name = "MainForm";
            this.Text = "JV-Relay";
            this.mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.mainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.TopToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ResumeLayout(false);
            this.mainToolStripContainer.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.debugGroupBox.ResumeLayout(false);
            this.debugGroupBox.PerformLayout();
            this.umaGroupBox.ResumeLayout(false);
            this.umaGroupBox.PerformLayout();
            this.quickGroupBox.ResumeLayout(false);
            this.quickGroupBox.PerformLayout();
            this.raceGroupBox.ResumeLayout(false);
            this.raceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axJVLink)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
        private AxJVDTLabLib.AxJVLink axJVLink;
        private System.Windows.Forms.Button quickFileSaveButton;
        private System.Windows.Forms.Button raceFileSaveButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar mainToolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBoxToolStripMenuItem;
        private System.Windows.Forms.Button quickPostButton;
        private System.Windows.Forms.Button racePostButton;
        private System.Windows.Forms.TextBox umaFromTextBox;
        private System.Windows.Forms.Button umaFileSaveButton;
        private System.ComponentModel.BackgroundWorker mainBackgroundWorker;
        private System.Windows.Forms.CheckBox isSetupCheckBox;
        private System.Windows.Forms.TextBox quickAutoPostIntervalTextBox;
        private System.Windows.Forms.TextBox quickAutoPostToTextBox;
        private System.Windows.Forms.Label quickAutoPost1Label;
        private System.Windows.Forms.Label quickAutoPost2Label;
        private System.Windows.Forms.CheckBox isQuickAutoPostCheckBox;
        private System.Windows.Forms.Label quickAutoPost4Label;
        private System.Windows.Forms.Label quickAutoPost3Label;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.GroupBox raceGroupBox;
        private System.Windows.Forms.GroupBox debugGroupBox;
        private System.Windows.Forms.GroupBox umaGroupBox;
        private System.Windows.Forms.GroupBox quickGroupBox;
        private System.Windows.Forms.CheckBox isRaceAutoPostCheckBox;
        private System.Windows.Forms.TextBox raceAutoPostFromTextBox;
        private System.Windows.Forms.Label raceAutoPost2Label;
        private System.Windows.Forms.Label raceAutoPost1Label;
        private System.Windows.Forms.Button umaPostButton;
        private System.Windows.Forms.Label umaAutoPost1Label;
        private System.Windows.Forms.TextBox umaAutoPostFromTextBox;
        private System.Windows.Forms.CheckBox isUmaAutoPostCheckBox;
        private System.Windows.Forms.Label umaAutoPost2Label;
        private System.Windows.Forms.Label raceAutoPost3Label;
        private System.Windows.Forms.Button racePostPreset3Button;
        private System.Windows.Forms.Button racePostPreset2Button;
        private System.Windows.Forms.Button racePostPreset1Button;
        private System.Windows.Forms.Button umaPostPreset2Button;
        private System.Windows.Forms.Button umaPostPreset1Button;
        private System.Windows.Forms.Label umaAutoPost3Label;
        private System.Windows.Forms.Label quickDaysLabel;
        private System.Windows.Forms.TextBox quickDaysTextBox;
        private System.Windows.Forms.ToolStripMenuItem readMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator helpToolStripSeparator;
        private System.Windows.Forms.Label raceWeekLabel;
        private System.Windows.Forms.ComboBox raceWeekComboBox;
        private System.Windows.Forms.CheckBox isNextYearCheckBox;
    }
}

