using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

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
            /// 蓄積系データ
            /// </summary>
            eSTORE,

            /// <summary>
            /// 速報系データ
            /// </summary>
            eSPOT,
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

            try
            {
                // JVInit:ソフトウェアID
                string sid = "UNKNOWN";

                //-----------------
                // JVLink初期化
                //-----------------
                if (0 == AxJVLink.JVInit(sid))
                {
                    IsUse = true;
                }
            }
            finally
            {
                // ToDo...
            }
        }

        /// <summary>
        /// JVReading処理
        /// </summary>
        /// <param name="endDate">終了日</param>
        public static void JVReading(string endDate)
        {
            try
            {
                bool reading = true;
                int nCount = 0;
                object buffObj = new byte[0];
                int buffsize = 110000;
                string endTimeStamp = endDate + "235959";
                string timeStamp;
                string buffname;

                if (JVDataAccessType == eJVDataAccessType.eSTORE)
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
                        if (0 <= endTimeStamp.CompareTo(timeStamp))
                        {
                            switch (JVData_Struct.MidB2S(ref buff, 1, 2))
                            {
                                case "RA":
                                    if (JVDataSpec.Equals(JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1)) ||
                                        0 <= JVDataSpec.IndexOf(JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1)))
                                    {
                                        JVData_Struct.JV_RA_RACE race = new JVData_Struct.JV_RA_RACE();
                                        race.SetDataB(ref buffStr);
                                        OutputRaceData(eOutput.Umanushi, race);
                                    }
                                    else
                                    {
                                        // 対象外recspecのファイルをスキップする。
                                        AxJVLink.JVSkip();
                                        nCount++;
                                    }
                                    break;

                                case "SE":
                                    if (JVDataSpec.Equals(JVRelayClass.eJVDataSpec.e0B12.ToString().Substring(1)) ||
                                        0 <= JVDataSpec.IndexOf(JVRelayClass.eJVDataSpec.eRACE.ToString().Substring(1)))
                                    {
                                        JVData_Struct.JV_SE_RACE_UMA raceUma = new JVData_Struct.JV_SE_RACE_UMA();
                                        raceUma.SetDataB(ref buffStr);
                                        OutputRaceUmaData(eOutput.Umanushi, raceUma);
                                    }
                                    else
                                    {
                                        // 対象外recspecのファイルをスキップする。
                                        AxJVLink.JVSkip();
                                        nCount++;
                                    }
                                    break;

                                case "UM":
                                    {
                                        JVData_Struct.JV_UM_UMA uma = new JVData_Struct.JV_UM_UMA();
                                        uma.SetDataB(ref buffStr);
                                        OutputUmaData(eOutput.Pogdb, uma);
                                    }
                                    break;

                                case "SK":
                                    {
                                        JVData_Struct.JV_SK_SANKU sanku = new JVData_Struct.JV_SK_SANKU();
                                        sanku.SetDataB(ref buffStr);
                                        OutputSankuData(eOutput.Pogdb, sanku);
                                    }
                                    break;

                                case "HY":
                                    {
                                        JVData_Struct.JV_HY_BAMEIORIGIN bameiOrigin = new JVData_Struct.JV_HY_BAMEIORIGIN();
                                        bameiOrigin.SetDataB(ref buffStr);
                                        OutputBameiOriginData(eOutput.Pogdb, bameiOrigin);
                                    }
                                    break;

                                case "KS":
                                    {
                                        JVData_Struct.JV_KS_KISYU kisyu = new JVData_Struct.JV_KS_KISYU();
                                        kisyu.SetDataB(ref buffStr);
                                        OutputKisyuData(eOutput.Pogdb, kisyu);
                                    }
                                    break;

                                case "CH":
                                    {
                                        JVData_Struct.JV_CH_CHOKYOSI chokyosi = new JVData_Struct.JV_CH_CHOKYOSI();
                                        chokyosi.SetDataB(ref buffStr);
                                        OutputChokyosiData(eOutput.Pogdb, chokyosi);
                                    }
                                    break;

                                case "BR":
                                    {
                                        JVData_Struct.JV_BR_BREEDER breeder = new JVData_Struct.JV_BR_BREEDER();
                                        breeder.SetDataB(ref buffStr);
                                        OutputBreederData(eOutput.Pogdb, breeder);
                                    }
                                    break;

                                case "BN":
                                    {
                                        JVData_Struct.JV_BN_BANUSI banusi = new JVData_Struct.JV_BN_BANUSI();
                                        banusi.SetDataB(ref buffStr);
                                        OutputBanusiData(eOutput.Pogdb, banusi);
                                    }
                                    break;
                                default:
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
                        if (JVDataAccessType == eJVDataAccessType.eSTORE)
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
                        if (JVDataAccessType == eJVDataAccessType.eSTORE)
                        {
                            ProgressUserState.Value = ProgressUserState.Maxinum;
                            ProgressUserState.Text = "データ読み込み完了";
                            MainBackgroundWorker.ReportProgress(0, ProgressUserState);
                        }

                        reading = false;

                        // ToDo...
                    }
                    // エラー
                    else if (-1 > nRet)
                    {
                        // ToDo...

                        return;
                    }

                    System.Threading.Thread.Sleep(10);
                }
                while (true == reading);
            }
            finally
            {
                // ToDo...
            }
        }

        /// <summary>
        /// JVClosing処理
        /// </summary>
        public static void JVClosing()
        {
            try
            {
                AxJVLink.JVClose();
            }
            finally
            {
                // ToDo...
            }
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
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", race.head.RecordSpec);
                    Output.AppendFormat("{0},", race.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", race.head.MakeDate.Year, race.head.MakeDate.Month, race.head.MakeDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", race.id.Year, race.id.MonthDay.Substring(0, 2), race.id.MonthDay.Substring(2));
                    Output.AppendFormat("{0},", race.id.JyoCD);
                    Output.AppendFormat("{0},", race.id.Kaiji);
                    Output.AppendFormat("{0},", race.id.Nichiji);
                    Output.AppendFormat("{0},", race.id.RaceNum);
                    Output.AppendFormat("{0},", race.RaceInfo.YoubiCD);
                    Output.AppendFormat("{0},", race.RaceInfo.Hondai.Trim());
                    Output.AppendFormat("{0},", race.RaceInfo.Fukudai.Trim());
                    Output.AppendFormat("{0},", race.RaceInfo.Kakko.Trim());
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
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", raceUma.head.RecordSpec);
                    Output.AppendFormat("{0},", raceUma.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", raceUma.head.MakeDate.Year, raceUma.head.MakeDate.Month, raceUma.head.MakeDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", raceUma.id.Year, raceUma.id.MonthDay.Substring(0, 2), raceUma.id.MonthDay.Substring(2));
                    Output.AppendFormat("{0},", raceUma.id.JyoCD);
                    Output.AppendFormat("{0},", raceUma.id.Kaiji);
                    Output.AppendFormat("{0},", raceUma.id.Nichiji);
                    Output.AppendFormat("{0},", raceUma.id.RaceNum);
                    Output.AppendFormat("{0},", raceUma.Wakuban);
                    Output.AppendFormat("{0},", raceUma.Umaban);
                    Output.AppendFormat("{0},", raceUma.KettoNum);
                    Output.AppendFormat("{0},", raceUma.Bamei.Trim());
                    Output.AppendFormat("{0},", raceUma.UmaKigoCD);
                    Output.AppendFormat("{0},", raceUma.SexCD);
                    Output.AppendFormat("{0},", raceUma.KeiroCD);
                    Output.AppendFormat("{0},", raceUma.Barei);
                    Output.AppendFormat("{0},", raceUma.TozaiCD);
                    Output.AppendFormat("{0},", raceUma.ChokyosiCode);
                    Output.AppendFormat("{0},", raceUma.Futan);
                    Output.AppendFormat("{0},", raceUma.Blinker);
                    Output.AppendFormat("{0},", raceUma.KisyuCode);
                    Output.AppendFormat("{0},", raceUma.MinaraiCD);
                    Output.AppendFormat("{0},", raceUma.IJyoCD);
                    Output.AppendFormat("{0},", raceUma.KakuteiJyuni);
                    Output.AppendFormat("{0},", raceUma.DochakuKubun);
                    Output.AppendFormat("{0},", raceUma.DochakuTosu);
                    Output.AppendFormat("{0},", raceUma.Honsyokin);
                    Output.AppendFormat("{0}", raceUma.RecordUpKubun);
                    Output.Append(System.Environment.NewLine);
                    break;

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
        /// 競走馬マスタ情報出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="uma">競走馬マスタ</param>
        private static void OutputUmaData(eOutput e, JVData_Struct.JV_UM_UMA uma)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", uma.head.RecordSpec);
                    Output.AppendFormat("{0},", uma.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", uma.head.MakeDate.Year, uma.head.MakeDate.Month, uma.head.MakeDate.Day);
                    Output.AppendFormat("{0},", uma.KettoNum);
                    Output.AppendFormat("{0},", uma.DelKubun);
                    Output.AppendFormat("{0}/{1}/{2},", uma.RegDate.Year, uma.RegDate.Month, uma.RegDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", uma.DelDate.Year, uma.DelDate.Month, uma.DelDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", uma.BirthDate.Year, uma.BirthDate.Month, uma.BirthDate.Day);
                    Output.AppendFormat("{0},", uma.Bamei.Trim());
                    Output.AppendFormat("{0},", uma.BameiEng.Trim());
                    Output.AppendFormat("{0},", uma.ZaikyuFlag);
                    Output.AppendFormat("{0},", uma.UmaKigoCD);
                    Output.AppendFormat("{0},", uma.SexCD);
                    Output.AppendFormat("{0},", uma.HinsyuCD);
                    Output.AppendFormat("{0},", uma.KeiroCD);
                    // 父
                    Output.AppendFormat("{0},", uma.Ketto3Info[0].HansyokuNum);
                    Output.AppendFormat("{0},", uma.Ketto3Info[0].Bamei.Trim());
                    // 母
                    Output.AppendFormat("{0},", uma.Ketto3Info[1].HansyokuNum);
                    Output.AppendFormat("{0},", uma.Ketto3Info[1].Bamei.Trim());
                    // 母父
                    Output.AppendFormat("{0},", uma.Ketto3Info[4].HansyokuNum);
                    Output.AppendFormat("{0},", uma.Ketto3Info[4].Bamei.Trim());
                    Output.AppendFormat("{0},", uma.TozaiCD);
                    Output.AppendFormat("{0},", uma.ChokyosiCode);
                    Output.AppendFormat("{0},", uma.ChokyosiRyakusyo.Trim());
                    Output.AppendFormat("{0},", uma.Syotai.Trim());
                    Output.AppendFormat("{0},", uma.BreederCode);
                    Output.AppendFormat("{0},", uma.BreederName.Trim());
                    Output.AppendFormat("{0},", uma.SanchiName.Trim());
                    Output.AppendFormat("{0},", uma.BanusiCode);
                    Output.AppendFormat("{0}", uma.BanusiName.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 産駒マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sanku">産駒マスタ</param>
        private static void OutputSankuData(eOutput e, JVData_Struct.JV_SK_SANKU sanku)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", sanku.head.RecordSpec);
                    Output.AppendFormat("{0},", sanku.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", sanku.head.MakeDate.Year, sanku.head.MakeDate.Month, sanku.head.MakeDate.Day);
                    Output.AppendFormat("{0},", sanku.KettoNum);
                    Output.AppendFormat("{0}/{1}/{2},", sanku.BirthDate.Year, sanku.BirthDate.Month, sanku.BirthDate.Day);
                    Output.AppendFormat("{0},", sanku.SexCD);
                    Output.AppendFormat("{0},", sanku.HinsyuCD);
                    Output.AppendFormat("{0},", sanku.KeiroCD);
                    Output.AppendFormat("{0},", sanku.SankuMochiKubun);
                    Output.AppendFormat("{0},", sanku.ImportYear);
                    Output.AppendFormat("{0},", sanku.BreederCode);
                    Output.AppendFormat("{0},", sanku.SanchiName.Trim());
                    // 父
                    Output.AppendFormat("{0},", sanku.HansyokuNum[0]);
                    // 母
                    Output.AppendFormat("{0},", sanku.HansyokuNum[1]);
                    // 母父
                    Output.AppendFormat("{0}", sanku.HansyokuNum[4]);
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 馬名の意味由来情報出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bameiOrigin">馬名の意味由来情報</param>
        private static void OutputBameiOriginData(eOutput e, JVData_Struct.JV_HY_BAMEIORIGIN bameiOrigin)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", bameiOrigin.head.RecordSpec);
                    Output.AppendFormat("{0},", bameiOrigin.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", bameiOrigin.head.MakeDate.Year, bameiOrigin.head.MakeDate.Month, bameiOrigin.head.MakeDate.Day);
                    Output.AppendFormat("{0},", bameiOrigin.KettoNum);
                    Output.AppendFormat("{0},", bameiOrigin.Bamei.Trim());
                    Output.AppendFormat("{0},", bameiOrigin.Origin.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 繁殖馬マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="BoldHn">繁殖馬マスタ</param>
        private static void OutputBoldHnData(eOutput e, JVData_Struct.JV_HN_HANSYOKU BoldHn, ref StringBuilder s)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    s.AppendFormat("{0},", BoldHn.head.RecordSpec);
                    s.AppendFormat("{0},", BoldHn.head.DataKubun);
                    s.AppendFormat("{0}/{1}/{2},", BoldHn.head.MakeDate.Year, BoldHn.head.MakeDate.Month, BoldHn.head.MakeDate.Day);
                    s.AppendFormat("{0},", BoldHn.HansyokuNum);
                    s.AppendFormat("{0},", BoldHn.KettoNum);
                    s.AppendFormat("{0},", BoldHn.Bamei.Trim());
                    s.AppendFormat("{0},", BoldHn.BameiEng.Trim());
                    s.AppendFormat("{0},", BoldHn.BirthYear);
                    s.AppendFormat("{0},", BoldHn.SexCD);
                    s.AppendFormat("{0},", BoldHn.HinsyuCD);
                    s.AppendFormat("{0},", BoldHn.KeiroCD);
                    s.AppendFormat("{0},", BoldHn.HansyokuMochiKubun);
                    s.AppendFormat("{0},", BoldHn.ImportYear);
                    s.AppendFormat("{0},", BoldHn.SanchiName.Trim());
                    s.AppendFormat("{0},", BoldHn.HansyokuFNum);
                    s.AppendFormat("{0}", BoldHn.HansyokuMNum);
                    s.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 騎手マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="kisyu">騎手マスタ</param>
        private static void OutputKisyuData(eOutput e, JVData_Struct.JV_KS_KISYU kisyu)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", kisyu.head.RecordSpec);
                    Output.AppendFormat("{0},", kisyu.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", kisyu.head.MakeDate.Year, kisyu.head.MakeDate.Month, kisyu.head.MakeDate.Day);
                    Output.AppendFormat("{0},", kisyu.KisyuCode);
                    Output.AppendFormat("{0},", kisyu.DelKubun);
                    Output.AppendFormat("{0}/{1}/{2},", kisyu.IssueDate.Year, kisyu.IssueDate.Month, kisyu.IssueDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", kisyu.DelDate.Year, kisyu.DelDate.Month, kisyu.DelDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", kisyu.BirthDate.Year, kisyu.BirthDate.Month, kisyu.BirthDate.Day);
                    Output.AppendFormat("{0},", kisyu.KisyuName.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 調教師マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="chokyosi">調教師マスタ</param>
        private static void OutputChokyosiData(eOutput e, JVData_Struct.JV_CH_CHOKYOSI chokyosi)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", chokyosi.head.RecordSpec);
                    Output.AppendFormat("{0},", chokyosi.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", chokyosi.head.MakeDate.Year, chokyosi.head.MakeDate.Month, chokyosi.head.MakeDate.Day);
                    Output.AppendFormat("{0},", chokyosi.ChokyosiCode);
                    Output.AppendFormat("{0},", chokyosi.DelKubun);
                    Output.AppendFormat("{0}/{1}/{2},", chokyosi.IssueDate.Year, chokyosi.IssueDate.Month, chokyosi.IssueDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", chokyosi.DelDate.Year, chokyosi.DelDate.Month, chokyosi.DelDate.Day);
                    Output.AppendFormat("{0}/{1}/{2},", chokyosi.BirthDate.Year, chokyosi.BirthDate.Month, chokyosi.BirthDate.Day);
                    Output.AppendFormat("{0},", chokyosi.ChokyosiName.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 生産者マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="breeder">生産者マスタ</param>
        private static void OutputBreederData(eOutput e, JVData_Struct.JV_BR_BREEDER breeder)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", breeder.head.RecordSpec);
                    Output.AppendFormat("{0},", breeder.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", breeder.head.MakeDate.Year, breeder.head.MakeDate.Month, breeder.head.MakeDate.Day);
                    Output.AppendFormat("{0},", breeder.BreederCode);
                    Output.AppendFormat("{0},", breeder.BreederName_Co.Trim());
                    Output.AppendFormat("{0},", breeder.BreederName.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }

        /// <summary>
        /// 馬主マスタ出力
        /// </summary>
        /// <param name="e"></param>
        /// <param name="banusi">馬主マスタ</param>
        private static void OutputBanusiData(eOutput e, JVData_Struct.JV_BN_BANUSI banusi)
        {
            switch (e)
            {
                case eOutput.Pogdb:
                    Output.AppendFormat("{0},", banusi.head.RecordSpec);
                    Output.AppendFormat("{0},", banusi.head.DataKubun);
                    Output.AppendFormat("{0}/{1}/{2},", banusi.head.MakeDate.Year, banusi.head.MakeDate.Month, banusi.head.MakeDate.Day);
                    Output.AppendFormat("{0},", banusi.BanusiCode);
                    Output.AppendFormat("{0},", banusi.BanusiName_Co.Trim());
                    Output.AppendFormat("{0},", banusi.BanusiName.Trim());
                    Output.Append(System.Environment.NewLine);
                    break;
            }
        }
        #endregion
    }
}
