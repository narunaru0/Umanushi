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
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            string result = "";
            string url;
            string body;
            string errorMessage = string.Empty;
            string logFilePath =  System.Windows.Forms.Application.StartupPath + @"\log.txt";

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
                if (s.StartsWith("http://"))
                {
                    body += HttpUtility.UrlEncode(s) + "<br>";
                }
                else
                {
                    body += s + "<br>";
                }
            }
            
            foreach (var to in toTextBox.Text.Replace("\r\n", "\n").Split('\n'))
            {
                querystring.Clear();
                querystring["mode"] = "mail_go";
                querystring["speed"] = "mid";
                querystring["usr"] = nameTextBox.Text;
                querystring["pwd"] = passwordTextBox.Text;
                querystring["subject"] = subjectTextBox.Text;
                querystring["from"] = nameTextBox.Text;
                querystring["to"] = to;
                querystring["body"] = body;

                result = HttpPost(url, querystring);

                File.AppendAllText(logFilePath, result);

                System.Threading.Thread.Sleep(5000);
            }

            MessageBox.Show("終了しました。");
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
