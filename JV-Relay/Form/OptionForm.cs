using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVRelay
{
    /// <summary>
    /// オプション画面
    /// </summary>
    public partial class OptionForm : Form
    {
        #region プロパティ
        /// <summary>
        /// POST転送使用
        /// </summary>
        public bool IsPost
        {
            get { return this.isPostCheckBox.Checked; }
            set { this.isPostCheckBox.Checked = value; }
        }

        /// <summary>
        /// POSTユーザー名
        /// </summary>
        public string PostUserName
        {
            get { return this.postUserNameTextBox.Text; }
            set { this.postUserNameTextBox.Text = value; }
        }

        /// <summary>
        /// POSTパスワード
        /// </summary>
        public string PostPassword
        {
            get { return this.postPasswordTextBox.Text; }
            set { this.postPasswordTextBox.Text = value; }
        }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OptionForm()
        {
            InitializeComponent();

            // 初期化処理
            Initialize();
        }

        /// <summary>
        /// okButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            // 入力チェック処理
            if (ChkInput())
            {
                SettingsClass.Setting.IsPost = this.IsPost;
                SettingsClass.Setting.PostUserName = this.PostUserName;
                SettingsClass.Setting.PostPassword = this.PostPassword;

                // 設定ファイル保存
                SettingsClass.Save();
            }
            else
            {
                // 入力無効
                this.DialogResult = DialogResult.None;
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Initialize()
        {
            // 初期値を設定する
            this.IsPost = SettingsClass.Setting.IsPost;
            this.PostUserName = SettingsClass.Setting.PostUserName;
            this.PostPassword = SettingsClass.Setting.PostPassword;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns>true：正常終了、false：エラー終了</returns>
        private bool ChkInput()
        {
            if (this.IsPost)
            {
                #region ユーザー名
                if (string.IsNullOrEmpty(this.PostUserName)==true)
                {
                    MessageBox.Show("ユーザー名を入力して下さい。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                #endregion
            }

            return true;
        } 
        #endregion
    }
}
