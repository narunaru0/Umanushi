using System;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace JVRelay
{
    /// <summary>
    /// 設定クラス
    /// </summary>
    public static class SettingsClass
    {
        #region privateメンバ
        /// <summary>
        /// 会社名
        /// </summary>
        private static string m_assemblyCompany = "";

        /// <summary>
        /// 製品名
        /// </summary>
        private static string m_assemblyProduct = "";

        /// <summary>
        /// 設定ディレクトリパス
        /// </summary>
        private static string m_settingDirectoryPath = "";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string m_settingFileName = "setting.xml";

        /// <summary>
        /// 設定ファイルパス
        /// </summary>
        private static string m_settingFilePath = "";
        #endregion

        #region プロパティ
        /// <summary>
        /// 設定
        /// </summary>
        public static setting Setting { get; private set; }
        #endregion

        #region コンストラクタ/デストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        static SettingsClass()
        {
            // 設定ファイル読込
            Load();
        } 
        #endregion

        #region メソッド
        /// <summary>
        /// 設定ファイル読込
        /// </summary>
        private static void Load()
        {
            // 設定の初期化
            Setting = new setting();

            // アセンブリ情報から会社名を設定
            m_assemblyCompany = ((System.Reflection.AssemblyCompanyAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyCompanyAttribute))).Company;

            // アセンブリ情報から製品名を設定
            m_assemblyProduct = ((System.Reflection.AssemblyProductAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyProductAttribute))).Product;

            // ディレクトリパスの設定
            m_settingDirectoryPath = string.Format(@"{0}\{1}\{2}"
                , Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                , m_assemblyCompany
                , m_assemblyProduct);

            // ファイルパスの設定
            m_settingFilePath = FileSystem.CombinePath(m_settingDirectoryPath, m_settingFileName);


            // ディレクトリパスが無い場合は作成する
            if (!FileSystem.DirectoryExists(m_settingDirectoryPath))
            {
                FileSystem.CreateDirectory(m_settingDirectoryPath);
            }

            // 設定ファイルが無い場合は作成する
            if (!FileSystem.FileExists(m_settingFilePath))
            {
                FileSystem.WriteAllText(m_settingFilePath, @"<?xml version='1.0' encoding='utf-8' ?>", false, Encoding.UTF8);
                Save();
            }

            // 設定ファイルの読込
            XmlSerializer serializer = new XmlSerializer(typeof(setting));
            System.IO.FileStream fs = new System.IO.FileStream(m_settingFilePath, System.IO.FileMode.Open);
            Setting = (setting)serializer.Deserialize(fs);
            fs.Close();
        }

        /// <summary>
        /// 設定ファイル保存
        /// </summary>
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(setting));
            System.IO.FileStream fs = new System.IO.FileStream(m_settingFilePath, System.IO.FileMode.Create);
            serializer.Serialize(fs, Setting);
            fs.Close();
        }
        #endregion
    }

    /// <summary>
    /// 設定定義クラス
    /// </summary>
    public class setting
    {
        /// <summary>
        /// POST使用
        /// </summary>
        public bool IsPost { get; set; }

        /// <summary>
        /// POSTユーザー名
        /// </summary>
        public string PostUserName { get; set; }

        /// <summary>
        /// POSTパスワード
        /// </summary>
        public string PostPassword { get; set; }

        /// <summary>
        /// デバッグ用SQLiteファイルパス
        /// </summary>
        public string DebugSqLiteFilePath { get; set; }
    }
}
