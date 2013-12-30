namespace NushiPost
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.waitLabel = new System.Windows.Forms.Label();
            this.waitComboBox = new System.Windows.Forms.ComboBox();
            this.postButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toLabel = new System.Windows.Forms.Label();
            this.bodyTextBox = new NushiPost.MyTextBox();
            this.subjectTextBox = new NushiPost.MyTextBox();
            this.passwordTextBox = new NushiPost.MyTextBox();
            this.nameTextBox = new NushiPost.MyTextBox();
            this.toTextBox = new NushiPost.MyTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(630, 411);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bodyTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 316);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.waitLabel);
            this.panel4.Controls.Add(this.waitComboBox);
            this.panel4.Controls.Add(this.postButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 368);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(453, 43);
            this.panel4.TabIndex = 2;
            // 
            // waitLabel
            // 
            this.waitLabel.AutoSize = true;
            this.waitLabel.Location = new System.Drawing.Point(116, 12);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(103, 12);
            this.waitLabel.TabIndex = 5;
            this.waitLabel.Text = "連続送信間隔(秒)：";
            // 
            // waitComboBox
            // 
            this.waitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waitComboBox.FormattingEnabled = true;
            this.waitComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.waitComboBox.Location = new System.Drawing.Point(225, 9);
            this.waitComboBox.Name = "waitComboBox";
            this.waitComboBox.Size = new System.Drawing.Size(48, 20);
            this.waitComboBox.TabIndex = 1;
            // 
            // postButton
            // 
            this.postButton.Location = new System.Drawing.Point(13, 7);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(75, 23);
            this.postButton.TabIndex = 0;
            this.postButton.Text = "送信";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.subjectTextBox);
            this.panel1.Controls.Add(this.subjectLabel);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 52);
            this.panel1.TabIndex = 0;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(5, 32);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(35, 12);
            this.subjectLabel.TabIndex = 4;
            this.subjectLabel.Text = "題名：";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(188, 7);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(58, 12);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "パスワード：";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 7);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(58, 12);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "うまぬし名：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 33);
            this.panel3.TabIndex = 0;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(56, 7);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(53, 12);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "宛先リスト";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTextBox.Location = new System.Drawing.Point(0, 0);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bodyTextBox.Size = new System.Drawing.Size(453, 316);
            this.bodyTextBox.TabIndex = 0;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(69, 29);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(367, 19);
            this.subjectTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(252, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 19);
            this.passwordTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(69, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 19);
            this.nameTextBox.TabIndex = 1;
            // 
            // toTextBox
            // 
            this.toTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toTextBox.Location = new System.Drawing.Point(0, 33);
            this.toTextBox.Multiline = true;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.toTextBox.Size = new System.Drawing.Size(173, 378);
            this.toTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 411);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "NushiPost";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private MyTextBox subjectTextBox;
        private System.Windows.Forms.Label subjectLabel;
        private MyTextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private MyTextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label toLabel;
        private MyTextBox toTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button postButton;
        private MyTextBox bodyTextBox;
        private System.Windows.Forms.Label waitLabel;
        private System.Windows.Forms.ComboBox waitComboBox;
    }
}

