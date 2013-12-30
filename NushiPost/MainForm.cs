using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace NushiPost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            waitComboBox.SelectedItem = "5"; 
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;
            string result = "";
            string url;
            string body;
            string errorMessage = string.Empty;
            string logFilePath =  System.Windows.Forms.Application.StartupPath + @"\log.txt";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (File.Exists(logFilePath))
                {
                    File.Delete(logFilePath);
                }

                NameValueCollection querystring = new NameValueCollection();
                CookieContainer cookies = new CookieContainer();

                // 送信
                url = "http://www.umanushi.com/old2/mail_form/";
                body = "";
                foreach (var s in bodyTextBox.Text.Replace("\r\n", "\n").Split('\n'))
                {
                    body += s.Replace("&", "%26").Replace("=","%3d") + "<br>";
                }

                var toList = toTextBox.Text.Replace("\r\n", "\n").Split('\n');
                for (int i = 0; i < toList.Length; i++)
                {
                    querystring.Clear();
                    querystring["mode"] = "mail_go";
                    querystring["speed"] = "mid";
                    querystring["usr"] = nameTextBox.Text.Replace("&", "%26").Replace("=", "%3d");
                    querystring["pwd"] = passwordTextBox.Text.Replace("&", "%26").Replace("=", "%3d");
                    querystring["subject"] = subjectTextBox.Text.Replace("&", "%26").Replace("=", "%3d");
                    querystring["from"] = nameTextBox.Text.Replace("&", "%26").Replace("=", "%3d");
                    querystring["to"] = toList[i].Replace("&", "%26").Replace("=", "%3d");
                    querystring["body"] = body;

                    result = HttpPost(url, querystring);

                    File.AppendAllText(logFilePath, result);

                    if (i == toList.Length - 1) break;

                    System.Threading.Thread.Sleep(int.Parse(waitComboBox.Text) * 1000);
                }
                MessageBox.Show("送信しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = preCursor;
            }
        }

        /// <summary>
        /// HTTPでのGET処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="cookies">GET時に使用するCookie</param>
        /// <returns>HTTPのGET結果</returns>
        public static string HttpGet(string url, CookieContainer cookies)
        {
            // リクエストの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.CookieContainer = cookies;

            WebResponse res = req.GetResponse();

            // レスポンスの読み取り
            Stream resStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("Shift-JIS"));
            string result = sr.ReadToEnd();
            sr.Close();
            resStream.Close();

            return result;
        }

        /// <summary>
        /// HTTPでのPOST処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="querystring">POSTパラメータ</param>
        /// <returns>HTTPのPOST結果</returns>
        public string HttpPost(string url, NameValueCollection querystring)
        {
            string param = "";
            if (querystring != null)
            {
                foreach (string key in querystring.Keys)
                {
                    param += String.Format("{0}={1}&", key, querystring.Get(key));
                }
            }
            byte[] data = Encoding.GetEncoding("Shift-JIS").GetBytes(param);

            // リクエストの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;

            // ポスト・データの書き込み
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();

            WebResponse res = req.GetResponse();

            // レスポンスの読み取り
            Stream resStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("Shift-JIS"));
            string result = sr.ReadToEnd();
            sr.Close();
            resStream.Close();

            return result;
        }    
    }
}
