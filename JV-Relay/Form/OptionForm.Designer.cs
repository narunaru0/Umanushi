namespace JVRelay
{
    partial class OptionForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.postGroupBox = new System.Windows.Forms.GroupBox();
            this.postPasswordTextBox = new System.Windows.Forms.TextBox();
            this.postPasswordLabel = new System.Windows.Forms.Label();
            this.postUserNameTextBox = new System.Windows.Forms.TextBox();
            this.postUserNameLabel = new System.Windows.Forms.Label();
            this.isPostCheckBox = new System.Windows.Forms.CheckBox();
            this.postGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(211, 118);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 21);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(292, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 21);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.Text = "キャンセル";
            // 
            // postGroupBox
            // 
            this.postGroupBox.Controls.Add(this.postPasswordTextBox);
            this.postGroupBox.Controls.Add(this.postPasswordLabel);
            this.postGroupBox.Controls.Add(this.postUserNameTextBox);
            this.postGroupBox.Controls.Add(this.postUserNameLabel);
            this.postGroupBox.Controls.Add(this.isPostCheckBox);
            this.postGroupBox.Location = new System.Drawing.Point(12, 12);
            this.postGroupBox.Name = "postGroupBox";
            this.postGroupBox.Size = new System.Drawing.Size(355, 96);
            this.postGroupBox.TabIndex = 29;
            this.postGroupBox.TabStop = false;
            this.postGroupBox.Text = "POST転送設定";
            // 
            // postPasswordTextBox
            // 
            this.postPasswordTextBox.Location = new System.Drawing.Point(106, 65);
            this.postPasswordTextBox.Name = "postPasswordTextBox";
            this.postPasswordTextBox.Size = new System.Drawing.Size(128, 19);
            this.postPasswordTextBox.TabIndex = 33;
            // 
            // postPasswordLabel
            // 
            this.postPasswordLabel.AutoSize = true;
            this.postPasswordLabel.Location = new System.Drawing.Point(6, 68);
            this.postPasswordLabel.Name = "postPasswordLabel";
            this.postPasswordLabel.Size = new System.Drawing.Size(58, 12);
            this.postPasswordLabel.TabIndex = 33;
            this.postPasswordLabel.Text = "パスワード：";
            // 
            // postUserNameTextBox
            // 
            this.postUserNameTextBox.Location = new System.Drawing.Point(106, 40);
            this.postUserNameTextBox.Name = "postUserNameTextBox";
            this.postUserNameTextBox.Size = new System.Drawing.Size(128, 19);
            this.postUserNameTextBox.TabIndex = 32;
            // 
            // postUserNameLabel
            // 
            this.postUserNameLabel.AutoSize = true;
            this.postUserNameLabel.Location = new System.Drawing.Point(6, 43);
            this.postUserNameLabel.Name = "postUserNameLabel";
            this.postUserNameLabel.Size = new System.Drawing.Size(63, 12);
            this.postUserNameLabel.TabIndex = 31;
            this.postUserNameLabel.Text = "ユーザー名：";
            // 
            // isPostCheckBox
            // 
            this.isPostCheckBox.AutoSize = true;
            this.isPostCheckBox.Location = new System.Drawing.Point(8, 18);
            this.isPostCheckBox.Name = "isPostCheckBox";
            this.isPostCheckBox.Size = new System.Drawing.Size(175, 16);
            this.isPostCheckBox.TabIndex = 30;
            this.isPostCheckBox.Text = "うまぬしくん情報をWEB登録する";
            this.isPostCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 151);
            this.Controls.Add(this.postGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "OptionForm";
            this.Text = "オプション";
            this.postGroupBox.ResumeLayout(false);
            this.postGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox postGroupBox;
        private System.Windows.Forms.CheckBox isPostCheckBox;
        private System.Windows.Forms.Label postPasswordLabel;
        private System.Windows.Forms.TextBox postUserNameTextBox;
        private System.Windows.Forms.Label postUserNameLabel;
        private System.Windows.Forms.TextBox postPasswordTextBox;
    }
}