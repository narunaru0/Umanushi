using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

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
            string errorMessage = string.Empty;

            NameValueCollection querystring = new NameValueCollection();
            CookieContainer cookies = new CookieContainer();

            // 認証
            url = "http://www.umanushi.com/old2/mail_form/";
            querystring["usr"] = nameTextBox.Text;
            querystring["pwd"] = passwordTextBox.Text;
            result = HttpPost(url, querystring, cookies);
            if (cookies.Count == 0)
            {
                // 認証に失敗
                errorMessage = string.Format("ログインに失敗しました。うまぬし名=[{1}]、パスワード=[{2}]",
                    querystring["usr"],
                    querystring["pwd"]);
                return;
            }
            querystring.Clear();

            // 送信
            foreach (var to in toTextBox.Text.Replace("\r\n", "\n").Split('\n'))
            {
                url = "http://www.umanushi.com/old2/mail_form/";
                querystring["mode"] = "mail_go";
                querystring["speed"] = "mid";
                querystring["usr"] = nameTextBox.Text;
                querystring["pwd"] = passwordTextBox.Text;
                querystring["subject"] = subjectTextBox.Text;
                querystring["from"] = nameTextBox.Text;
                querystring["to"] = to;
                querystring["body"] = bodyTextBox.Text;
                result = HttpPost(url, querystring, cookies);

                System.Threading.Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// HTTPでのPOST処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="querystring">POSTパラメータ</param>
        /// <param name="cookies">POST時に使用するCookie</param>
        /// <returns>HTTPのPOST結果</returns>
        public string HttpPost(string url, NameValueCollection querystring, CookieContainer cookies)
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
            req.CookieContainer = cookies;

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
