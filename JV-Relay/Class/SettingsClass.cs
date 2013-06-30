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
        /// ファイル名
        /// </summary>
        private const string m_fileName = "setting.xml";

        /// <summary>
        /// 会社名
        /// </summary>
        private static string m_assemblyCompany = "";

        /// <summary>
        /// 製品名
        /// </summary>
        private static string m_assemblyProduct = "";

        /// <summary>
        /// ディレクトリパス
        /// </summary>
        private static string m_directoryPath = "";

        /// <summary>
        /// ファイルパス
        /// </summary>
        private static string m_filePath = "";
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
            m_directoryPath = string.Format(@"{0}\{1}\{2}"
                , Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                , m_assemblyCompany
                , m_assemblyProduct);

            // ファイルパスの設定
            m_filePath = FileSystem.CombinePath(m_directoryPath, m_fileName);


            // ディレクトリパスが無い場合は作成する
            if (!FileSystem.DirectoryExists(m_directoryPath))
            {
                FileSystem.CreateDirectory(m_directoryPath);
            }

            // 設定ファイルが無い場合は作成する
            if (!FileSystem.FileExists(m_filePath))
            {
                FileSystem.WriteAllText(m_filePath, @"<?xml version='1.0' encoding='utf-8' ?>", false, Encoding.UTF8);
                Save();
            }

            // 設定ファイルの読込
            XmlSerializer serializer = new XmlSerializer(typeof(setting));
            System.IO.FileStream fs = new System.IO.FileStream(m_filePath, System.IO.FileMode.Open);
            Setting = (setting)serializer.Deserialize(fs);
            fs.Close();
        }

        /// <summary>
        /// 設定ファイル保存
        /// </summary>
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(setting));
            System.IO.FileStream fs = new System.IO.FileStream(m_filePath, System.IO.FileMode.Create);
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
    }
}
