using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace JVRelay
{
    /// <summary>
    /// JVRelayクラス
    /// </summary>
    static class JVRelayClass
    {
        #region 列挙体
        /// <summary>
        /// JVデータアクセスタイプ
        /// </summary>
        public enum eJVDataAccessType
        {
            /// <summary>
            /// レースデータ
            /// </summary>
            eRACE,

            /// <summary>
            /// 速報データ
            /// </summary>
            eQUICK,

            /// <summary>
            /// 馬データ
            /// </summary>
            eUMA,
        }

        /// <summary>
        /// JVデータ種別ID
        /// </summary>
        public enum eJVDataSpec
        {
            /// <summary>
            /// レース情報
            /// </summary>
            eRACE,

            /// <summary>
            /// 蓄積情報
            /// </summary>
            eDIFF,

            /// <summary>
            /// 血統情報
            /// </summary>
            eBLOD,

            /// <summary>
            /// 馬名の意味由来情報
            /// </summary>
            eHOYU,

            /// <summary>
            /// 速報レース情報
            /// </summary>
            e0B12,
        }

        /// <summary>
        /// JVOpen/option値
        /// </summary>
        public enum eJVOpenFlag
        {
            /// <summary>
            /// 通常データ
            /// </summary>
            Normal = 1,

            /// <summary>
            /// 今週データ
            /// </summary>
            ThisWeek = 2,

            /// <summary>
            /// セットアップ
            /// </summary>
            SetupDialog = 3,

            /// <summary>
            /// セットアップ(ダイアログスキップ)
            /// </summary>
            SetupSkipDialog = 4,
        }

        /// <summary>
        /// 出力
        /// </summary>
        public enum eOutput
        {
            /// <summary>
            /// POGDB
            /// </summary>
            Pogdb,

            /// <summary>
            /// うまぬしくん
            /// </summary>
            Umanushi,
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 使用可能フラグ
        /// </summary>
        public static bool IsUse { get; private set; }

        /// <summary>
        /// データベースコネクション
        /// </summary>
        public static SQLiteConnection DbConn { get; private set; }

        /// <summary>
        /// データベースタイムスタンプ
        /// </summary>
        public static string DbTimeStamp { get; set; }

        /// <summary>
        /// JV-Link ActiveX Object
        /// </summary>
        public static AxJVDTLabLib.AxJVLink AxJVLink { get; private set; }

        /// <summary>
        /// JVデータアクセスタイプ
        /// </summary>
        public static eJVDataAccessType JVDataAccessType { get; set; }

        /// <summary>
        /// JVデータ種別ID
        /// </summary>
        public static string JVDataSpec { get; set; }

        /// <summary>
        /// JVOpen/FromDate
        /// </summary>
        public static string FromDate { get; set; }

        /// <summary>
        /// JVOpen/ToDate
        /// </summary>
        public static string ToDate { get; set; }

        /// <summary>
        /// JVOpen/Option
        /// </summary>
        public static int Option { get; set; }

        /// <summary>
        /// JVOpen/ダウンロード件数
        /// </summary>
        public static int DownloadCount { get; set; }

        /// <summary>
        /// JVOpen/読み込み件数
        /// </summary>
        public static int ReadCount { get; set; }

        /// <summary>
        /// JVOpen/最終ファイルタイムスタンプ
        /// </summary>
        public static string LastFileTimestamp { get; set; }

        /// <summary>
        /// 出力文字列
        /// </summary>
        public static StringBuilder Output { get; set; }

        /// <summary>
        /// バックグラウンドワーカー
        /// </summary>
        public static BackgroundWorker MainBackgroundWorker { get; set; }

        /// <summary>
        /// ファイルを保存するか
        /// </summary>
        public static bool IsSaveFile { get; set; }

        /// <summary>
        /// ファイルをPOSTするか
        /// </summary>
        public static bool IsPostFile { get; set; }

        /// <summary>
        /// データ破棄する馬の生年
        /// </summary>
        public static int DiscardBirthYear
        {
            get
            {
                return DateTime.Today.AddYears(-20).Year;
            }
        }
        #endregion

        public static ProgressUserStateClass ProgressUserState = new ProgressUserStateClass();
        public class ProgressUserStateClass
        {
            public int Maxinum;
            public int Value;
            public string Text;
        }

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="axJVLink"></param>
        /// <param name="mainBackgroundWorker"></param>
        public static void Initialize(AxJVDTLabLib.AxJVLink axJVLink, BackgroundWorker mainBackgroundWorker)
        {
            IsUse = false;
            AxJVLink = axJVLink;
            MainBackgroundWorker = mainBackgroundWorker;

            // JVInit:ソフトウェアID
            string sid = "UNKNOWN";

            // データベースコネクション
            DbConn = new SQLiteConnection();
            string dbPath = "";
            if (string.IsNullOrEmpty(SettingsClass.Setting.DebugSqLiteFilePath))
            {
                dbPath = "jvRelay.db";
            }
            else
            {
                dbPath = SettingsClass.Setting.DebugSqLiteFilePath;
            }
            DbConn.ConnectionString = "Data Source=" + dbPath + ";Version=3;";
            DbConn.Open();

            // データベースバージョンアップ処理
            DbVersionUp();

            using (SQLiteCommand command = DbConn.CreateCommand())
            {
                command.CommandText = "SELECT date FROM timestamp ORDER BY date DESC";
                if (command.ExecuteScalar() == null)
                {
                    DbTimeStamp = "";
                }
                else if (command.ExecuteScalar().ToString() == "00000000000000")
                {
                    DbTimeStamp = "";
                }
                else
                {
                    DbTimeStamp = command.ExecuteScalar().ToString();
                }
            }

            //-----------------
            // JVLink初期化
            //-----------------
            if (0 == AxJVLink.JVInit(sid))
            {
                IsUse = true;
            }
        }

        /// <summary>
        /// データベースバージョンアップ処理
        /// </summary>
        private static void DbVersionUp()
        {
            using (SQLiteTransaction tran = DbConn.BeginTransaction())
            {
                using (SQLiteCommand command = DbConn.CreateCommand())
                {
                    command.Transaction = tran;
                    command.CommandText = "SELECT tbl_name FROM sqlite_master WHERE type='table' AND tbl_name='version'";
                    if (command.ExecuteScalar() == null)
                    {
                        // version
                        command.CommandText = "CREATE TABLE version (ver integer primary key, date text)";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO version (ver, date) VALUES (@1, @2)";
                        SQLiteParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "@1";
                        parameter.Value = "1000";
                        command.Parameters.Add(parameter);
                        parameter = command.CreateParameter();
                        parameter.ParameterName = "@2";
                        parameter.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();

                        // timestamp
                        command.CommandText = "CREATE TABLE timestamp (date text primary key)";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO timestamp (date) VALUES (@1)";
                        parameter = command.CreateParameter();
                        parameter.ParameterName = "@1";
                        parameter.Value = "00000000000000";
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();

                        // uma
                        command.CommandText = "CREATE TABLE uma (KettoNum integer primary key, MakeDate text, DelKubun text, RegDate text, DelDate text, BirthYear text, Bamei text, SexCD text, TozaiCD text, ChokyosiRyakusyo text, RuikeiSyutokuHeichi integer, RuikeiSyutokuSyogai integer, RaceCount integer, UmaClass text, RaceDate text, RaceDataKubun text, RaceGradeCD text, RaceSyubetuCD text, RaceKakuteiJyuni text, BeforeUmaClass text, BeforeRaceDate text, BeforeRaceDataKubun text, BeforeRaceGradeCD text, BeforeRaceSyubetuCD text, BeforeRaceKakuteiJyuni text)";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = "SELECT ver FROM version ORDER BY ver DESC";
                    Int32 version = Int32.Parse(command.ExecuteScalar().ToString());
                    switch (version)
                    {
                        case 1001:
                            // バージョンアップ用のコードはここに記述
                            break;
                    }
                }
                tran.Commit();
            }
        }

        /// <summary>
        /// JVReading処理
        /// </summary>
        /// <param name="endDate">終了日</param>
        public static void JVReading(string endDate)
        {
            bool reading = true;
            int nCount = 0;
            object buffObj = new byte[0];
            int buffsize = 110000;
            string endTimeStamp = endDate + "235959";
            string timeStamp;
            string buffname;

            if (JVDataAccessType == eJVDataAccessType.eRACE)
            {
                ProgressUserState.Maxinum = ReadCount;
                ProgressUserState.Value = 0;
                ProgressUserState.Text = "データ読み込み中...";
                MainBackgroundWorker.ReportProgress(0, ProgressUserState);
            }

            do
            {
                //---------------------
                // JVLink読込み処理
                //---------------------
                buffObj = new byte[0];
                int nRet = AxJVLink.JVGets(ref buffObj, buffsize, out buffname);
                timeStamp = AxJVLink.m_CurrentFileTimeStamp;
                byte[] buff = (byte[])buffObj;
                string buffStr = System.Text.Encoding.GetEncoding(932).GetString(buff);

                // 正常
                if (0 < nRet)
                {
                    string recordSpec = JVData_Struct.MidB2S(ref buff, 1, 2);
                    buffObj = new byte[0];
                    buff = new byte[0];

                    if (0 <= endTimeStamp.CompareTo(timeStamp))
                    {
                        switch (recordSpec)
                        {
                            case "RA":
                                JVData_Struct.JV_RA_RACE race = new JVData_Struct.JV_RA_RACE();
                                race.SetDataB(ref buffStr);
                                OutputRaceData(eOutput.Umanushi, race);
                                break;

                            case "SE":
                                JVData_Struct.JV_SE_RACE_UMA raceUma = new JVData_Struct.JV_SE_RACE_UMA();
                                raceUma.SetDataB(ref buffStr);
                                OutputRaceUmaData(eOutput.Umanushi, raceUma);
                                break;

                            default:
                                // 対象外recspecのファイルをスキップする。
                                AxJVLink.JVSkip();
                                nCount++;
                                ProgressUserState.Value = nCount;
                                ProgressUserState.Text = "データ読み込み中...";
                                MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                                break;
                        }
                    }
                    else
                    {
                        // 対象外recspecのファイルをスキップする。
                        AxJVLink.JVSkip();
                        nCount++;
                        ProgressUserState.Value = nCount;
                        ProgressUserState.Text = "データ読み込み中...";
                        MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                    }
                }
                // ファイルの切れ目
                else if (-1 == nRet)
                {
                    if (JVDataAccessType == eJVDataAccessType.eRACE)
                    {
                        nCount++;
                        ProgressUserState.Value = nCount;
                        ProgressUserState.Text = "データ読み込み中...";
                        MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                    }
                }
                // 全レコード読込み終了(EOF)
                else if (0 == nRet)
                {
                    if (JVDataAccessType == eJVDataAccessType.eRACE)
                    {
                        ProgressUserState.Value = ProgressUserState.Maxinum;
                        ProgressUserState.Text = "データ読み込み完了";
                        MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                    }

                    reading = false;
                }
                // エラー
                else if (-1 > nRet)
                {
                    // エラーファイルをスキップする。
                    AxJVLink.JVSkip();
                    nCount++;
                    ProgressUserState.Value = nCount;
                    ProgressUserState.Text = "データ読み込み中...";
                    MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                }

                System.Threading.Thread.Sleep(10);
            }
            while (true == reading);
        }

        /// <summary>
        /// JVUmaReadWriting処理
        /// </summary>
        public static void JVUmaReadWriting()
        {
            bool reading = true;
            int nCount = 0;
            object buffObj = new byte[0];
            int buffsize = 110000;
            string timeStamp;
            string buffname;
            DataTable umaDataTable = new DataTable();
            DataTable raceDataTable = new DataTable();
            DataTable raceUmaDataTable = new DataTable();

            // 初期化時
            if (JVRelayClass.Option == (int)JVRelayClass.eJVOpenFlag.SetupSkipDialog)
            {
                using (SQLiteCommand command = DbConn.CreateCommand())
                {
                    command.CommandText = "DELETE FROM uma";
                    command.ExecuteNonQuery();
                }
            }

            using (SQLiteCommand command = DbConn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM uma";
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(umaDataTable);
                }
            }
            raceDataTable.Columns.Add("RaceKey", typeof(string));
            raceDataTable.Columns.Add("RaceDate", typeof(string));
            raceDataTable.Columns.Add("DataKubun", typeof(string));
            raceDataTable.Columns.Add("GradeCD", typeof(string));
            raceDataTable.Columns.Add("SyubetuCD", typeof(string));
            raceUmaDataTable.Columns.Add("RaceKey", typeof(string));
            raceUmaDataTable.Columns.Add("RaceDate", typeof(string));
            raceUmaDataTable.Columns.Add("KettoNum", typeof(string));
            raceUmaDataTable.Columns.Add("KakuteiJyuni", typeof(string));

            if (umaDataTable.PrimaryKey.Length == 0)
            {
                umaDataTable.PrimaryKey = new[] { umaDataTable.Columns["KettoNum"] };
            }
            if (raceDataTable.PrimaryKey.Length == 0)
            {
                raceDataTable.PrimaryKey = new[] { raceDataTable.Columns["RaceKey"] };
            }
            if (raceUmaDataTable.PrimaryKey.Length == 0)
            {
                raceUmaDataTable.PrimaryKey = new[] { raceUmaDataTable.Columns["RaceKey"], raceUmaDataTable.Columns["KettoNum"] };
            }

            ProgressUserState.Maxinum = ReadCount;
            ProgressUserState.Value = 0;
            ProgressUserState.Text = "データ読み込み中...";
            MainBackgroundWorker.ReportProgress(0, ProgressUserState);

            do
            {
                //---------------------
                // JVLink読込み処理
                //---------------------
                buffObj = new byte[0];
                int nRet = AxJVLink.JVGets(ref buffObj, buffsize, out buffname);
                timeStamp = AxJVLink.m_CurrentFileTimeStamp;
                byte[] buff = (byte[])buffObj;
                string buffStr = System.Text.Encoding.GetEncoding(932).GetString(buff);

                // 正常
                if (0 < nRet)
                {
                    string recordSpec = JVData_Struct.MidB2S(ref buff, 1, 2);
                    buffObj = new byte[0];
                    buff = new byte[0];

                    switch (recordSpec)
                    {
                        case "UM":
                            {
                                JVData_Struct.JV_UM_UMA uma = new JVData_Struct.JV_UM_UMA();
                                uma.SetDataB(ref buffStr);
                                WriteDbUmaData(eOutput.Umanushi, uma, umaDataTable);
                            }
                            break;
                        case "RA":
                            {
                                JVData_Struct.JV_RA_RACE race = new JVData_Struct.JV_RA_RACE();
                                race.SetDataB(ref buffStr);
                                WriteDbRaceData(eOutput.Umanushi, race, raceDataTable);
                            }
                            break;
                        case "SE":
                            {
                                JVData_Struct.JV_SE_RACE_UMA raceUma = new JVData_Struct.JV_SE_RACE_UMA();
                                raceUma.SetDataB(ref buffStr);
                                WriteDbRaceUmaData(eOutput.Umanushi, raceUma, raceUmaDataTable);
                            }
                            break;
                        default:
                            // 対象外recspecのファイルをスキップする。
                            AxJVLink.JVSkip();
                            nCount++;
                            ProgressUserState.Value = nCount;
                            ProgressUserState.Text = "データ読み込み中...";
                            MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                            break;
                    }
                }
                // ファイルの切れ目
                else if (-1 == nRet)
                {
                    nCount++;
                    ProgressUserState.Value = nCount;
                    ProgressUserState.Text = "データ読み込み中...";
                    MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                }
                // 全レコード読込み終了(EOF)
                else if (0 == nRet)
                {
                    ProgressUserState.Value = ProgressUserState.Maxinum;
                    ProgressUserState.Text = "データ読み込み完了";
                    MainBackgroundWorker.ReportProgress(0, ProgressUserState);

                    reading = false;
                }
                // エラー
                else if (-1 > nRet)
                {
                    // エラーファイルをスキップする。
                    AxJVLink.JVSkip();
                    nCount++;
                    ProgressUserState.Value = nCount;
                    ProgressUserState.Text = "データ読み込み中...";
                    MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                }

                System.Threading.Thread.Sleep(10);
            }
            while (true == reading);

            // データ整備
            if (raceUmaDataTable.Rows.Count > 0)
            {
                foreach (DataRow raceUmaDataRow in raceUmaDataTable.Select("", "RaceDate"))
                {
                    DataRow raceDataRow = raceDataTable.Rows.Find(raceUmaDataRow["RaceKey"]);
                    DataRow umaDataRow = umaDataTable.Rows.Find(raceUmaDataRow["KettoNum"]);
                    if (raceDataRow != null && umaDataRow != null)
                    {
                        string raceDate = umaDataRow["RaceDate"].ToString();
                        if ("" == raceDate || 0 > raceDate.CompareTo(raceUmaDataRow["RaceDate"].ToString()))
                        {
                            // レースを追加
                            umaDataRow["BeforeUmaClass"] = umaDataRow["UmaClass"];
                            umaDataRow["BeforeRaceDate"] = umaDataRow["RaceDate"];
                            umaDataRow["BeforeRaceDataKubun"] = umaDataRow["RaceDataKubun"];
                            umaDataRow["BeforeRaceGradeCD"] = umaDataRow["RaceGradeCD"];
                            umaDataRow["BeforeRaceSyubetuCD"] = umaDataRow["RaceSyubetuCD"];
                            umaDataRow["BeforeRaceKakuteiJyuni"] = umaDataRow["RaceKakuteiJyuni"];

                            umaDataRow["RaceDate"] = raceUmaDataRow["RaceDate"];
                            umaDataRow["RaceDataKubun"] = raceDataRow["DataKubun"];
                            umaDataRow["RaceGradeCD"] = raceDataRow["GradeCD"];
                            umaDataRow["RaceSyubetuCD"] = raceDataRow["SyubetuCD"];
                            umaDataRow["RaceKakuteiJyuni"] = raceUmaDataRow["KakuteiJyuni"];
                            umaDataRow["UmaClass"] = GetUmaClass(umaDataRow);
                        }
                        else if (0 == raceDate.CompareTo(raceUmaDataRow["RaceDate"].ToString()))
                        {
                            // レース結果の更新
                            if (umaDataRow["RaceDataKubun"].ToString() != raceDataRow["DataKubun"].ToString())
                            {
                                umaDataRow["RaceDataKubun"] = raceDataRow["DataKubun"];
                            }
                            if (umaDataRow["RaceGradeCD"].ToString() != raceDataRow["GradeCD"].ToString())
                            {
                                umaDataRow["RaceGradeCD"] = raceDataRow["GradeCD"];
                            }
                            if (umaDataRow["RaceSyubetuCD"].ToString() != raceDataRow["SyubetuCD"].ToString())
                            {
                                umaDataRow["RaceSyubetuCD"] = raceDataRow["SyubetuCD"];
                            }
                            if (umaDataRow["RaceKakuteiJyuni"].ToString() != raceUmaDataRow["KakuteiJyuni"].ToString())
                            {
                                umaDataRow["RaceKakuteiJyuni"] = raceUmaDataRow["KakuteiJyuni"];
                            }
                            if (umaDataRow["UmaClass"].ToString() != GetUmaClass(umaDataRow))
                            {
                                umaDataRow["UmaClass"] = GetUmaClass(umaDataRow);
                            }
                        }
                    }
                }
            }

            // データ更新
            using (SQLiteTransaction tran = DbConn.BeginTransaction())
            {
                using (SQLiteCommand command = DbConn.CreateCommand())
                {
                    command.Transaction = tran;
                    command.CommandText = "SELECT * FROM uma";
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                    using (SQLiteCommandBuilder cb = new SQLiteCommandBuilder(da))
                    {
                        cb.SetAllValues = false;
                        cb.ConflictOption = ConflictOption.OverwriteChanges;
                        da.UpdateCommand = cb.GetUpdateCommand();
                        da.InsertCommand = cb.GetInsertCommand();
                        da.DeleteCommand = cb.GetDeleteCommand();
                        da.Update(umaDataTable);
                    }

                    command.CommandText = "DELETE FROM uma WHERE BirthYear <= '" + DiscardBirthYear + "'";
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE timestamp SET date ='" + LastFileTimestamp + "'";
                    command.ExecuteNonQuery();
                }
                tran.Commit();
                JVRelayClass.DbTimeStamp = LastFileTimestamp;
            }
        }

        /// <summary>
        /// JVUmaReading処理
        /// </summary>
        public static void JVUmaReading()
        {
            DataTable umaDataTable = new DataTable();
            string delDate = DateTime.Today.AddMonths(-3).ToString("yyyyMMdd");

            using (SQLiteCommand command = DbConn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM uma WHERE DelKubun='0' OR (DelKubun='1' AND DelDate>='" + delDate + "')";
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(umaDataTable);
                }
                foreach (DataRow dr in umaDataTable.Rows)
                {
                    OutputUmaData(eOutput.Umanushi, dr);
                }
            }
        }

        /// <summary>
        /// JVClosing処理
        /// </summary>
        public static void JVClosing()
        {
            AxJVLink.JVClose();
        }

        /// <summary>
        /// レース詳細出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="race">レース詳細情報</param>
        private static void OutputRaceData(eOutput e, JVData_Struct.JV_RA_RACE race)
        {
            switch (e)
            {
                case eOutput.Umanushi:
                    Output.AppendFormat("{0},", race.head.RecordSpec);
                    Output.AppendFormat("{0},", race.head.DataKubun);
                    Output.AppendFormat("{0},", race.id.Year);
                    Output.AppendFormat("{0},", race.id.MonthDay);
                    Output.AppendFormat("{0},", race.id.JyoCD);
                    Output.AppendFormat("{0},", race.id.Kaiji);
                    Output.AppendFormat("{0},", race.id.Nichiji);
                    Output.AppendFormat("{0},", race.id.RaceNum);
                    Output.AppendFormat("{0},", race.RaceInfo.YoubiCD);
                    Output.AppendFormat("{0},", race.RaceInfo.Hondai.Replace("　", ""));
                    Output.AppendFormat("{0},", race.RaceInfo.Fukudai.Replace("　", ""));
                    Output.AppendFormat("{0},", race.RaceInfo.Kakko.Replace("　", ""));
                    Output.AppendFormat("{0},", race.RaceInfo.Kubun);
                    Output.AppendFormat("{0},", race.RaceInfo.Nkai);
                    Output.AppendFormat("{0},", race.GradeCD);
                    Output.AppendFormat("{0},", race.JyokenInfo.SyubetuCD);
                    Output.AppendFormat("{0},", race.JyokenInfo.KigoCD);
                    Output.AppendFormat("{0},", race.JyokenInfo.JyuryoCD);
                    for (int i = 0; i < 5; i++)
                    {
                        Output.AppendFormat("{0},", race.JyokenInfo.JyokenCD[i]);
                    }
                    Output.AppendFormat("{0},", race.Kyori);
                    Output.AppendFormat("{0},", race.TrackCD);
                    Output.AppendFormat("{0},", race.CourseKubunCD);
                    for (int i = 0; i < 7; i++)
                    {
                        Output.AppendFormat("{0},", int.Parse(race.Honsyokin[i]).ToString());
                    }
                    Output.AppendFormat("{0},", race.HassoTime);
                    Output.AppendFormat("{0}", race.TorokuTosu);
                    Output.AppendFormat("{0}", System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 馬毎レース情報出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="raceUma">馬毎レース情報</param>
        private static void OutputRaceUmaData(eOutput e, JVData_Struct.JV_SE_RACE_UMA raceUma)
        {
            switch (e)
            {
                case eOutput.Umanushi:
                    Output.AppendFormat("{0},", raceUma.head.RecordSpec);
                    Output.AppendFormat("{0},", raceUma.head.DataKubun);
                    Output.AppendFormat("{0},", raceUma.id.Year);
                    Output.AppendFormat("{0},", raceUma.id.MonthDay);
                    Output.AppendFormat("{0},", raceUma.id.JyoCD);
                    Output.AppendFormat("{0},", raceUma.id.Kaiji);
                    Output.AppendFormat("{0},", raceUma.id.Nichiji);
                    Output.AppendFormat("{0},", raceUma.id.RaceNum);
                    Output.AppendFormat("{0},", raceUma.Wakuban);
                    Output.AppendFormat("{0},", raceUma.Umaban);
                    Output.AppendFormat("{0},", raceUma.KettoNum);
                    Output.AppendFormat("{0},", raceUma.Bamei.Replace("　", ""));
                    Output.AppendFormat("{0},", raceUma.UmaKigoCD);
                    Output.AppendFormat("{0},", raceUma.SexCD);
                    Output.AppendFormat("{0},", raceUma.KeiroCD);
                    Output.AppendFormat("{0},", raceUma.Barei);
                    Output.AppendFormat("{0},", raceUma.TozaiCD);
                    Output.AppendFormat("{0},", raceUma.ChokyosiRyakusyo.Replace("　", ""));
                    Output.AppendFormat("{0},", raceUma.Futan);
                    Output.AppendFormat("{0},", raceUma.Blinker);
                    Output.AppendFormat("{0},", raceUma.KisyuRyakusyo.Replace("　", ""));
                    Output.AppendFormat("{0},", raceUma.MinaraiCD);
                    Output.AppendFormat("{0},", raceUma.IJyoCD);
                    Output.AppendFormat("{0},", raceUma.KakuteiJyuni);
                    Output.AppendFormat("{0},", raceUma.DochakuKubun);
                    Output.AppendFormat("{0},", raceUma.DochakuTosu);
                    Output.AppendFormat("{0},", raceUma.Honsyokin);
                    Output.AppendFormat("{0}", raceUma.RecordUpKubun);
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 競走馬マスタDB保存
        /// </summary>
        /// <param name="e"></param>
        /// <param name="uma">競走馬マスタ</param>
        /// <param name="umaDataTable">競走馬データテーブル</param>
        private static void WriteDbUmaData(eOutput e, JVData_Struct.JV_UM_UMA uma, DataTable umaDataTable)
        {
            switch (e)
            {
                case eOutput.Umanushi:

                    if (0 >= uma.BirthDate.Year.CompareTo(DiscardBirthYear.ToString()))
                    {
                        // 20歳以上の馬は不要
                        return;
                    }

                    string makeDate = uma.head.MakeDate.Year + uma.head.MakeDate.Month + uma.head.MakeDate.Day;
                    string regDate = uma.RegDate.Year + uma.RegDate.Month + uma.RegDate.Day;
                    string delDate = uma.DelDate.Year + uma.DelDate.Month + uma.DelDate.Day;
                    long ruikeiSyutokuHeichi = long.Parse(uma.RuikeiSyutokuHeichi) / 100;
                    long ruikeiSyutokuSyogai = long.Parse(uma.RuikeiSyutokuSyogai) / 100;
                    int raceCount = int.Parse(uma.RaceCount);

                    DataRow dr = umaDataTable.Rows.Find(uma.KettoNum);

                    if (dr == null)
                    {
                        dr = umaDataTable.NewRow();
                        dr["KettoNum"] = uma.KettoNum;
                        dr["MakeDate"] = makeDate;
                        dr["DelKubun"] = uma.DelKubun;
                        dr["RegDate"] = regDate;
                        dr["DelDate"] = delDate;
                        dr["BirthYear"] = uma.BirthDate.Year;
                        dr["Bamei"] = uma.Bamei.Trim();
                        dr["SexCD"] = uma.SexCD;
                        dr["TozaiCD"] = uma.TozaiCD;
                        dr["ChokyosiRyakusyo"] = uma.ChokyosiRyakusyo.Trim();
                        dr["RuikeiSyutokuHeichi"] = ruikeiSyutokuHeichi;
                        dr["RuikeiSyutokuSyogai"] = ruikeiSyutokuSyogai;
                        dr["RaceCount"] = raceCount;
                        if (raceCount == 0)
                        {
                            dr["UmaClass"] = GetUmaClass(dr);
                        }
                        umaDataTable.Rows.Add(dr);
                    }
                    else
                    {
                        if (0 < dr["MakeDate"].ToString().CompareTo(makeDate))
                        {
                            // 古いデータはスキップ
                            break;
                        }

                        if (dr["MakeDate"].ToString() != makeDate)
                        {
                            dr["MakeDate"] = makeDate;
                        }
                        if (dr["DelKubun"].ToString() != uma.DelKubun)
                        {
                            dr["DelKubun"] = uma.DelKubun;
                        }
                        if (dr["RegDate"].ToString() != regDate)
                        {
                            dr["RegDate"] = regDate;
                        }
                        if (dr["DelDate"].ToString() != delDate)
                        {
                            dr["DelDate"] = delDate;
                        }
                        if (dr["BirthYear"].ToString() != uma.BirthDate.Year)
                        {
                            dr["BirthYear"] = uma.BirthDate.Year;
                        }
                        if (dr["Bamei"].ToString() != uma.Bamei.Trim())
                        {
                            dr["Bamei"] = uma.Bamei.Trim();
                        }
                        if (dr["SexCD"].ToString() != uma.SexCD)
                        {
                            dr["SexCD"] = uma.SexCD;
                        }
                        if (dr["TozaiCD"].ToString() != uma.TozaiCD)
                        {
                            dr["TozaiCD"] = uma.TozaiCD;
                        }
                        if (dr["ChokyosiRyakusyo"].ToString() != uma.ChokyosiRyakusyo.Trim())
                        {
                            dr["ChokyosiRyakusyo"] = uma.ChokyosiRyakusyo.Trim();
                        }
                        if (dr["RuikeiSyutokuHeichi"].ToString() != ruikeiSyutokuHeichi.ToString())
                        {
                            dr["RuikeiSyutokuHeichi"] = ruikeiSyutokuHeichi;
                        }
                        if (dr["RuikeiSyutokuSyogai"].ToString() != ruikeiSyutokuSyogai.ToString())
                        {
                            dr["RuikeiSyutokuSyogai"] = ruikeiSyutokuSyogai;
                        }
                        if (dr["RaceCount"].ToString() != raceCount.ToString())
                        {
                            dr["RaceCount"] = raceCount;
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// レース詳細DB保存
        /// </summary>
        /// <param name="e"></param>
        /// <param name="race">レース詳細</param>
        /// <param name="raceDataTable">レース詳細データテーブル</param>
        private static void WriteDbRaceData(eOutput e, JVData_Struct.JV_RA_RACE race, DataTable raceDataTable)
        {
            switch (e)
            {
                case eOutput.Umanushi:
                    string receKey = race.id.Year + race.id.MonthDay + race.id.JyoCD + race.id.Kaiji + race.id.Nichiji + race.id.RaceNum;
                    string raceDate = race.id.Year + race.id.MonthDay;

                    DataRow dr = raceDataTable.Rows.Find(receKey);

                    if (dr == null)
                    {
                        dr = raceDataTable.NewRow();
                        dr["RaceKey"] = receKey;
                        dr["RaceDate"] = raceDate;
                        dr["DataKubun"] = race.head.DataKubun;
                        dr["GradeCD"] = race.GradeCD;
                        dr["SyubetuCD"] = race.JyokenInfo.SyubetuCD;
                        raceDataTable.Rows.Add(dr);
                    }
                    else
                    {
                        if (dr["DataKubun"].ToString() != race.head.DataKubun)
                        {
                            dr["DataKubun"] = race.head.DataKubun;
                        }
                        if (dr["GradeCD"].ToString() != race.GradeCD)
                        {
                            dr["GradeCD"] = race.GradeCD;
                        }
                        if (dr["SyubetuCD"].ToString() != race.JyokenInfo.SyubetuCD)
                        {
                            dr["SyubetuCD"] = race.JyokenInfo.SyubetuCD;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 馬毎レース情報DB保存
        /// </summary>
        /// <param name="e"></param>
        /// <param name="raceUma">馬毎レース情報</param>
        /// <param name="raceUmaDataTable">馬毎レース情報データテーブル</param>
        private static void WriteDbRaceUmaData(eOutput e, JVData_Struct.JV_SE_RACE_UMA raceUma, DataTable raceUmaDataTable)
        {
            switch (e)
            {
                case eOutput.Umanushi:
                    string receKey = raceUma.id.Year + raceUma.id.MonthDay + raceUma.id.JyoCD + raceUma.id.Kaiji + raceUma.id.Nichiji + raceUma.id.RaceNum;
                    string raceDate = raceUma.id.Year + raceUma.id.MonthDay;

                    DataRow dr = raceUmaDataTable.Rows.Find(new[] { receKey, raceUma.KettoNum });

                    if (dr == null)
                    {
                        dr = raceUmaDataTable.NewRow();
                        dr["RaceKey"] = receKey;
                        dr["RaceDate"] = raceDate;
                        dr["KettoNum"] = raceUma.KettoNum;
                        dr["KakuteiJyuni"] = raceUma.KakuteiJyuni;
                        raceUmaDataTable.Rows.Add(dr);
                    }
                    else
                    {
                        if (dr["KakuteiJyuni"].ToString() != raceUma.KakuteiJyuni)
                        {
                            dr["KakuteiJyuni"] = raceUma.KakuteiJyuni;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 競走馬マスタ情報出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="umaDataRow">競走馬DataRow</param>
        private static void OutputUmaData(eOutput e, DataRow umaDataRow)
        {
            switch (e)
            {
                case eOutput.Umanushi:
                    Output.AppendFormat("{0},", umaDataRow["KettoNum"].ToString());
                    Output.AppendFormat("{0},", umaDataRow["Bamei"].ToString());
                    Output.AppendFormat("{0},", GetAge(umaDataRow["BirthYear"].ToString()));
                    Output.AppendFormat("{0},", GetSex(umaDataRow["SexCD"].ToString()));
                    Output.AppendFormat("{0},", GetKyusha(umaDataRow["TozaiCD"].ToString(), umaDataRow["ChokyosiRyakusyo"].ToString()));
                    Output.AppendFormat("{0},", umaDataRow["UmaClass"].ToString());
                    Output.AppendFormat("{0},", umaDataRow["RaceDate"].ToString());
                    Output.AppendFormat("{0},", GetUmaClassKakuteiFlag(umaDataRow["UmaClass"].ToString(), umaDataRow["BeforeRaceSyubetuCD"].ToString(), umaDataRow["RaceDataKubun"].ToString(), umaDataRow["RaceGradeCD"].ToString(), umaDataRow["RaceKakuteiJyuni"].ToString()));
                    Output.AppendFormat("{0},", umaDataRow["BeforeUmaClass"].ToString());
                    Output.AppendFormat("{0},", umaDataRow["BeforeRaceDate"].ToString());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 馬クラスの取得
        /// </summary>
        /// <param name="umaDataRow">競走馬データ行</param>
        /// <returns></returns>
        private static string GetUmaClass(DataRow umaDataRow)
        {
            Int32 ruikeiSyutokuHeichi = Int32.Parse(umaDataRow["RuikeiSyutokuHeichi"].ToString());
            Int32 ruikeiSyutokuSyogai = Int32.Parse(umaDataRow["RuikeiSyutokuSyogai"].ToString());

            if (umaDataRow["BirthYear"].ToString() == DateTime.Today.AddYears(-2).Year.ToString())
            {
                // ２歳
                if (ruikeiSyutokuHeichi == 0)
                {
                    // ２歳収得賞金０万円
                    return "2_0";
                }
                else if (ruikeiSyutokuHeichi <= 500)
                {
                    // ２歳収得賞金１～５００万円
                    return "2_500";
                }
                else
                {
                    // ２歳収得賞金５０１万円以上
                    return "2_501";
                }
            }
            else
            {
                if (umaDataRow["RaceSyubetuCD"].ToString() == "18" ||
                    umaDataRow["RaceSyubetuCD"].ToString() == "19")
                {
                    // 障害
                    if (ruikeiSyutokuSyogai == 0)
                    {
                        // 障害未勝利
                        return "S_0";
                    }
                    else
                    {
                        // 障害ＯＰクラス
                        return "S_OP";
                    }
                }
                else
                {
                    // ３歳以上
                    if (ruikeiSyutokuHeichi == 0)
                    {
                        // ３歳以上収得賞金０万円
                        return "3_0";
                    }
                    else if (ruikeiSyutokuHeichi <= 500)
                    {
                        // ３歳以上収得賞金１～５００万円
                        return "3_500";
                    }
                    else if (ruikeiSyutokuHeichi <= 1000)
                    {
                        // ３歳以上収得賞金５０１～１０００万円
                        return "3_1000";
                    }
                    else if (ruikeiSyutokuHeichi <= 1600)
                    {
                        // ３歳以上収得賞金１００１～１６００万円
                        return "3_1600";
                    }
                    else
                    {
                        // ３歳以上収得賞金１６０１万円以上
                        return "3_1601";
                    }
                }
            }
        }

        /// <summary>
        /// 馬齢の取得
        /// </summary>
        /// <param name="birthYear">生年</param>
        /// <returns></returns>
        private static string GetAge(string birthYear)
        {
            int year = DateTime.Today.Year;
            int age = year - int.Parse(birthYear);
            return age.ToString() + "歳";
        }

        /// <summary>
        /// 性別の取得
        /// </summary>
        /// <param name="sexCD">性別コード</param>
        /// <returns></returns>
        private static string GetSex(string sexCD)
        {
            switch (sexCD)
            {
                case "1":
                    return "牡";
                case "2":
                    return "牝";
                case "3":
                    return "騙";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 厩舎の取得
        /// </summary>
        /// <param name="tozaiCD">東西コード</param>
        /// <param name="chokyosi">調教師</param>
        /// <returns></returns>
        private static string GetKyusha(string tozaiCD, string chokyosi)
        {
            string kyusha;
            switch (tozaiCD)
            {
                case "1":
                    kyusha = "美";
                    break;
                case "2":
                    kyusha = "栗";
                    break;
                case "3":
                    kyusha = "地";
                    break;
                case "4":
                    kyusha = "外";
                    break;
                default:
                    kyusha = "";
                    break;
            }
            kyusha += "･";
            kyusha += chokyosi;

            return kyusha;
        }

        /// <summary>
        /// 馬クラス確定フラグの取得
        /// </summary>
        /// <param name="umaClass">馬クラス</param>
        /// <param name="beforeRaceSyubetuCD">前走競走種別コード</param>
        /// <param name="raceDataKubun">レースデータ区分</param>
        /// <param name="raceGradeCD">レースグレードコード</param>
        /// <param name="raceKakuteiJyuni">レース確定順位</param>
        /// <returns></returns>
        private static string GetUmaClassKakuteiFlag(
            string umaClass,
            string beforeRaceSyubetuCD,
            string raceDataKubun, 
            string raceGradeCD, 
            string raceKakuteiJyuni)
        {
            if (umaClass == "2_501")
            {
                // ２歳OP馬はクラスアップが無いため確定
                return "1";
            }
            else if (string.IsNullOrEmpty(beforeRaceSyubetuCD) == false)
            {
                if (beforeRaceSyubetuCD == "18" || beforeRaceSyubetuCD == "19")
                {
                    if (umaClass == "S_OP")
                    {
                        // 前走障害を走った障害OP馬はクラスアップが無いため確定
                        return "1";
                    }
                }
                else
                {
                    if (umaClass == "3_1601")
                    {
                        // 前走平地を走ったOP馬はクラスアップが無いため確定
                        return "1";
                    }
                }
            }


            switch (raceDataKubun)
            {
                case "7":
                case "A":
                case "B":
                case "9":
                case "0":
                    return "1";
                case "3":
                case "4":
                case "5":
                case "6":
                    if (raceKakuteiJyuni == "00")
                    {
                        // 着順未定のため未確定
                        return "0";
                    }
                    else if (raceKakuteiJyuni == "01")
                    {
                        // 収得金額未定のため未確定
                        return "0";
                    }
                    else if (raceKakuteiJyuni == "02")
                    {
                        if (raceGradeCD != " " && raceGradeCD != "E")
                        {
                            // 重賞２着。収得金額未定のため未確定
                            return "0";
                        }
                        else
                        {
                            // 重賞以外の２着は収得金額変動なしのため確定
                            return "1";
                        }
                    }
                    else
                    {
                        return "1";
                    }
                default:
                    // 出走前は未確定
                    return "0";
            }
        }
        #endregion
    }
}
