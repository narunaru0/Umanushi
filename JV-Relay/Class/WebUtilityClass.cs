using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace JVRelay
{
    /// <summary>
    /// Webユーティリティクラス
    /// </summary>
    static class WebUtilityClass
    {
        /// <summary>
        /// JVRelayをHTTPでPOST処理
        /// </summary>
        /// <param name="isError">エラーか</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>POST結果</returns>
        public static string HttpPostJVRelay(out bool isError, out string errorMessage)
        {
            string result = "";
            string url;
            string fileFormName;

            isError = false;
            errorMessage = string.Empty;

            NameValueCollection querystring = new NameValueCollection();
            CookieContainer cookies = new CookieContainer();

            if (SettingsClass.Setting.IsPost == true)
            {
                // 認証
                querystring["Fnc"] = "Login";
                querystring["Props"] = "/login/";
                querystring["USR"] = SettingsClass.Setting.PostUserName;
                querystring["PWD"] = SettingsClass.Setting.PostPassword;
                url = "http://www.umanushi.com/login/";
                result = WebUtilityClass.HttpPost(url, querystring, cookies);
                if (cookies.Count == 0)
                {
                    // 認証に失敗
                    isError = true;
                    errorMessage = string.Format("ログインに失敗しました。ユーザー名=[{1}]、パスワード=[{2}]",
                        url,
                        SettingsClass.Setting.PostUserName,
                        SettingsClass.Setting.PostPassword);
                    return result;
                }
                querystring.Clear();

                // レースデータ送信
                url = "http://www.umanushi.com/race/admin/";
                fileFormName = "NEWRACEFILE";
                querystring["Fnc"] = "Update";
                querystring["Mode"] = "RaceInfo";

                result = WebUtilityClass.HttpPostFile(url, new MemoryStream(System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(JVRelayClass.Output.ToString())),
                    @"c:\dummy.csv", fileFormName, "application/vnd.ms-excel", querystring, cookies);
            }

            return result;
        }

        /// <summary>
        /// JVRTRelayをHTTPでPOST処理
        /// </summary>
        /// <param name="isError">エラーか</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>POST結果</returns>
        public static string HttpPostJVRTRelay(out bool isError, out string errorMessage)
        {
            string result = "";
            string url;
            string fileFormName;

            isError = false;
            errorMessage = string.Empty;

            NameValueCollection querystring = new NameValueCollection();
            CookieContainer cookies = new CookieContainer();

            if (SettingsClass.Setting.IsPost == true)
            {
                // 認証
                querystring["Fnc"] = "Login";
                querystring["Props"] = "/login/";
                querystring["USR"] = SettingsClass.Setting.PostUserName;
                querystring["PWD"] = SettingsClass.Setting.PostPassword;
                url = "http://www.umanushi.com/login/";
                result = WebUtilityClass.HttpPost(url, querystring, cookies);
                if (cookies.Count == 0)
                {
                    // 認証に失敗
                    isError = true;
                    errorMessage = string.Format("ログインに失敗しました。ユーザー名=[{1}]、パスワード=[{2}]",
                        url,
                        SettingsClass.Setting.PostUserName,
                        SettingsClass.Setting.PostPassword);
                    return result;
                }
                querystring.Clear();

                // レース結果データ送信
                url = "http://www.umanushi.com/race/admin/";
                fileFormName = "NEWRESULTFILE1";
                querystring["Fnc"] = "Update";
                querystring["Mode"] = "RaceResult";

                result = WebUtilityClass.HttpPostFile(url, new MemoryStream(System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(JVRelayClass.Output.ToString())),
                    @"c:\dummy.csv", fileFormName, "application/vnd.ms-excel", querystring, cookies);
            }

            return result;
        }

        /// <summary>
        /// HTTPでのPOST処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="querystring">POSTパラメータ</param>
        /// <param name="cookies">POST時に使用するCookie</param>
        /// <returns>HTTPのPOST結果</returns>
        public static string HttpPost(string url, NameValueCollection querystring, CookieContainer cookies)
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
        /// HTTPでのファイルPOST処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="filePath">対象ファイルパス</param>
        /// <param name="fileFormName"></param>
        /// <param name="contenttype"></param>
        /// <param name="querystring">POSTパラメータ</param>
        /// <param name="cookies">POST時に使用するCookie</param>
        /// <returns></returns>
        public static string HttpPostFile(string url,
            string filePath,
            string fileFormName, 
            string contenttype, 
            NameValueCollection querystring,
            CookieContainer cookies)
        {
            return HttpPostFile(url, 
                new FileStream(filePath, FileMode.Open, FileAccess.Read), 
                filePath,
                fileFormName, 
                contenttype, 
                querystring, 
                cookies);
        }

        /// <summary>
        /// HTTPでのファイルPOST処理
        /// </summary>
        /// <param name="url">対象URL</param>
        /// <param name="stream">対象ファイルのStream</param>
        /// <param name="filePath">対象ファイルパス</param>
        /// <param name="fileFormName"></param>
        /// <param name="contenttype"></param>
        /// <param name="querystring">POSTパラメータ</param>
        /// <param name="cookies">POST時に使用するCookie</param>
        /// <returns></returns>
        public static string HttpPostFile(string url, 
            Stream stream, 
            string filePath,
            string fileFormName, 
            string contenttype, 
            NameValueCollection querystring,
            CookieContainer cookies)
        {
            if (String.IsNullOrEmpty(fileFormName))
            {
                fileFormName = "file";
            }

            if (String.IsNullOrEmpty(contenttype))
            {
                contenttype = "application/octet-stream";
            }

            Uri uri = new Uri(url);


            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.CookieContainer = cookies;
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";

            // Build up the post message header
            StringBuilder sb = new StringBuilder();

            if (querystring != null)
            {
                foreach (string key in querystring.Keys)
                {
                    sb.Append("--");
                    sb.Append(boundary);
                    sb.Append("\r\n");
                    sb.Append(string.Format(@"Content-Disposition: form-data; name=""{0}""", key));
                    sb.Append("\r\n");
                    sb.Append("\r\n");
                    sb.Append(querystring.Get(key));
                    sb.Append("\r\n");
                }
            }
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append(string.Format(@"Content-Disposition: form-data; name=""{0}""; filename=""{1}""", fileFormName, filePath));
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contenttype);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.GetEncoding("Shift-JIS").GetBytes(postHeader);

            // Build the trailing boundary string as a byte array
            // ensuring the boundary appears on a line by itself
            byte[] boundaryBytes =
                   Encoding.GetEncoding(932).GetBytes("\r\n--" + boundary + "\r\n");

            long length = postHeaderBytes.Length + stream.Length +
                                                   boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            // Write out our post header
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // Write out the file contents
            byte[] buffer = new Byte[checked((uint)Math.Min(4096,
                                     (int)stream.Length))];
            int bytesRead = 0;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // Write out the trailing boundary
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse responce = webrequest.GetResponse();
            Stream s = responce.GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.GetEncoding("Shift-JIS"));

            return sr.ReadToEnd();
        }
    }
}
