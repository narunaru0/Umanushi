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
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Data;

namespace JVRelay
{
    public partial class MainForm : Form
    {
        #region privateフィールド
        private System.Windows.Forms.Timer quickAutoPostTimer = new System.Windows.Forms.Timer();
        private WakeUPTimer raceWakeUpTimer = new WakeUPTimer("raceWakeUpTimer");
        private WakeUPTimer umaWakeUpTimer = new WakeUPTimer("umaWakeUpTimer");
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

            try
            {
                // 初期化
                Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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
            string readMeFile = Path.Combine(Application.StartupPath, "ReadMe.txt");
            if (FileSystem.FileExists(readMeFile) == true)
            {
                Process.Start(readMeFile);
            }
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
        /// raceFileSaveButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void raceFileSaveButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }

            int fromInterval = (int)raceWeekComboBox.SelectedValue - (int)DateTime.Today.DayOfWeek;
            if (fromInterval > 0)
            {
                fromInterval -= 7;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eRACE;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.ThisWeek;
            JVRelayClass.FromDate = DateTime.Today.AddDays(fromInterval).ToString("yyyyMMdd");
            JVRelayClass.ToDate = DateTime.Today.ToString("yyyyMMdd");
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// racePostButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void racePostButton_Click(object sender, EventArgs e)
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
            if (isRaceAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は設定を解除
                isRaceAutoPostCheckBox.Checked = false;
            }

            int fromInterval = (int)raceWeekComboBox.SelectedValue - (int)DateTime.Today.DayOfWeek;
            if (fromInterval > 0)
            {
                fromInterval -= 7;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eRACE;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.ThisWeek;
            JVRelayClass.FromDate = DateTime.Today.AddDays(fromInterval).ToString("yyyyMMdd");
            JVRelayClass.ToDate = DateTime.Today.ToString("yyyyMMdd");
            JVRelayClass.IsSaveFile = false;
            JVRelayClass.IsPostFile = true;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// racePostPreset1Button押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void racePostPreset1Button_Click(object sender, EventArgs e)
        {
            if (isRaceAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は一旦設定を解除
                isRaceAutoPostCheckBox.Checked = false;
            }

            // 次の木18:00にセット
            int fromInterval = DayOfWeek.Thursday - DateTime.Today.DayOfWeek;
            if (fromInterval < 0)
            {
                fromInterval += 7;
            }
            raceAutoPostFromTextBox.Text = DateTime.Today.AddDays(fromInterval).AddHours(18).ToString("yyyy/MM/dd HH:mm");
            isRaceAutoPostCheckBox.Checked = true;
        }

        /// <summary>
        /// racePostPreset2Button押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void racePostPreset2Button_Click(object sender, EventArgs e)
        {
            if (isRaceAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は一旦設定を解除
                isRaceAutoPostCheckBox.Checked = false;
            }

            // 次の金13:00にセット
            int fromInterval = DayOfWeek.Friday - DateTime.Today.DayOfWeek;
            if (fromInterval < 0)
            {
                fromInterval += 7;
            }
            raceAutoPostFromTextBox.Text = DateTime.Today.AddDays(fromInterval).AddHours(13).ToString("yyyy/MM/dd HH:mm");
            isRaceAutoPostCheckBox.Checked = true;
        }

        /// <summary>
        /// racePostPreset3Button押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void racePostPreset3Button_Click(object sender, EventArgs e)
        {
            if (isRaceAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は一旦設定を解除
                isRaceAutoPostCheckBox.Checked = false;
            }

            // 次の土13:00にセット
            int fromInterval = DayOfWeek.Saturday - DateTime.Today.DayOfWeek;
            if (fromInterval < 0)
            {
                fromInterval += 7;
            }
            raceAutoPostFromTextBox.Text = DateTime.Today.AddDays(fromInterval).AddHours(13).ToString("yyyy/MM/dd HH:mm");
            isRaceAutoPostCheckBox.Checked = true;
        }

        /// <summary>
        /// isRaceAutoPostCheckBox変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isRaceAutoPostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isRaceAutoPostCheckBox.Checked == true)
            {
                DateTime fromDateTime;
                if (DateTime.TryParse(raceAutoPostFromTextBox.Text, out fromDateTime) == false)
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isRaceAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > fromDateTime.CompareTo(DateTime.Now))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isRaceAutoPostCheckBox.Checked = false;
                    return;
                }

                raceWakeUpTimer.Woken += new EventHandler(racePostButton_Click);
                raceWakeUpTimer.SetWakeUpTime(fromDateTime.ToUniversalTime());
                raceAutoPost2Label.Text = fromDateTime.ToString("yyyy/MM/dd HH:mm頃");
            }
            else
            {
                raceWakeUpTimer.Woken -= new EventHandler(racePostButton_Click);
                raceAutoPost2Label.Text = "---";
                raceWakeUpTimer = new WakeUPTimer("raceWakeUpTimer");
            }
        }

