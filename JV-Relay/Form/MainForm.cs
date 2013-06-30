using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace JVRelay
{
    public partial class MainForm : Form
    {
        #region privateフィールド
        private System.Windows.Forms.Timer autoPostTimer = new System.Windows.Forms.Timer();
        #endregion

        #region プロパティ
        /// <summary>
        /// JVRelayファイル名
        /// </summary>
        public string JVRelayFileName { get; set; }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // 初期化
            Initialize();
        }

        /// <summary>
        /// exitToolStripMenuItem押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// optionToolStripMenuItem押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionForm f = new OptionForm();
            if (f.ShowDialog() == DialogResult.Cancel)
            {

            }
        }

        /// <summary>
        /// readMeToolStripMenuItem押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        /// <summary>
        /// aboutBoxToolStripMenuItem押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm f = new AboutBoxForm();
            f.ShowDialog();
        }

        /// <summary>
        /// storageButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void storageButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eSTORE;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.ThisWeek;
            JVRelayClass.FromDate = DateTime.Today.AddDays(-7).ToString("yyyyMMdd");
            JVRelayClass.ToDate = DateTime.Today.ToString("yyyyMMdd");
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// storagePostButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void storagePostButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }
            if (SettingsClass.Setting.IsPost == false)
            {
                MessageBox.Show("WEB登録の設定が無効です。" + Environment.NewLine + "[ツール]-[オプション]からWEB登録に必要な設定を行ってください。",
                    "実行エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eSTORE;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.ThisWeek;
            JVRelayClass.FromDate = DateTime.Today.AddDays(-7).ToString("yyyyMMdd");
            JVRelayClass.ToDate = DateTime.Today.ToString("yyyyMMdd");
            JVRelayClass.IsSaveFile = false;
            JVRelayClass.IsPostFile = true;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// realTimeButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realTimeButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eSPOT;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.Normal;
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// realTimePostButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realTimePostButton_Click(object sender, EventArgs e)
        {
            if (isAutoPostCheckBox.Checked == true)
            {
                if (DateTime.Now.AddMilliseconds(autoPostTimer.Interval).CompareTo(DateTime.Parse(autoPostToTextBox.Text)) > 0)
                {
                    autoPostTimer.Tick -= new EventHandler(realTimePostButton_Click);
                    autoPostTimer.Enabled = false;
                    autoPost4Label.Text = "---";
                }
                else
                {
                    autoPost4Label.Text = DateTime.Now.AddMilliseconds(autoPostTimer.Interval).ToString("yyyy/MM/dd HH:mm:ss頃");
                }
            }
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }
            if (SettingsClass.Setting.IsPost == false)
            {
                MessageBox.Show("WEB登録の設定が無効です。" + Environment.NewLine + "[ツール]-[オプション]からWEB登録に必要な設定を行ってください。",
                    "実行エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eSPOT;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.Normal;
            JVRelayClass.IsSaveFile = false;
            JVRelayClass.IsPostFile = true;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 自動POST設定値変更イベントハンドラ
        /// </summary>
        private void autoPostSetting_Changed(object sender, EventArgs e)
        {
            if (isAutoPostCheckBox.Checked == true)
            {
                DateTime toDateTime;
                if (DateTime.TryParse(autoPostToTextBox.Text, out toDateTime) == false)
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > toDateTime.CompareTo(DateTime.Now))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isAutoPostCheckBox.Checked = false;
                    return;
                }

                Int32 interval;
                if (Int32.TryParse(autoPostIntervalTextBox.Text, out interval) == false)
                {
                    MessageBox.Show("有効な間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > interval)
                {
                    MessageBox.Show("有効な間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isAutoPostCheckBox.Checked = false;
                    return;
                }
                if (DateTime.Now.AddMinutes(interval).CompareTo(DateTime.Parse(autoPostToTextBox.Text)) > 0)
                {
                    MessageBox.Show("有効な日時、間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isAutoPostCheckBox.Checked = false;
                    return;
                }
                autoPostTimer.Tick += new EventHandler(realTimePostButton_Click);
                autoPostTimer.Interval = interval * 60 * 1000;
                autoPostTimer.Enabled = true;
                autoPost4Label.Text = DateTime.Now.AddMilliseconds(autoPostTimer.Interval).ToString("yyyy/MM/dd HH:mm:ss頃");
            }
            else
            {
                autoPostTimer.Tick -= new EventHandler(realTimePostButton_Click);
                autoPostTimer.Enabled = false;
                autoPost4Label.Text = "---";
            }
        }

        /// <summary>
        /// customStorageButtonボタン押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customStorageButton_Click(object sender, EventArgs e)
        {
            // TODO
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=testdb.db;Version=3;";
            conn.Open();
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "CREATE TABLE Test (id integer primary key AUTOINCREMENT, text varchar(100))";
            command.ExecuteNonQuery();

            command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Test (text) VALUES (@1)";
            SQLiteParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@1";
            parameter.Value = "あいうえお";
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();

            return;

            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }
            
            DateTime fromDate;
            DateTime toDate;
            string dataSpec;

            #region 入力値
            if (raceRadioButton.Checked)
            {
                dataSpec = JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1);
            }
            else if (diffRadioButton.Checked)
            {
                dataSpec = JVRelayClass.eJVDataSpec.eDIFF.ToString().Substring(1);
            }
            else if (boldRadioButton.Checked)
            {
                dataSpec = JVRelayClass.eJVDataSpec.eBLOD.ToString().Substring(1);
            }
            else if (hoyuRadioButton.Checked)
            {
                dataSpec = JVRelayClass.eJVDataSpec.eHOYU.ToString().Substring(1);
            }
            else
            {
                MessageBox.Show("有効な情報を選択してください。",
                    "入力値エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (8 == fromTextBox.Text.Length)
            {
                string s = string.Format("{0}/{1}/{2}", fromTextBox.Text.Substring(0, 4), fromTextBox.Text.Substring(4, 2), fromTextBox.Text.Substring(6, 2));
                if (!DateTime.TryParse(s, out fromDate))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("有効な日時を入力してください。",
                    "入力値エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (8 == toTextBox.Text.Length)
            {
                string s = string.Format("{0}/{1}/{2}", toTextBox.Text.Substring(0, 4), toTextBox.Text.Substring(4, 2), toTextBox.Text.Substring(6, 2));
                if (!DateTime.TryParse(s, out toDate))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                toDate = DateTime.Today;
            }
            #endregion

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eSTORE;
            JVRelayClass.JVDataSpec = dataSpec;
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.SetupSkipDialog;
            JVRelayClass.FromDate = fromDate.ToString("yyyyMMdd");
            JVRelayClass.ToDate = toDate.ToString("yyyyMMdd");
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// mainBackgroundWorker実行イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eSPOT)
            {
                JVRTRelay();
            }
            else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eSTORE)
            {
                JVRelay();
            }
        }

        /// <summary>
        /// mainBackgroundWorker進捗表示イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState is JVRelayClass.ProgressUserStateClass)
            {
                JVRelayClass.ProgressUserStateClass state = (JVRelayClass.ProgressUserStateClass)e.UserState;
                if (0 == state.Maxinum)
                {
                    mainToolStripProgressBar.Value = 0;
                }
                else
                {
                    mainToolStripProgressBar.Value = (int)(state.Value / (double)state.Maxinum * 100);
                }

                mainToolStripStatusLabel.Text = state.Text + string.Format("({0}/{1})", state.Value, state.Maxinum);
            }
        }

        /// <summary>
        /// mainBackgroundWorker完了イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (JVRelayClass.IsSaveFile)
            {
                if (JVRelayClass.ReadCount > 0)
                {
                    using (SaveFileDialog dlg = new SaveFileDialog())
                    {
                        dlg.FileName = JVRelayFileName;
                        dlg.Filter = "CSVファイル(*csv)|*.csv";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            FileSystem.WriteAllText(dlg.FileName, JVRelayClass.Output.ToString(), false, System.Text.Encoding.GetEncoding("Shift-JIS"));
                        }
                    }
                }
            }

            if (JVRelayClass.IsPostFile)
            {
                bool isError;
                string errorMessage;
                if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eSPOT)
                {
                    WebUtilityClass.HttpPostJVRTRelay(out isError, out errorMessage);
                    if (isError == true)
                    {
                        mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
                        mainToolStripStatusLabel.Text = errorMessage;
                        return;
                    }
                }
                else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eSTORE)
                {
                    WebUtilityClass.HttpPostJVRelay(out isError, out errorMessage);
                    if (isError == true)
                    {
                        mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
                        mainToolStripStatusLabel.Text = errorMessage;
                        return;
                    }
                }
            }

            mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
            mainToolStripStatusLabel.Text = "完了 " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            // JVRelay初期化
            JVRelayClass.Initialize(axJVLink, mainBackgroundWorker);

            fromTextBox.Text = DateTime.Today.AddYears(-1).ToString("yyyy") + "0101";
            autoPostToTextBox.Text = DateTime.Now.AddHours(3).ToString("yyyy/MM/dd HH:mm");
            autoPostIntervalTextBox.Text = "10";
        }

        /// <summary>
        /// JVRelay
        /// </summary>
        public void JVRelay()
        {
            int nRet = -1;
            int readCount = 0;
            int downloadCount = 0;
            string lastFileTimeStamp = "";

            JVRelayClass.ProgressUserState.Value = 0;
            JVRelayClass.ProgressUserState.Text = "";
            mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

            JVRelayClass.ReadCount = 0;
            JVRelayClass.DownloadCount = 0;
            JVRelayClass.Output = new StringBuilder();

            nRet = axJVLink.JVOpen(JVRelayClass.JVDataSpec, JVRelayClass.FromDate + "000000", JVRelayClass.Option, ref readCount, ref downloadCount, out lastFileTimeStamp);
            JVRelayClass.ReadCount += readCount;
            JVRelayClass.DownloadCount += downloadCount;
            JVRelayClass.LastFileTimestamp = lastFileTimeStamp;

            if (0 == nRet)
            {
                JVRelayClass.ProgressUserState.Maxinum = JVRelayClass.DownloadCount;

                do
                {
                    nRet = axJVLink.JVStatus();

                    // エラー発生
                    if (nRet < 0)
                    {
                        mainToolStripStatusLabel.Text = "エラー発生";

                        break;
                    }
                    else if (nRet == JVRelayClass.DownloadCount)
                    {
                        JVRelayClass.ProgressUserState.Value = nRet;
                        JVRelayClass.ProgressUserState.Text = "ダウンロード完了";
                        mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

                        //JVReading処理
                        JVRelayClass.JVReading(JVRelayClass.ToDate);
                    }
                    else
                    {
                        JVRelayClass.ProgressUserState.Value = nRet;
                        JVRelayClass.ProgressUserState.Text = "ダウンロード中...";
                        mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

                        System.Threading.Thread.Sleep(100);
                    }
                } while (nRet < JVRelayClass.DownloadCount);

                // JVClosing処理
                JVRelayClass.JVClosing();


                // JVRelayファイル名の設定
                if (JVRelayClass.JVDataSpec != JVRelayClass.JVDataSpec)
                {
                    JVRelayFileName = "JVStore_" + JVRelayClass.JVDataSpec + "_" + JVRelayClass.FromDate + "-" + JVRelayClass.ToDate;
                    JVRelayFileName += ".csv";
                }
                else
                {
                    JVRelayFileName = "JVStore_" + JVRelayClass.FromDate + "-" + JVRelayClass.ToDate;
                    JVRelayFileName += ".csv";
                }
            }
        }

        /// <summary>
        /// JVRTRelay
        /// </summary>
        public void JVRTRelay()
        {
            int nRet;
            const int nPrev = -5;
            List<string> sRTRelay = new List<string>();

            JVRelayClass.ProgressUserState.Value = 0;
            JVRelayClass.ProgressUserState.Text = "";
            mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

            JVRelayClass.ReadCount = 0;
            JVRelayClass.DownloadCount = 0;
            JVRelayClass.Output = new StringBuilder();
            JVRelayClass.ProgressUserState.Maxinum = nPrev * -1;

            // 指定日数分遡ってデータを取得
            for (int i = 0; i >= nPrev; i--)
            {
                string targetDate = DateTime.Today.AddDays(i).ToString("yyyyMMdd");
                nRet = axJVLink.JVRTOpen(JVRelayClass.JVDataSpec, targetDate);
                JVRelayClass.ReadCount += 1;
                JVRelayClass.DownloadCount += 1;
                JVRelayClass.LastFileTimestamp = "";

                JVRelayClass.ProgressUserState.Value = i * -1;
                JVRelayClass.ProgressUserState.Text = "データ読み込み中...";
                mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

                if (0 == nRet)
                {
                    sRTRelay.Add(targetDate);

                    //JVReading処理
                    JVRelayClass.JVReading(targetDate);
                }

                // JVClosing処理
                JVRelayClass.JVClosing();
            }

            //sslMain.Text = "データ読み込み完了";
            JVRelayClass.ProgressUserState.Value = JVRelayClass.ProgressUserState.Maxinum;
            JVRelayClass.ProgressUserState.Text = "データ読み込み完了";
            mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

            if (sRTRelay.Count > 0)
            {
                // JVRTRelayファイル名の設定
                JVRelayFileName = "JVSpot_";
                bool bFileNameFirst = false;
                sRTRelay.Sort();
                for (int i = 0; i < sRTRelay.Count; i++)
                {
                    if (!bFileNameFirst)
                    {
                        JVRelayFileName += sRTRelay[i];
                        bFileNameFirst = true;
                    }
                    else
                    {
                        if (i == sRTRelay.Count - 1)
                        {
                            JVRelayFileName += "-" + sRTRelay[i].Substring(6, 2);
                        }
                    }
                }
                JVRelayFileName += ".csv";
            }
        }
        #endregion
    }
}