        /// <summary>
        /// quickFileSaveButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quickFileSaveButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eQUICK;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.Normal;
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// quickPostButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quickPostButton_Click(object sender, EventArgs e)
        {
            if (isQuickAutoPostCheckBox.Checked == true)
            {
                if (DateTime.Now.AddMilliseconds(quickAutoPostTimer.Interval).CompareTo(DateTime.Parse(quickAutoPostToTextBox.Text)) > 0)
                {
                    quickAutoPostTimer.Tick -= new EventHandler(quickPostButton_Click);
                    quickAutoPostTimer.Enabled = false;
                    quickAutoPost4Label.Text = "---";
                }
                else
                {
                    quickAutoPost4Label.Text = DateTime.Now.AddMilliseconds(quickAutoPostTimer.Interval).ToString("yyyy/MM/dd HH:mm:ss頃");
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
            
            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eQUICK;
            JVRelayClass.JVDataSpec = JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1);
            JVRelayClass.Option = (int)JVRelayClass.eJVOpenFlag.Normal;
            JVRelayClass.IsSaveFile = false;
            JVRelayClass.IsPostFile = true;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// isQuickAutoPostCheckBox変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isQuickAutoPostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isQuickAutoPostCheckBox.Checked == true)
            {
                DateTime toDateTime;
                if (DateTime.TryParse(quickAutoPostToTextBox.Text, out toDateTime) == false)
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuickAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > toDateTime.CompareTo(DateTime.Now))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuickAutoPostCheckBox.Checked = false;
                    return;
                }

                Int32 interval;
                if (Int32.TryParse(quickAutoPostIntervalTextBox.Text, out interval) == false)
                {
                    MessageBox.Show("有効な間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuickAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > interval)
                {
                    MessageBox.Show("有効な間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuickAutoPostCheckBox.Checked = false;
                    return;
                }
                if (DateTime.Now.AddMinutes(interval).CompareTo(DateTime.Parse(quickAutoPostToTextBox.Text)) > 0)
                {
                    MessageBox.Show("有効な日時、間隔(分)を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuickAutoPostCheckBox.Checked = false;
                    return;
                }
                quickAutoPostTimer.Tick += new EventHandler(quickPostButton_Click);
                quickAutoPostTimer.Interval = interval * 60 * 1000;
                quickAutoPostTimer.Enabled = true;
                quickAutoPost4Label.Text = DateTime.Now.AddMilliseconds(quickAutoPostTimer.Interval).ToString("yyyy/MM/dd HH:mm:ss頃");
            }
            else
            {
                quickAutoPostTimer.Tick -= new EventHandler(quickPostButton_Click);
                quickAutoPostTimer.Enabled = false;
                quickAutoPost4Label.Text = "---";
            }
        }

        /// <summary>
        /// umaFileSaveButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void umaFileSaveButton_Click(object sender, EventArgs e)
        {
            if (mainBackgroundWorker.IsBusy == true)
            {
                mainToolStripStatusLabel.Text += "ビジー状態です。";
                return;
            }
            
            DateTime fromDate;
            int option;

            #region 入力値
            if (isSetupCheckBox.Checked == true)
            {
                option = (int)JVRelayClass.eJVOpenFlag.SetupSkipDialog;
                fromDate = new DateTime(DateTime.Today.Year - 3, 1, 1);
            }
            else
            {
                option = (int)JVRelayClass.eJVOpenFlag.Normal;

                if (14 == umaFromTextBox.Text.Length)
                {
                    string s = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                        umaFromTextBox.Text.Substring(0, 4),
                        umaFromTextBox.Text.Substring(4, 2),
                        umaFromTextBox.Text.Substring(6, 2),
                        umaFromTextBox.Text.Substring(8, 2),
                        umaFromTextBox.Text.Substring(10, 2),
                        umaFromTextBox.Text.Substring(12, 2));
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
            }
            #endregion

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eUMA;
            JVRelayClass.JVDataSpec = "RACEDIFF";
            JVRelayClass.Option = option;
            JVRelayClass.FromDate = fromDate.ToString("yyyyMMddHHmmss");
            JVRelayClass.ToDate = "";
            JVRelayClass.IsSaveFile = true;
            JVRelayClass.IsPostFile = false;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// umaPostButton押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void umaPostButton_Click(object sender, EventArgs e)
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
            if (isUmaAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は設定を解除
                isUmaAutoPostCheckBox.Checked = false;
            }

            DateTime fromDate;
            int option;

            #region 入力値
            if (isSetupCheckBox.Checked == true)
            {
                option = (int)JVRelayClass.eJVOpenFlag.SetupSkipDialog;
                fromDate = new DateTime(DateTime.Today.Year - 3, 1, 1);
            }
            else
            {
                option = (int)JVRelayClass.eJVOpenFlag.Normal;

                if (14 == umaFromTextBox.Text.Length)
                {
                    string s = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                        umaFromTextBox.Text.Substring(0, 4),
                        umaFromTextBox.Text.Substring(4, 2),
                        umaFromTextBox.Text.Substring(6, 2),
                        umaFromTextBox.Text.Substring(8, 2),
                        umaFromTextBox.Text.Substring(10, 2),
                        umaFromTextBox.Text.Substring(12, 2));
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
            }
            #endregion

            JVRelayClass.JVDataAccessType = JVRelayClass.eJVDataAccessType.eUMA;
            JVRelayClass.JVDataSpec = "RACEDIFF";
            JVRelayClass.Option = option;
            JVRelayClass.FromDate = fromDate.ToString("yyyyMMddHHmmss");
            JVRelayClass.ToDate = "";
            JVRelayClass.IsSaveFile = false;
            JVRelayClass.IsPostFile = true;
            mainBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// isUmaAutoPostCheckBox変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isUmaAutoPostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isUmaAutoPostCheckBox.Checked == true)
            {
                DateTime fromDateTime;
                if (DateTime.TryParse(umaAutoPostFromTextBox.Text, out fromDateTime) == false)
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isUmaAutoPostCheckBox.Checked = false;
                    return;
                }
                if (0 > fromDateTime.CompareTo(DateTime.Now))
                {
                    MessageBox.Show("有効な日時を入力してください。",
                        "入力値エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isUmaAutoPostCheckBox.Checked = false;
                    return;
                }

                umaWakeUpTimer.Woken += new EventHandler(umaPostButton_Click);
                umaWakeUpTimer.SetWakeUpTime(fromDateTime.ToUniversalTime());
                umaAutoPost2Label.Text = fromDateTime.ToString("yyyy/MM/dd HH:mm頃");
            }
            else
            {
                umaWakeUpTimer.Woken -= new EventHandler(umaPostButton_Click);
                umaAutoPost2Label.Text = "---";
                umaWakeUpTimer = new WakeUPTimer("umaWakeUpTimer");
            }
        }

        /// <summary>
        /// umaPostPreset1Button押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void umaPostPreset1Button_Click(object sender, EventArgs e)
        {
            if (isUmaAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は一旦設定を解除
                isUmaAutoPostCheckBox.Checked = false;
            }

            // 次の木21:00にセット
            int fromInterval = DayOfWeek.Thursday - DateTime.Today.DayOfWeek;
            if (fromInterval < 0)
            {
                fromInterval += 7;
            }
            umaAutoPostFromTextBox.Text = DateTime.Today.AddDays(fromInterval).AddHours(21).ToString("yyyy/MM/dd HH:mm");
            isUmaAutoPostCheckBox.Checked = true;
        }

        /// <summary>
        /// umaPostPreset2Button押下イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void umaPostPreset2Button_Click(object sender, EventArgs e)
        {
            if (isUmaAutoPostCheckBox.Checked == true)
            {
                // 自動POSTの場合は一旦設定を解除
                isUmaAutoPostCheckBox.Checked = false;
            }

            // 次の月15:00にセット
            int fromInterval = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
            if (fromInterval < 0)
            {
                fromInterval += 7;
            }
            umaAutoPostFromTextBox.Text = DateTime.Today.AddDays(fromInterval).AddHours(15).ToString("yyyy/MM/dd HH:mm");
            isUmaAutoPostCheckBox.Checked = true;
        }

        /// <summary>
        /// mainBackgroundWorker実行イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eRACE)
            {
                JVRaceRelay();
            }
            else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eQUICK)
            {
                JVQuickRelay();
            }
            else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eUMA)
            {
                JVUmaRelay();
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
                if (JVRelayClass.Output.Length > 0)
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
                if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eQUICK)
                {
                    WebUtilityClass.HttpPostQuickRelay(out isError, out errorMessage);
                    if (isError == true)
                    {
                        mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
                        mainToolStripStatusLabel.Text = errorMessage;
                        return;
                    }
                }
                else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eRACE)
                {
                    WebUtilityClass.HttpPostRaceRelay(out isError, out errorMessage);
                    if (isError == true)
                    {
                        mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
                        mainToolStripStatusLabel.Text = errorMessage;
                        return;
                    }
                }
                else if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eUMA)
                {
                    WebUtilityClass.HttpPostUmaRelay(out isError, out errorMessage);
                    if (isError == true)
                    {
                        mainToolStripProgressBar.Value = mainToolStripProgressBar.Maximum;
                        mainToolStripStatusLabel.Text = errorMessage;
                        return;
                    }
                }
            }

            if (JVRelayClass.JVDataAccessType == JVRelayClass.eJVDataAccessType.eUMA)
            {
                umaFromTextBox.Text = JVRelayClass.DbTimeStamp;
                isSetupCheckBox.Checked = false;
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

            raceAutoPostFromTextBox.Text = DateTime.Now.AddMinutes(1).ToString("yyyy/MM/dd HH:mm");
            quickAutoPostToTextBox.Text = DateTime.Today.AddHours(17).ToString("yyyy/MM/dd HH:mm");
            quickAutoPostIntervalTextBox.Text = "5";
            quickDaysTextBox.Text = "5";
            umaAutoPostFromTextBox.Text = DateTime.Now.AddMinutes(1).ToString("yyyy/MM/dd HH:mm");
            if (JVRelayClass.DbTimeStamp == "")
            {
                isSetupCheckBox.Checked = true;
            }
            else
            {
                umaFromTextBox.Text = JVRelayClass.DbTimeStamp;
            }

            #region raceWeekComboBox
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("text", typeof(String));
            dt.Columns.Add("value", typeof(Int32));
            dr = dt.NewRow();
            dr["text"] = "月";
            dr["value"] = (int)DayOfWeek.Monday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "火";
            dr["value"] = (int)DayOfWeek.Tuesday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "水";
            dr["value"] = (int)DayOfWeek.Wednesday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "木";
            dr["value"] = (int)DayOfWeek.Thursday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "金";
            dr["value"] = (int)DayOfWeek.Friday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "土";
            dr["value"] = (int)DayOfWeek.Saturday;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["text"] = "日";
            dr["value"] = (int)DayOfWeek.Sunday;
            dt.Rows.Add(dr);

            dt.AcceptChanges();
            raceWeekComboBox.DataSource = dt;
            raceWeekComboBox.DisplayMember = "text";
            raceWeekComboBox.ValueMember = "value";

            raceWeekComboBox.SelectedValue = (int)DayOfWeek.Wednesday;
            #endregion
        }

        /// <summary>
        /// JVRaceRelay
        /// </summary>
        public void JVRaceRelay()
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
                JVRelayFileName = "JVRace_" + JVRelayClass.FromDate + "-" + JVRelayClass.ToDate;
                JVRelayFileName += ".csv";
            }
        }

        /// <summary>
        /// JVQuickRelay
        /// </summary>
        public void JVQuickRelay()
        {
            int nRet;
            int prevDays;
            List<string> sRTRelay = new List<string>();

            JVRelayClass.ProgressUserState.Value = 0;
            JVRelayClass.ProgressUserState.Text = "";
            mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

            prevDays = int.Parse(quickDaysTextBox.Text);

            JVRelayClass.ReadCount = 0;
            JVRelayClass.DownloadCount = 0;
            JVRelayClass.Output = new StringBuilder();
            JVRelayClass.ProgressUserState.Maxinum = prevDays;

            // 指定日数分遡ってデータを取得
            for (int i = 0; i < prevDays; i++)
            {
                string targetDate = DateTime.Today.AddDays(-i).ToString("yyyyMMdd");
                nRet = axJVLink.JVRTOpen(JVRelayClass.JVDataSpec, targetDate);
                JVRelayClass.ReadCount += 1;
                JVRelayClass.DownloadCount += 1;
                JVRelayClass.LastFileTimestamp = "";

                JVRelayClass.ProgressUserState.Value = i + 1;
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

            JVRelayClass.ProgressUserState.Value = JVRelayClass.ProgressUserState.Maxinum;
            JVRelayClass.ProgressUserState.Text = "データ読み込み完了";
            mainBackgroundWorker.ReportProgress(0, JVRelayClass.ProgressUserState);

            if (sRTRelay.Count > 0)
            {
                // JVRTRelayファイル名の設定
                JVRelayFileName = "JVQuick_";
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

        /// <summary>
        /// JVUmaRelay
        /// </summary>
        public void JVUmaRelay()
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
            nRet = axJVLink.JVOpen(JVRelayClass.JVDataSpec, JVRelayClass.FromDate, JVRelayClass.Option, ref readCount, ref downloadCount, out lastFileTimeStamp);

            JVRelayClass.ReadCount += readCount;
            JVRelayClass.DownloadCount += downloadCount;
            if (string.IsNullOrEmpty(lastFileTimeStamp))
            {
                JVRelayClass.LastFileTimestamp = JVRelayClass.DbTimeStamp;
            }
            else
            {
                JVRelayClass.LastFileTimestamp = lastFileTimeStamp;
            }

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

                        // JVUmaReadWriting処理
                        JVRelayClass.JVUmaReadWriting();
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
            }

            // JVUmaReading処理
            JVRelayClass.JVUmaReading();

            // JVRelayファイル名の設定
            JVRelayFileName = "JVUma_" + JVRelayClass.LastFileTimestamp;
            JVRelayFileName += ".csv";
        }
        #endregion
    }
}
